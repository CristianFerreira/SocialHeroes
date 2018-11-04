using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, object data)
        {
            Sucess = sucess;
            Data = data;
        }
        public bool Sucess { get; set; }
        public object Data { get; set; }
    }
}
