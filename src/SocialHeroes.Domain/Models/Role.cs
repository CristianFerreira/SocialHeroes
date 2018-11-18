using Microsoft.AspNetCore.Identity;
using System;

namespace SocialHeroes.Domain.Models
{
    public class Role : IdentityRole<Guid>
    {
        private Role(){}
        public Role(string role)
        {
            Name = role;
        }
    }
}
