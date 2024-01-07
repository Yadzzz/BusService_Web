using System.Net;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Logging;
using Template_Web.Accelerator.Models.Email;

namespace Template_Web.Accelerator.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(ILogger<EmailService> logger, IEmailConfiguration emailConfiguration)
        {
            _logger = logger;
            _emailConfiguration = emailConfiguration;
        }

        public async Task<bool> SendEmailAsync(EmailDataModel emailData)
        {
            MailMessage mail = new MailMessage(_emailConfiguration.Email, emailData.To);
            mail.Subject = emailData.Subject;
            mail.Body = emailData.Body;

            SmtpClient smtpClient = new SmtpClient(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
            smtpClient.Port = 587; // Use 465 for SSL
            smtpClient.Credentials = new NetworkCredential(_emailConfiguration.Email, _emailConfiguration.Password);
            smtpClient.EnableSsl = true;

            try
            {
                await smtpClient.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return false;
            }
        }
    }
}
