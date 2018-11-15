using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(object data)
        {
            Data = data;
        }
        public object Data { get; set; }
    }
}
