using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface INotificationTypeRepository : IRepository<NotificationType>
    {
        NotificationType GetByName(string name);

        ICollection<NotificationType> GetByUserId(Guid userId);
    }
}
