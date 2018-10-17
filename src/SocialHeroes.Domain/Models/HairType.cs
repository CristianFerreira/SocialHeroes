using SocialHeroes.Domain.DonatorContext.Enum;
using System;

namespace SocialHeroes.Domain.DonatorContext.Models
{
    public class HairType
    {
        public HairType(EHairType Type)
        {
            this.Type = Type;
        }

        public Guid Id { get; set; }
        public EHairType Type { get; private set; }
    }
}
