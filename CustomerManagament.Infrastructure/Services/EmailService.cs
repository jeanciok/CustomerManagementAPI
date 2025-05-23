﻿using CustomerManagament.Infrastructure.Models;
using CustomerManagement.Core.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
            message.To.Add(MailboxAddress.Parse(recipient));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink)
        {
            var body = $@"
            <h3>Redefinição de Senha</h3>
            <p>Clique no link abaixo (válido por 15 minutos):</p>
            <a href='{resetLink}'>{resetLink}</a>
            <p><em>Se você não solicitou isso, ignore este email.</em></p>
            <p>Equipe Customer Management</p>";

            await SendEmailAsync(
                recipient: email,
                subject: "Redefinição de Senha",
                body: body
            );
        }
    }
}
