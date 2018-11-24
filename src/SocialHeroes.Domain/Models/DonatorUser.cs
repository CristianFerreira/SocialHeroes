using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUser : IEntity
    {
        private DonatorUser() {}
        public DonatorUser(Guid id,
                          Guid userId, 
                          string name, 
                          EGenre genre, 
                          DateTime dateBirth,
                          DateTime? lastDonation = null, 
                          string cpf = null, 
                          string cellPhone = null)
        {
            Id = id;
            UserId = userId;
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
        public bool ActivedBloodNotification { get; private set; }
        public bool ActivedHairNotification { get; private set; }
        public bool ActivedBreastMilkNotification { get; private set; }


        [JsonIgnore]
        public User User { get; private set; }
        public Guid UserId { get; private set; }

        [JsonIgnore]
        public Hair Hair { get; private set; }
        public Guid? HairId { get; private set; }

    }
}
