using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace SocialHeroes.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<ICommandResult> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
