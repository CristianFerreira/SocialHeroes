using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("donatoruserhairnotification")]
    public class DonatorUserHairNotificationController : ApiController
    {
        private readonly IDonatorUserHairNotificationRepository _donatorUserHairNotificationRepository;
        private readonly IMediatorHandler bus;

        public DonatorUserHairNotificationController(IDonatorUserHairNotificationRepository donatorUserHairNotificationRepository,
                              IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _donatorUserHairNotificationRepository = donatorUserHairNotificationRepository;
            bus = mediator;
        }

        [HttpGet]
        [Route("requests/{donatorUserId}")]
        [AllowAnonymous]
        public IActionResult GetByUserId(Guid donatorUserId)
           => Response(_donatorUserHairNotificationRepository.GetRequestsByDonatorUserId(donatorUserId));
    }
}
