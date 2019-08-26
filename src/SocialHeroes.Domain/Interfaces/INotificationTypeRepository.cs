using SocialHeroes.Domain.Models;

namespace SocialHeroes.Domain.Interfaces
{
    public interface INotificationTypeRepository : IRepository<NotificationType>
    {
        NotificationType GetByName(string name);
    }
}
