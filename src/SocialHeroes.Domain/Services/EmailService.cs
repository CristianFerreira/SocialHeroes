using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;

namespace SocialHeroes.Domain.Services
{
    public class EmailService
    {
        public void SendEmail(string from, string to, string subject, string body)
        {
            var apiKey = Environment.GetEnvironmentVariable("sendGridKey", EnvironmentVariableTarget.User);
            var client = new SendGridClient(apiKey);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(new EmailAddress(from, "Social Heroes"), new EmailAddress(to), subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
        }
    }
}
