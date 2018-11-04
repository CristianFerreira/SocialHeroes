using System.Threading.Tasks;

namespace SocialHeroes.Domain.Cores.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
