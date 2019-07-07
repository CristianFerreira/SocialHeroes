using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.Account.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{

    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IMediatorHandler bus;

        public AccountController(IUserRepository userRepository, 
                                 IDonatorUserRepository donatorUserRepository,
                                 IMediatorHandler mediator,
                                 INotificationHandler<DomainNotification> notifications) 
                                 : base(notifications)
        {
            _userRepository = userRepository;
            _donatorUserRepository = donatorUserRepository;
            bus = mediator;
        }

        [HttpPost]
        [Route("account/donator")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterNewDonatorUserCommand command) 
            => Response(bus.SendCommand(command).Result);

        [HttpPost]
        [Route("account/institution")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterNewInstitutionUserCommand command)
            => Response(bus.SendCommand(command).Result);

        [HttpPost]
        [Route("account/token")]
        [AllowAnonymous]
        public IActionResult Token([FromBody]TokenUserCommand command) 
            => Response(bus.SendCommand(command).Result);
    }
}
