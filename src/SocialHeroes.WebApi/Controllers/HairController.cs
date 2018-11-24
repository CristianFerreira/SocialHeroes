using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;

namespace SocialHeroes.WebApi.Controllers
{

    public class HairController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly IHairRepository _hairRepository;

        public HairController(IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications,
                              IHairRepository hairRepository)
                              : base(notifications)
        {
            Bus = mediator;
            _hairRepository = hairRepository;
        }

        [HttpGet]
        [Route("hair/type")]
        public IActionResult GetByTypes() 
            => Response(_hairRepository.GetByType());

        [HttpGet]
        [Route("hair/color/{type}")]
        public IActionResult GetColorByType(string type) 
            => Response(_hairRepository.GetColorByType(type));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("hair")]
        public IActionResult Post([FromBody]RegisterNewHairCommand registerNewHairCommand) 
            => Response(Bus.SendCommand(registerNewHairCommand).Result);
         
    }
}
