using ECommerce.Application.Interfaces;
using ECommerce.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerce.Application.UseCases.Orders.EventHandlers;

public class SendEmailOnOrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<SendEmailOnOrderCreatedEventHandler> _logger;
    private readonly IEmailService _emailService;
    public SendEmailOnOrderCreatedEventHandler(ILogger<SendEmailOnOrderCreatedEventHandler> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        var htmlBody = """
    <!DOCTYPE html>
    <html lang="en">
    <head>
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    <body style="margin: 0; padding: 0; background-color: #f4f6f9; font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;">
      <table role="presentation" width="100%" cellspacing="0" cellpadding="0" style="background-color: #f4f6f9; padding: 40px 10px;">
        <tr>
          <td align="center">
            <table role="presentation" width="100%" style="max-width: 600px; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);">
              
              <!-- Header Banner -->
              <tr>
                <td style="background-color: #0f172a; padding: 32px; text-align: center;">
                  <h1 style="color: #ffffff; margin: 0; font-size: 24px; font-weight: 700; letter-spacing: 0.5px;">E-Commerce Store</h1>
                </td>
              </tr>

              <!-- Main Body -->
              <tr>
                <td style="padding: 40px 32px; text-align: center;">
                  <!-- Checkmark Icon -->
                  <div style="display: inline-block; width: 64px; height: 64px; background-color: #dcfce7; border-radius: 50%; line-height: 64px; margin-bottom: 24px;">
                    <span style="color: #16a34a; font-size: 32px; font-weight: bold;">✓</span>
                  </div>

                  <h2 style="color: #0f172a; margin: 0 0 12px 0; font-size: 26px; font-weight: 700;">Order Confirmed!</h2>
                  <p style="color: #475569; font-size: 16px; line-height: 1.6; margin: 0 0 28px 0;">
                    Thank you for your purchase. We've received your order, and our team is already preparing your items for shipment.
                  </p>
                  
                  <!-- Info Callout Box -->
                  <div style="background-color: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 20px; text-align: left; margin-bottom: 32px;">
                    <h3 style="color: #1e293b; margin: 0 0 8px 0; font-size: 15px; font-weight: 600;">What happens next?</h3>
                    <p style="color: #64748b; font-size: 14px; line-height: 1.5; margin: 0;">
                      We'll send you a follow-up email with full tracking details as soon as your package leaves our warehouse.
                    </p>
                  </div>

                  <!-- Call To Action Button -->
                  <a href="https://yourstore.com/account" style="display: inline-block; background-color: #2563eb; color: #ffffff; text-decoration: none; font-size: 15px; font-weight: 600; padding: 14px 32px; border-radius: 8px; box-shadow: 0 2px 4px rgba(37, 99, 235, 0.2);">
                    View Account & Orders
                  </a>
                </td>
              </tr>

              <!-- Footer -->
              <tr>
                <td style="background-color: #f8fafc; padding: 24px 32px; text-align: center; border-top: 1px solid #e2e8f0;">
                  <p style="color: #94a3b8; font-size: 13px; margin: 0 0 8px 0;">Need help? Simply reply to this email or contact support.</p>
                  <p style="color: #cbd5e1; font-size: 12px; margin: 0;">&copy; 2026 E-Commerce Store. All rights reserved.</p>
                </td>
              </tr>

            </table>
          </td>
        </tr>
      </table>
    </body>
    </html>
    """;

        await _emailService.SendEmailAsync(
            notification.CustomerEmail,
            $"Order Confirmation",
            htmlBody,
            cancellationToken);
        _logger.LogInformation($"[EMAIL SERVICE] Sending order confirmation email to {notification.CustomerEmail} for new Order");

    }
}
