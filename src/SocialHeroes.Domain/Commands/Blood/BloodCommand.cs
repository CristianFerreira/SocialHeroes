using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Blood
{
    public class BloodCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Type { get; protected set; }
    }
}
