using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public User(){}
        public User(Guid id, EUserType userType)
        {
            Id = id;
            UserType = userType;
        }

        public EUserType UserType { get; set; }

        public ICollection<DonatorUser> DonatorsUsers { get; set; }

        public ICollection<HospitalUser> HospitalsUsers { get; set; }
    }
}
