using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Commands;

namespace SocialHeroes.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected ApiController(){}

        protected new IActionResult Response(CommandResult result = null)
        {
            if (result.Sucess)
            {
                return Ok(new
                {
                    success = result.Sucess,
                    data = result.Data
                });
            }

            return BadRequest(new
            {
                success = result.Sucess,
                errors = result.Notifications
            });
        }
    }
}
