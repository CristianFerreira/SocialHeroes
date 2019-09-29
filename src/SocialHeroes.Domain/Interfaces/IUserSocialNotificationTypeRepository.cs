using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IUserSocialNotificationTypeRepository : IRepository<UserSocialNotificationType>
    {
        ICollection<string> GetUserSocialNotificationTypeCode(Guid userId);
        ICollection<UserSocialNotificationType> GetUserSocialNotificationTypeByUserId(Guid userId);
    }
}
