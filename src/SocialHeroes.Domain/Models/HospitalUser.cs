using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class HospitalUser : IEntity
    {
        public HospitalUser()  {}
        public HospitalUser(Guid id, User user, string socialReason, string fantasyName, string cnpj)
        {
            Id = id;
            UserId = user.Id;
            User = user;
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Actived = false;         
        }

        public Guid Id { get; private set; }
        public string SocialReason { get; private set; }
        public string FantasyName { get; private set; }
        public string CNPJ { get; private set; }
        public bool Actived { get; private set; }

        [JsonIgnore]
        public User User { get; private set; }
        public Guid UserId { get; private set; }


        public void Activate() => Actived = true;
        public void Disable() => Actived = false;

    }
}
