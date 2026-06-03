using BusinessLogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(
            IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmail(
             string toEmail,
             string subject,
              string body)
        {
            MailMessage message =
                new MailMessage();

            message.From =
                new MailAddress(
                    _config["EmailSettings:Email"]);

            message.To.Add(toEmail);

            message.Subject = subject;

            message.Body = body;

            message.IsBodyHtml = true;

            SmtpClient smtp =
                new SmtpClient(
                    _config["EmailSettings:Host"],
                    Convert.ToInt32(
                        _config["EmailSettings:Port"]));

            smtp.Credentials =
                new NetworkCredential(
                    _config["EmailSettings:Email"],
                    _config["EmailSettings:Password"]);

            smtp.EnableSsl = true;

            await smtp.SendMailAsync(message);
        }
    }
}
