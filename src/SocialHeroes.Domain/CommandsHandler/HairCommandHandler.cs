
using MediatR;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            var hair = new Hair(Guid.NewGuid(), request.Color);
            _hairRepository.Add(hair);

            return (Commit()) ?  Task.FromResult(new CommandResult(true, hair)) 
                              :  Task.FromResult(new CommandResult(false, null, _notificationsCommand.GetNotifications()));      
            
        }

        public void Dispose()
        {
            _hairRepository.Dispose();
        }
    }
}
