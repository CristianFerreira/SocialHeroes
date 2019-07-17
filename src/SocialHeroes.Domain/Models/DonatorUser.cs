using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUser : IEntity
    {
        protected DonatorUser() {}
        public DonatorUser(Guid id,
                           Guid userId, 
                           string name, 
                           EGenre genre, 
                           DateTime dateBirth,
                           DateTime? lastDonatedBlood = null,
                           DateTime? lastDonatedHair = null,
                           DateTime? lastDonatedBreastMilk = null,
                           string cpf = null, 
                           string cellPhone = null)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Genre = genre;
            DateBirth = dateBirth;
            LastDonatedBlood = lastDonatedBlood;
            LastDonatedHair = lastDonatedHair;
            LastDonatedBreastMilk = lastDonatedBreastMilk;
            CPF = cpf;
            CellPhone = cellPhone;
            ActivedBloodNotification = true;
            ActivedHairNotification = true;
            ActivedBreastMilkNotification = true;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string CellPhone { get; private set; }
        public EGenre Genre { get; private set; }
        public DateTime DateBirth { get; private set; }

        public DateTime? LastDonatedBlood { get; private set; }
        public DateTime? LastDonatedHair { get; private set; }
        public DateTime? LastDonatedBreastMilk { get; private set; }

        public DateTime? LastBloodNotification{ get; private set; }
        public DateTime? LastHairNotification { get; private set; }
        public DateTime? LastBreastMilkNotification { get; private set; }

        public bool ActivedBloodNotification { get; private set; }
        public bool ActivedHairNotification { get; private set; }
        public bool ActivedBreastMilkNotification{ get; private set; }


        [JsonIgnore]
        public User User { get; private set; }
        public Guid UserId { get; private set; }

        [JsonIgnore]
        public Blood Blood { get; private set; }
        public Guid? BloodId { get; private set; }

        [JsonIgnore]
        public Hair Hair { get; private set; }
        public Guid? HairId { get; private set; }

        public ICollection<DonatorUserBloodNotification> DonatorUserBloodNotifications { get; private set; }
        public ICollection<DonatorUserHairNotification> DonatorUserHairNotifications { get; private set; }
        public ICollection<DonatorUserBreastMilkNotification> DonatorUserBreastMilkNotifications { get; private set; }


        public void AddLastBreastMilkNotification()
        => LastBreastMilkNotification = DateTime.Now;

        public void AddLastBloodNotification()
        => LastBloodNotification = DateTime.Now;

        public void AddLastHairNotification()
        => LastHairNotification = DateTime.Now;
    }
}
