using MediatR;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using System.Threading.Tasks;


namespace SocialHeroes.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
        Task SendMirrorCommand<T>(T command) where T : IRequest;
    }
}
