
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SocialHeroes.Domain.Commands;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Events;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Domain.CommandsHandler
{
    public class HairCommandHandler : CommandHandler,
           IRequestHandler<RegisterNewHairCommand, CommandResult>
    {
        private readonly IHairRepository _hairRepository;
        private readonly IMediatorHandler Bus;
        private readonly DomainNotificationHandler _notificationsCommand;

        public HairCommandHandler(IHairRepository hairRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _hairRepository = hairRepository;
            Bus = bus;
            _notificationsCommand = (DomainNotificationHandler)notifications;
        }

        public Task<CommandResult> Handle(RegisterNewHairCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                var notifications = _notificationsCommand.GetNotifications();
                return Task.FromResult(new CommandResult(false, null, _notificationsCommand.GetNotifications()));
            }

            var hair = new Hair(Guid.NewGuid(), request.Color);

            _hairRepository.Add(hair);

            if (Commit())
            {
                Bus.RaiseEvent(new HairRegisteredEvent(hair.Id, hair.Color));
                return Task.FromResult(new CommandResult(true, hair));
            }
            else
                return Task.FromResult(new CommandResult(false, null, _notificationsCommand.GetNotifications()));      
            
        }

        public void Dispose()
        {
            _hairRepository.Dispose();
        }
    }
}
