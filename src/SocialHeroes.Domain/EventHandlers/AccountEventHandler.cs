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
            var from = "socialheroes_app@outlook.com";
            var to = notification.Email;
            var body = $"<span>Seu cadastro foi ativado no Social Heroes, agora você pode solicitar doações!</span>";
            new EmailService().SendEmail(from, to, "usuario inativo", body);

            return Task.CompletedTask;
        }

        public Task Handle(InactiveUserAccountEvent notification, CancellationToken cancellationToken)
        {
            var from = "socialheroes_app@outlook.com";
            var to = "socialheroes_app@outlook.com";
            var body = $"<span>Usuario cadastrado está inativo: <bold>{notification.Email}</bold></span>";
            new EmailService().SendEmail(from, to, "usuario inativo", body);


            return Task.CompletedTask;
        }
    }

}
