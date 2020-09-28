using MediatR;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialHeroes.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;



        public InMemoryBus(IMediator mediator) => _mediator = mediator; 

        public async Task<ICommandResult> SendCommand<T>(T command) where T : Command 
            => await _mediator.Send(command).ConfigureAwait(false);

        public async Task RaiseEvent<T>(T @event) where T : Event 
            =>  await _mediator.Publish(@event);
    }
}
