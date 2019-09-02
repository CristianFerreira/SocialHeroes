using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("hairnotification")]
    public class HairNotificationController : ApiController
    {
        private readonly IHairNotificationRepository _hairNotificationRepository;
        private readonly IMediatorHandler bus;

        public HairNotificationController(IHairNotificationRepository hairNotificationRepository,
                                           IMediatorHandler mediator,
                                           INotificationHandler<DomainNotification> notifications)
                                             : base(notifications)
        {
            _hairNotificationRepository = hairNotificationRepository;
            bus = mediator;
        }

        [HttpGet("info/enableOnPage")]
        public IActionResult GetAllInfoEnableOnPage()
          => Response(_hairNotificationRepository.GetAllInfoEnableOnPage());

        [HttpGet("enableOnPage/{notificationId}")]
        public IActionResult GetEnableOnPageByNotificationId(Guid notificationId)
          => Response(_hairNotificationRepository.GetEnableOnPageByNotificationId(notificationId));

    }
}
