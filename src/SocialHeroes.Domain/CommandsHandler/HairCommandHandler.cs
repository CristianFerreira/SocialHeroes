
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Domain.CommandsHandler
{
    public class HairCommandHandler : CommandHandler,
           IRequestHandler<RegisterNewHairCommand>
    {
        private readonly IHairRepository _hairRepository;
        private readonly IMediatorHandler Bus;

        public HairCommandHandler(IHairRepository hairRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _hairRepository = hairRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewHairCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            var hair = new Hair(Guid.NewGuid(), request.Color);

            _hairRepository.Add(hair);

            if (Commit())
            {
               //call event to save hair in another data base 
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _hairRepository.Dispose();
        }
    }
}
