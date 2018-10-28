﻿using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        //public User(){}
        public User(Guid id, EUserType userType, string email)
        {
            Id = id;
            UserType = userType;
            Email = email;
            UserName = email;
            EmailConfirmed = true;
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            AccessFailedCount = 0;
            LockoutEnabled = true;
        }

        public EUserType UserType { get; set; }
        public ICollection<DonatorUser> DonatorsUsers { get; set; }
        public ICollection<HospitalUser> HospitalsUsers { get; set; }
    }
}
