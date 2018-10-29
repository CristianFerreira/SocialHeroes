using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialHeroes.Domain.Commands.UserCommand;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Configurations;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.CrossCutting.Identity.Models.AccountViewModels;
using SocialHeroes.Infra.Data.Configurations;
using SocialHeroes.Infra.Data.Context;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SocialHeroes.WebApi.Controllers
{

    public class AccountController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly IUserRepository _userRepository;
        private readonly IDonatorUserRepository _context;

        public AccountController(UserManager<User> userManager, 
                                SignInManager<User> signInManager, 
                                SigningConfiguration signingConfiguration, 
                                TokenConfiguration tokenConfiguration,
                                IUserRepository userRepository, 
                                IDonatorUserRepository context)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
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
        [Authorize("Bearer")]
        public async Task<IActionResult> Register([FromBody]RegisterNewUserCommand model)
        {

            var user = new User(Guid.NewGuid(), EUserType.Donator, model.Email, true);
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


        [HttpPost]
        [AllowAnonymous]
        [Route("account/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel usuario)
        {
            bool credenciaisValidas = false;
            var userIdentity = new User();
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                userIdentity = _userManager
                    .FindByNameAsync(usuario.Email).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = _signInManager
                        .CheckPasswordSignInAsync(userIdentity, usuario.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui a role 
                        credenciaisValidas = _userManager.IsInRoleAsync(
                            userIdentity, RolesConfiguration.ROLE_API_ADMIN).Result;
                    }
                }
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userIdentity.Id.ToString(), "Login"),
                    new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userIdentity.Id.ToString())
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _signingConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Response(new CommandResult(true, new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                }));
            }
            else
            {
                return Response(new CommandResult(true,new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    }
                ));
            }

            
              
        }
    }
}
