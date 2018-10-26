using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;

namespace SocialHeroes.WebApi.Controllers
{

    public class HairController : ApiController
    {
        private readonly IMediatorHandler Bus;

        public HairController(IMediatorHandler mediator)
        {
            Bus = mediator;
        }


        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.2" };
        }

        [HttpPost]
        [Route("hairs")]
        public IActionResult Post([FromBody]RegisterNewHairCommand registerNewHairCommand)
        {
            var response = Bus.SendCommand(registerNewHairCommand);
            return Response(response.Result);
        }     
    }
}
