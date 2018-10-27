using System.Threading.Tasks;

namespace SocialHeroes.Domain.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
