using System.Threading.Tasks;

namespace SocialHeroes.Domain.Cores.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
