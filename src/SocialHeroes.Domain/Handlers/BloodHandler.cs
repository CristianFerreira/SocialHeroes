using MediatR;
using SocialHeroes.Domain.Commands.Blood.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class BloodHandler : Handler,
          IRequestHandler<RegisterNewBloodCommand, ICommandResult>
    {
        private readonly IBloodRepository _bloodRepository;
        private readonly IMediatorHandler Bus;

        public BloodHandler(IBloodRepository bloodRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bloodRepository = bloodRepository;
            Bus = bus;
        }

        public Task<ICommandResult> Handle(RegisterNewBloodCommand command, CancellationToken cancellationToken)
        {
            var blood = new Blood(Guid.NewGuid(), command.Type);
            _bloodRepository.Add(blood);
            Commit();

            return CompletedTask(blood);
        }

        public void Dispose()
        {
            _bloodRepository.Dispose();
        }
    }
}
