using ECommerce.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ECommerce.Infrastructure.BackgroundJobs;

public class OutboxProcessorJob:BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public OutboxProcessorJob(
        IServiceProvider serviceProvider,
        ILogger<OutboxProcessorJob> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

                var messages = await dbContext.OutboxMessages
                    .Where(m => m.ProcessedOnUtc == null && m.RetryCount < 3)
                    .OrderBy(m => m.OccurredOnUtc)
                    .Take(20)
                    .ToListAsync(stoppingToken);

                foreach (var message in messages)
                {
                    try
                    {
                        var eventType = Type.GetType(message.Type);
                        if (eventType == null)
                        {
                            _logger.LogError("Could not resolve event type: {Type}", message.Type);
                            continue;
                        }

                        var domainEvent = JsonSerializer.Deserialize(message.Content, eventType);
                        if (domainEvent != null)
                        {
                            await publisher.Publish(domainEvent, stoppingToken);
                        }

                        message.ProcessedOnUtc = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        message.RetryCount++;
                        message.Error = ex.Message;
                        _logger.LogError(ex, "Failed to process outbox message {Id}. Attempt {Count}", message.Id, message.RetryCount);
                    }
                }

                if (messages.Any())
                {
                    await dbContext.SaveChangesAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in OutboxProcessorJob loop");
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
