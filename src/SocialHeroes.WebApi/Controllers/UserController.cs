using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("user")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler bus;

        public UserController(IUserRepository userRepository,
                              IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications)
                              : base(notifications)
        {
            _userRepository = userRepository;
            bus = mediator;
        }

        [HttpGet]
        [Route("email/{email}")]
        [AllowAnonymous]
        public IActionResult GetByEmail(string email)
            => Response(_userRepository.GetByEmail(email));

       
    }
}
