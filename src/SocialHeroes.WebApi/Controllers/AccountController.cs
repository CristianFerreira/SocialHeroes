using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.AccountCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;
using System.Threading.Tasks;

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
                                 INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _userRepository = userRepository;
            _donatorUserRepository = donatorUserRepository;
            bus = mediator;
        }

        //[HttpGet]
        //[Route("account/{userType}")]
        //[Authorize("Bearer")]
        //public async Task<IActionResult> GetByUserType(string userType)
        //{
        //    EUserType userTypeEnum = (EUserType)Enum.Parse(typeof(EUserType), userType, true);
        //    //new CommandResult(true, _userRepository.GetByUserType(userTypeEnum))

        //    return Response(new CommandResult(true, _context.GetAllUser()));
        //}


     
        [HttpPost]
        [Route("account/register/donator")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterNewDonatorAccountCommand command)
        {
            return Response(bus.SendCommand(command).Result);
        }

        
        [HttpPost]
        [Route("account/token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody]GetTokenAccountCommand command)
        {
            return Response(bus.SendCommand(command).Result);
        }
    }
}
