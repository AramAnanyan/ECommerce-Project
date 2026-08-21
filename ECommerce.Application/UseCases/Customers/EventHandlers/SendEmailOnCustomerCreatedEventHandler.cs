using ECommerce.Application.Interfaces;
using ECommerce.Application.UseCases.Orders.EventHandlers;
using ECommerce.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Customers.EventHandlers;

internal class SendEmailOnCustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{

    private readonly ILogger<SendEmailOnCustomerCreatedEventHandler> _logger;
    private readonly IEmailService _emailService;
    public SendEmailOnCustomerCreatedEventHandler(ILogger<SendEmailOnCustomerCreatedEventHandler> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }
    public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        var htmlBody = """
    <!DOCTYPE html>
    <html lang="en">
    <head>
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1.0">
      <title>Welcome to E-Commerce Store!</title>
    </head>
    <body style="margin: 0; padding: 0; background-color: #f1f5f9; font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;">
      <table role="presentation" width="100%" cellspacing="0" cellpadding="0" style="background-color: #f1f5f9; padding: 40px 10px;">
        <tr>
          <td align="center">
            <table role="presentation" width="100%" style="max-width: 600px; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 10px 25px rgba(0, 0, 0, 0.05);">
              
              <!-- Header Banner -->
              <tr>
                <td style="background: linear-gradient(135deg, #4f46e5 0%, #7c3aed 100%); padding: 36px 32px; text-align: center;">
                  <h1 style="color: #ffffff; margin: 0; font-size: 26px; font-weight: 800; letter-spacing: 0.5px;">E-Commerce Store</h1>
                </td>
              </tr>

              <!-- Main Content -->
              <tr>
                <td style="padding: 40px 32px; text-align: center;">
                  
                  <!-- Icon Badge -->
                  <div style="display: inline-block; width: 72px; height: 72px; background-color: #e0e7ff; border-radius: 50%; line-height: 72px; margin-bottom: 24px;">
                    <span style="font-size: 36px;">🎉</span>
                  </div>

                  <h2 style="color: #0f172a; margin: 0 0 12px 0; font-size: 28px; font-weight: 800;">Welcome to the Family!</h2>
                  
                  <p style="color: #475569; font-size: 16px; line-height: 1.6; margin: 0 0 28px 0;">
                    We’re thrilled to have you here! Your account is officially active, unlocking instant access to top collections, express checkouts, and exclusive member deals.
                  </p>

                  <!-- Member Perks Box -->
                  <div style="background-color: #f8fafc; border: 1px dashed #cbd5e1; border-radius: 12px; padding: 24px; text-align: left; margin-bottom: 32px;">
                    <h3 style="color: #1e293b; margin: 0 0 16px 0; font-size: 15px; font-weight: 700; text-align: center;">What you can do with your account:</h3>
                    
                    <table role="presentation" width="100%" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="padding: 8px 0; color: #334155; font-size: 14px; line-height: 1.5;">⚡ <strong>Express Checkout:</strong> Save your preferences for seamless ordering.</td>
                      </tr>
                      <tr>
                        <td style="padding: 8px 0; color: #334155; font-size: 14px; line-height: 1.5;">📦 <strong>Order Tracking:</strong> Live status updates from dispatch to doorstep.</td>
                      </tr>
                      <tr>
                        <td style="padding: 8px 0; color: #334155; font-size: 14px; line-height: 1.5;">🎁 <strong>VIP Access:</strong> Early notifications on flash sales and promotions.</td>
                      </tr>
                    </table>
                  </div>

                  <!-- Call To Action Button -->
                  <a href="https://yourstore.com/shop" style="display: inline-block; background: linear-gradient(135deg, #4f46e5 0%, #7c3aed 100%); color: #ffffff; text-decoration: none; font-size: 16px; font-weight: 700; padding: 16px 36px; border-radius: 10px; box-shadow: 0 4px 12px rgba(79, 70, 229, 0.3);">
                    Start Exploring
                  </a>

                </td>
              </tr>

              <!-- Footer -->
              <tr>
                <td style="background-color: #f8fafc; padding: 28px 32px; text-align: center; border-top: 1px solid #e2e8f0;">
                  <p style="color: #64748b; font-size: 13px; margin: 0 0 8px 0;">Need help or have questions? Just reply to this email.</p>
                  <p style="color: #94a3b8; font-size: 12px; margin: 0;">&copy; 2026 E-Commerce Store. All rights reserved.</p>
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
            $"Customer created",
            htmlBody,
            cancellationToken);
        _logger.LogInformation($"[EMAIL SERVICE] Sending registration confirmation email to {notification.CustomerEmail}");
    }
}
