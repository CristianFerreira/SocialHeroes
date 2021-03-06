﻿using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SocialHeroesContext context) : base(context) {}

        public User GetByEmail(string email)
         => DbSet.AsNoTracking().FirstOrDefault(u => u.Email.ToUpper() == email.ToUpper());

        public User GetByUserType(EUserType userType) 
        => DbSet.AsNoTracking().FirstOrDefault(u => u.UserType == userType);

       


    }
}
