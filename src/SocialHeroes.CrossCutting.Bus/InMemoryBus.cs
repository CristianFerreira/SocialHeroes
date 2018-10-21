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
        private readonly IEventDataBase _eventDataBase;

        public InMemoryBus(IEventDataBase eventDataBase, IMediator mediator)
        {
            _eventDataBase = eventDataBase;
            _mediator = mediator;
        }

        public CommandResult SendCommand<T>(T command) where T : Command
        {
            var response = _mediator.Send(command);
            return response.Result;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventDataBase?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
