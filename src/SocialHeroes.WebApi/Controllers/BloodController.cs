using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.Blood.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{
    [Route("blood")]
    public class BloodController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly IBloodRepository _bloodRepository;

        public BloodController(IMediatorHandler mediator,
                               INotificationHandler<DomainNotification> notifications,
                               IBloodRepository bloodRepository)
                              : base(notifications)
        {
            Bus = mediator;
            _bloodRepository = bloodRepository;
        }

        [HttpGet("")]
        public IActionResult GetAll()
            => Response(_bloodRepository.GetAll());

        //[Authorize(Roles = "Admin")]
        [HttpPost("")]
        public IActionResult Post([FromBody]RegisterNewBloodCommand registerNewBloodCommand)
            => Response(Bus.SendCommand(registerNewBloodCommand).Result);

    }
}
