using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.AccountCommand;
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
        public IActionResult Register([FromBody]RegisterNewDonatorAccountCommand command) => Response(bus.SendCommand(command).Result);

        [HttpPost]
        [Route("account/hospital")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterNewHospitalAccountCommand command) => Response(bus.SendCommand(command).Result);

        [HttpPost]
        [Route("account/token")]
        [AllowAnonymous]
        public IActionResult Token([FromBody]GetTokenAccountCommand command) => Response(bus.SendCommand(command).Result);
    }
}
