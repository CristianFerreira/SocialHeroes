using SocialHeroes.Domain.DonatorContext.Enum;
using System;

namespace SocialHeroes.Domain.DonatorContext.Commands.HairTypeCommands
{
    public class HairTypeCommand
    {
        public Guid Id { get; set; }
        public EHairType Type { get; set; }
    }
}
