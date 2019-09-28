using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHeroes.WebApi.Controllers
{
    public class DonatorUserController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IUserSocialNotificationTypeRepository _userSocialNotificationTypeRepository;

        public DonatorUserController(IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications,
                              IDonatorUserRepository donatorUserRepository,
                              IUserSocialNotificationTypeRepository userSocialNotificationTypeRepository)
                              : base(notifications)
        {
            Bus = mediator;
            _donatorUserRepository = donatorUserRepository;
            _userSocialNotificationTypeRepository = userSocialNotificationTypeRepository;
        }

        [HttpGet]
        [Route("donatorUser/account/{donatorUserId}")]
        [AllowAnonymous]
        public IActionResult GetDonatorUserAccount(Guid donatorUserId)
        {
            UserAccountQuery userAccount = null;
            var donatorUser = _donatorUserRepository.GetById(donatorUserId);
            if (donatorUser != null)
            {
                var userSocialNotificationCodes = _userSocialNotificationTypeRepository.GetUserSocialNotificationTypeCode(donatorUser.UserId);
                userAccount = new UserAccountQuery()
                {
                    ActivedBloodNotification = donatorUser.ActivedBloodNotification,
                    ActivedHairNotification = donatorUser.ActivedHairNotification,
                    CellPhone = donatorUser.CellPhone,
                    LastDonatedBlood = donatorUser.LastDonatedBlood,
                    LastDonatedHair = donatorUser.LastDonatedHair,
                    SocialNotificationTypeCodes = userSocialNotificationCodes
                };
            };

            return Response(userAccount);
        }
    }

}
