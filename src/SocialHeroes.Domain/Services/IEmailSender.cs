using System.Threading.Tasks;

namespace SocialHeroes.Domain.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
