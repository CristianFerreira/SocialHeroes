using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(IEntity data) => Data = data;
        public IEntity Data { get; private set; }
    }
}
