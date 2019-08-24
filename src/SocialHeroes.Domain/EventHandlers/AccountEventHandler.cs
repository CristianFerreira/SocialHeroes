using MediatR;
using SocialHeroes.Domain.Events.AccountEvent;
using SocialHeroes.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.EventHandlers
{
    public class AccountEventHandler : INotificationHandler<PendingUserAccountEvent>,
                                       INotificationHandler<ActiveUserAccountEvent>
    {
        public Task Handle(ActiveUserAccountEvent notification, CancellationToken cancellationToken)
        {
            var from = "socialheroes_comunicacao@outlook.com";
            var to = notification.Email;
            var body = $"<span>Seu cadastro foi ativado no Social Heroes, agora você pode solicitar doações!</span>";
            new EmailService().SendEmail(from, to, "Cadastro ativado", body);

            return Task.CompletedTask;
        }

        public Task Handle(PendingUserAccountEvent notification, CancellationToken cancellationToken)
        {
            var from = "socialheroes_comunicacao@outlook.com";
            var to = "socialheroes_app@outlook.com";
            var body = $"<span>Usuario cadastrado está pendente de ativação: <strong>{notification.Email}</strong></span>";
            new EmailService().SendEmail(from, to, "Usuario pendente de ativação", body);


            return Task.CompletedTask;
        }
    }

}
