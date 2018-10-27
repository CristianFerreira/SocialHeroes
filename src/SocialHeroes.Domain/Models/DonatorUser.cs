using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Models;
using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUser : Entity
    {
        public DonatorUser(Guid id, Guid userId, string name, EGenre genre, DateTime dateBirth)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Genre = genre;
            DateBirth = dateBirth;
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string CellPhone { get; set; }
        public EGenre Genre { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime LastDonation { get; set; }

       
        public User User { get; set; }
        public Guid UserId { get; set; }
        
    }
}
