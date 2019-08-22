using MediatR;
using SocialHeroes.Domain.Events.AccountEvent;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.EventHandlers
{
    public class AccountEventHandler : INotificationHandler<InactiveUserAccountEvent>,
                                       INotificationHandler<ActiveUserAccountEvent>
    {
        public Task Handle(ActiveUserAccountEvent notification, CancellationToken cancellationToken)
        {
            //send email to user
            return Task.CompletedTask;
        }

        public Task Handle(InactiveUserAccountEvent notification, CancellationToken cancellationToken)
        {
            //send Email to admin
            return Task.CompletedTask;
        }
    }

}
