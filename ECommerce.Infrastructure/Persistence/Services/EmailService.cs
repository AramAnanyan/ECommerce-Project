using ECommerce.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace ECommerce.Infrastructure.Persistence.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default)
    {

        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(
            _config["SmtpSettings:SenderName"],
            _config["SmtpSettings:SenderEmail"]));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        email.Body = bodyBuilder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(
            _config["SmtpSettings:Host"],
            int.Parse(_config["SmtpSettings:Port"]!),
            MailKit.Security.SecureSocketOptions.StartTls,
            cancellationToken);

        await smtp.AuthenticateAsync(
            _config["SmtpSettings:Username"],
            _config["SmtpSettings:Password"],
            cancellationToken);

        await smtp.SendAsync(email, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }
}
