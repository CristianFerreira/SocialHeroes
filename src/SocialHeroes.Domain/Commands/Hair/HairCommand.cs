using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Hair
{
    public abstract class HairCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Color { get; protected set; }
        public string Type { get; protected set; }
    }
}
