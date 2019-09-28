using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("institutionUser")]
    public class InstitutionUserController : ApiController
    {
        private readonly IInstitutionUserRepository _institutionUserRepository;
        private readonly IMediatorHandler bus;

        public InstitutionUserController(IInstitutionUserRepository institutionUserRepository,
                                           IMediatorHandler mediator,
                                           INotificationHandler<DomainNotification> notifications)
                                             : base(notifications)
        {
            _institutionUserRepository = institutionUserRepository;
            bus = mediator;
        }

        [HttpGet("notifications/{institutionUserId}")]
        public IActionResult GetAllNotifications(Guid institutionUserId)
          => Response(_institutionUserRepository.GetAllNotificationsByInstitutionUserId(institutionUserId));
    }
}
