using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class UserSocialNotificationTypeRepository : Repository<UserSocialNotificationType>, IUserSocialNotificationTypeRepository
    {
        public UserSocialNotificationTypeRepository(SocialHeroesContext context) : base(context)
        {
        }

        public ICollection<UserSocialNotificationType> GetUserSocialNotificationTypeByUserId(Guid userId)
        => (from usnt in Db.UserSocialNotificationTypes
            where usnt.UserId == userId
            select usnt).ToList();

        public ICollection<string> GetUserSocialNotificationTypeCode(Guid userId)
         => (from usnt in Db.UserSocialNotificationTypes
            join snt in Db.SocialNotificationTypes on usnt.SocialNotificationTypeId equals snt.Id
            where usnt.UserId == userId
            select snt.Code).ToList();



    }
}
