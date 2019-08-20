using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("notificationtype")]
    public class NotificationTypeController : ApiController
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMediatorHandler bus;

        public NotificationTypeController(INotificationTypeRepository notificationTypeRepository,
                              IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _notificationTypeRepository = notificationTypeRepository;
            bus = mediator;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult GetAll()
            => Response(_notificationTypeRepository.GetAll());


    }
}
