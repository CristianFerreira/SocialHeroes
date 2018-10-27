using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Models;
using System;

namespace SocialHeroes.Domain.Models
{
    public class HospitalUser : Entity
    {
        public HospitalUser(Guid id, Guid userId, string socialReason, string fantasyName, string CNPJ, bool actived)
        {
            Id = id;
            UserId = userId;
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = CNPJ;
            Actived = actived;         
        }

        public string SocialReason { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public bool Actived { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
