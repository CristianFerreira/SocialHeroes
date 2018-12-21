using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class HospitalUser : IEntity
    {
        private HospitalUser()  {}
        public HospitalUser(Guid id, Guid userId, string socialReason, string fantasyName, string cnpj)
        {
            Id = id;
            UserId = userId;
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = cnpj;        
        }

        public Guid Id { get; private set; }
        public string SocialReason { get; private set; }
        public string FantasyName { get; private set; }
        public string CNPJ { get; private set; }

        [JsonIgnore]
        public User User { get; private set; }
        public Guid UserId { get; private set; }

        public Notification Notification { get; set; }

        public ICollection<Phone> Phones { get; private set; }


    }
}
