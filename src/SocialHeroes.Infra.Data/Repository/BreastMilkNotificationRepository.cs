﻿using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class BreastMilkNotificationRepository : Repository<BreastMilkNotification>, IBreastMilkNotificationRepository
    {
        public BreastMilkNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
