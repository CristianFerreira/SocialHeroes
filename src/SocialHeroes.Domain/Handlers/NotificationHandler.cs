using MediatR;
using SocialHeroes.Domain.Commands.Notification.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class NotificationHandler : Handler,
                 IRequestHandler<NotifyDonatorUserCommand, ICommandResult>
    {
        public NotificationHandler(IUnitOfWork uow, 
                                  IMediatorHandler bus, 
                                  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public Task<ICommandResult> Handle(NotifyDonatorUserCommand request, CancellationToken cancellationToken)
        {
            return CompletedTask();
        }
    }
}
