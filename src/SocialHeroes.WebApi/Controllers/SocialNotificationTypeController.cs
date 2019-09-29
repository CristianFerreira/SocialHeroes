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
    [Route("socialnotificationtype")]
    public class SocialNotificationTypeController : ApiController
    {
        private readonly ISocialNotificationTypeRepository _socialNotificationTypeRepository;
        private readonly IMediatorHandler bus;

        public SocialNotificationTypeController(ISocialNotificationTypeRepository socialNotificationTypeRepository,
                                           IMediatorHandler mediator,
                                           INotificationHandler<DomainNotification> notifications)
                                             : base(notifications)
        {
            _socialNotificationTypeRepository = socialNotificationTypeRepository;
            bus = mediator;
        }

        [HttpGet("")]
        public IActionResult GetAll()
          => Response(_socialNotificationTypeRepository.GetAll());
    }
}
