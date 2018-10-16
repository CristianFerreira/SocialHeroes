using SocialHeroes.Shared.Commands;
using System;

namespace SocialHeroes.Domain.DonatorContext.Commands.HairCommands.Inputs
{
    public class HairCommandResult : ICommandResult
    {
        public HairCommandResult(){}

        public HairCommandResult(Guid id, string color)
        {
            Id = id;
            Color = color;
        }

        public Guid Id { get; set; }
        public string Color { get; set; }
    }
}
