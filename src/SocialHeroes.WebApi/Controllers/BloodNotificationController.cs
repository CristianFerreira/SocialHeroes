using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("bloodnotification")]
    public class BloodNotificationController : ApiController
    {
        private readonly IBloodNotificationRepository _bloodNotificationRepository;
        private readonly IMediatorHandler bus;

        public BloodNotificationController(IBloodNotificationRepository bloodNotificationRepository,
                                           IMediatorHandler mediator,
                                           INotificationHandler<DomainNotification> notifications)
                                             : base(notifications)
        {
            _bloodNotificationRepository = bloodNotificationRepository;
            bus = mediator;
        }

        [HttpGet("info/enableOnPage")]
        public IActionResult GetAllEnableOnPage()
          => Response(_bloodNotificationRepository.GetAllInfoEnableOnPage());

    }

}
