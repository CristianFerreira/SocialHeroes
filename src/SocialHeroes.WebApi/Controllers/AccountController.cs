using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Infra.CrossCutting.Identity.Models;
using SocialHeroes.Infra.CrossCutting.Identity.Models.AccountViewModels;
using System.Threading.Tasks;

namespace SocialHeroes.WebApi.Controllers
{

    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        [Route("account/register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            return Response(new Domain.Core.Commands.CommandResult(true, null));
        }
    }
}
