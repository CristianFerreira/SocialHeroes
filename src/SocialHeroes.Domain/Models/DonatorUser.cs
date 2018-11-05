using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUser : IEntity
    {
        public DonatorUser() {}
        public DonatorUser(Guid id,  
                          User user, 
                          string name, 
                          EGenre genre, 
                          DateTime dateBirth,
                          DateTime? lastDonation = null, 
                          string cpf = null, 
                          string cellPhone = null)
        {
            Id = id;
            UserId = user.Id;
            User = user;
            Name = name;
            Genre = genre;
            DateBirth = dateBirth;
            LastDonation = lastDonation;
            CPF = cpf;
            CellPhone = cellPhone;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string CellPhone { get; private set; }
        public EGenre Genre { get; private set; }
        public DateTime DateBirth { get; private set; }
        public DateTime? LastDonation { get; private set; }

        [JsonIgnore]
        public User User { get; set; }

        public Guid UserId { get; private set; }
    }
}
