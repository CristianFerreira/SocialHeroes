using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        private User(){}
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

        public EUserType UserType { get; private set; }

        public Address Address { get; private set; }
        public DonatorUser DonatorUser { get; private set; }
        public HospitalUser HospitalUser { get; private set; }
    }
}
