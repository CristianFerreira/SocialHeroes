using SocialHeroes.Shared.Models;
using System;

namespace SocialHeroes.Domain.DonatorContext.Models
{
    public class HairHasHairType : Entity
    {
        public HairHasHairType(Hair hair, HairType hairType)
        {
            this.HairId = hair.Id;
            this.HairTypeId = hairType.Id;
        }

        public Guid HairId { get; private set; }
        public Guid HairTypeId { get; private set; }
    }
}
