using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("donatoruserbloodnotification")]
    public class DonatorUserBloodNotificationController : ApiController
    {
        private readonly IDonatorUserBloodNotificationRepository _donatorUserBloodNotificationRepository;
        private readonly IMediatorHandler bus;

        public DonatorUserBloodNotificationController(IDonatorUserBloodNotificationRepository donatorUserBloodNotificationRepository,
                              IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _donatorUserBloodNotificationRepository = donatorUserBloodNotificationRepository;
            bus = mediator;
        }

        [HttpGet]
        [Route("requests/{donatorUserId}")]
        [AllowAnonymous]
        public IActionResult GetByUserId(Guid donatorUserId)
         => Response(_donatorUserBloodNotificationRepository.GetRequestsByDonatorUserId(donatorUserId));
    }
}