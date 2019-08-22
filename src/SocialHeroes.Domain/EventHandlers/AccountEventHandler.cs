using MediatR;
using SocialHeroes.Domain.Events.AccountEvent;
using SocialHeroes.Domain.Services;
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
            var from = "socialheroes_app@outlook.com";
            new EmailService().SendEmail(from, "cristianferreira_gks@hotmail.com", "usuario inativo", notification.Email);


            return Task.CompletedTask;
        }
    }

}
