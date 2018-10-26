using SocialHeroes.Domain.Core.Models;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUser : Entity
    {
        public User User { get; set; }
        public string CPF { get; set; }
    }
}
