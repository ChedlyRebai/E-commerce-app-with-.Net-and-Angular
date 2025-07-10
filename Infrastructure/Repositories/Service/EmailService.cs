using System;
using Core.DTO;
using Core.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace Infrastructure.Repositories.Service

{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailDTO emailDTO)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:From"]));
            mimeMessage.To.Add(MailboxAddress.Parse(emailDTO.To));
            mimeMessage.Subject = emailDTO.Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = emailDTO.Content
            };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(
                        _configuration["EmailSettings:SmtpServer"],
                        int.Parse(_configuration["EmailSettings:Port"]),
                        MailKit.Security.SecureSocketOptions.StartTls);

                    await smtp.AuthenticateAsync(
                        _configuration["EmailSettings:Username"],
                        _configuration["EmailSettings:Password"]);

                    await smtp.SendAsync(mimeMessage);
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }
        }
    }
}