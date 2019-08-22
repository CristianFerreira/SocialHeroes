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
            var apiKey = Environment.GetEnvironmentVariable("sendGridKey");
            var client = new SendGridClient(apiKey);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(new EmailAddress(from), new EmailAddress(to), subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
        }
    }
}
