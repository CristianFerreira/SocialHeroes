using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.Notification.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(IMediatorHandler mediator,
                                      INotificationHandler<DomainNotification> notifications,
                                      INotificationRepository notificationRepository)
                                      : base(notifications)
        {
            Bus = mediator;
            _notificationRepository = notificationRepository;
        }

        [HttpPost]
        [Route("notify")]
        public IActionResult Post([FromBody]NotifyDonatorUserCommand notifyDonatorUser)
            => Response(Bus.SendCommand(notifyDonatorUser).Result);

    }
}
