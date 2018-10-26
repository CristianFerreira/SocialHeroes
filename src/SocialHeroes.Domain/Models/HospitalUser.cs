using SocialHeroes.Domain.Core.Models;
using System;

namespace SocialHeroes.Domain.Models
{
    public class HospitalUser : Entity
    {       
        public string CNPJ { get; set; }
        public User User { get; set; }
    }
}
