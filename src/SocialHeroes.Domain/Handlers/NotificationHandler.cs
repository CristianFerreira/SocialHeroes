using MediatR;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.Domain.Handlers
{
    public class NotificationHandler : Handler
    {
        public NotificationHandler(IUnitOfWork uow, 
                                  IMediatorHandler bus, 
                                  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }
    }
}
