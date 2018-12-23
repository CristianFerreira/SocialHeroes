using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(IEntity data) => Data = data;
        public object Data { get; private set; }
    }
}
