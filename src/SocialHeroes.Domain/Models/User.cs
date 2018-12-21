using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

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
            UserStatus = GetUserStatus();
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            AccessFailedCount = 0;
            LockoutEnabled = true;
        }
        public EUserStatus UserStatus { get; private set; }
        public EUserType UserType { get; private set; }

        public void ActivateUser() => UserStatus = EUserStatus.Active;
        public void InactivateUser() => UserStatus = EUserStatus.Inactive;

        public Address Address { get; private set; }
        public DonatorUser DonatorUser { get; private set; }
        public HospitalUser HospitalUser { get; private set; }

        public ICollection<UserNotificationType> UserNotificationTypes { get; private set; }

        private EUserStatus GetUserStatus()
            => UserType == EUserType.Donator ? EUserStatus.Active : EUserStatus.Pending;

        
    }
}
