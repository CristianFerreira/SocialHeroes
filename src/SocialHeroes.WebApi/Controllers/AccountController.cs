using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Commands.UserCommand;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace SocialHeroes.WebApi.Controllers
{

    public class AccountController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IDonatorUserRepository _context;

        public AccountController(UserManager<User> userManager, IUserRepository userRepository, IDonatorUserRepository context)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet]
        [Route("account/{userType}")]
        public async Task<IActionResult> GetByUserType(string userType)
        {
            EUserType userTypeEnum = (EUserType)Enum.Parse(typeof(EUserType), userType, true);
            //new CommandResult(true, _userRepository.GetByUserType(userTypeEnum))
            
            return Response(new CommandResult(true, _context.GetAllUser()));
        }



        [HttpPost]
        [Route("account/register")]
        public async Task<IActionResult> Register([FromBody]RegisterNewUserCommand model)
        {

            var user = new User(Guid.NewGuid(), EUserType.Donator, model.Email );
            var result = await _userManager.CreateAsync(user, model.Password);

            var donatorUser = new DonatorUser(Guid.NewGuid(), user, "cristian", EGenre.Male, new DateTime());
            _context.Add(donatorUser);
            if(_context.SaveChanges() > 1)
            {
                return Response(new CommandResult(true, null));
            }
            else
            {
                
            }


            return Response(new CommandResult(true, null));
        }
    }
}
