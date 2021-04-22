using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;

namespace YounicornApp.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public async Task<string> SendEmailAsync(string to, List<string> cc, List<string> bcc, string subject, string body)
        {
            try
            {
                var emailClient = new SmtpClient("mail.authsmtp.com");
                emailClient.Port = 2525;
                emailClient.Credentials = new System.Net.NetworkCredential("ac12652", "send2166");
                string from = @"mike@headstartsolutions.co.nz";
                var message = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body
                };
                foreach (var item in cc)
                {
                    message.CC.Add(new MailAddress(item));
                }
                foreach (var item in bcc)
                {
                    message.Bcc.Add(new MailAddress(item));
                }
                message.To.Add(new MailAddress(to));
                await emailClient.SendMailAsync(message);
                _logger.LogWarning($"Sending email to {to} from {from} with subject {subject}.");
                return $"Sending email to {to} from {from} with subject {subject}.";
            }
            catch (System.Exception exp)
            {
                return string.Format("Error-{0}",exp.Message);
            }

        }
    }
}
