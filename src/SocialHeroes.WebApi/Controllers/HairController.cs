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

        public HairController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            Bus = mediator;
        }


        [HttpGet]
        [Route("")]
        // [Route("clientes")] // Listar todos os clientes
        // [Route("clientes/2587")] // Listar o cliente 2587
        // [Route("clientes/2587/pedidos")] // Pedidos do cliente 2587
        public object Get()
        {
            return new { version = "Version 0.0.2" };
        }

        [HttpPost]
        [Route("hairs")]
        public IActionResult Post([FromBody]RegisterNewHairCommand registerNewHairCommand)
        {
            var response = Bus.SendCommand(registerNewHairCommand);
            return Response(response);
        }     
    }
}
