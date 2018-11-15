
using MediatR;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class HairHandler : Handler,
           IRequestHandler<RegisterNewHairCommand, ICommandResult>
    {
        private readonly IHairRepository _hairRepository;
        private readonly IMediatorHandler Bus;

        public HairHandler(IHairRepository hairRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _hairRepository = hairRepository;
            Bus = bus;
        }

        public Task<ICommandResult> Handle(RegisterNewHairCommand request, CancellationToken cancellationToken)
        {
            var hair = new Hair(Guid.NewGuid(), request.Color);
            _hairRepository.Add(hair);
            Commit();
            return Result(hair);
        }

        public void Dispose()
        {
            _hairRepository.Dispose();
        }
    }
}
