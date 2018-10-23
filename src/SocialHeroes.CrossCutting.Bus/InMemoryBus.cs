using MediatR;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using System.Threading.Tasks;

namespace SocialHeroes.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
           return await _mediator.Send(command).ConfigureAwait(false);
        }

        public Task SendMirrorCommand<T>(T command) where T : IRequest
        {
             return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
