using MediatR;
using SocialHeroes.Domain.Events.AccountEvent;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.EventHandlers
{
    public class AccountEventHandler : INotificationHandler<HospitalAccountRegisteredEvent>
    {
        public Task Handle(HospitalAccountRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //send email
            return Task.CompletedTask;
        }
    }
}
