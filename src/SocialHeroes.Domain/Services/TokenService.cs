using Microsoft.IdentityModel.Tokens;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.ResponseModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace SocialHeroes.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly SigningConfiguration _signingConfiguration;

        public TokenService(TokenConfiguration tokenConfiguration,
                            SigningConfiguration signingConfiguration)
        {
            InitialDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            _tokenConfiguration = tokenConfiguration;
            _signingConfiguration = signingConfiguration;
        }

        public DateTime InitialDate { get; }
        public DateTime ExpirationDate { get; }

        private ClaimsIdentity CreateClaimsIdentity(string name, string type)
        {
            return
                new ClaimsIdentity(new GenericIdentity(name, type),
                                   new[]
                                   {
                                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                        new Claim(JwtRegisteredClaimNames.UniqueName, name)
                                   });
        }

        public TokenResponse CreateToken(User user, string userName, int daysTokenExpiration)
        {
            var handler = new JwtSecurityTokenHandler();
            var expires = ExpirationDate.AddDays(daysTokenExpiration);
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = CreateClaimsIdentity(user.Id.ToString(), "LOGIN"),
                NotBefore = InitialDate,
                Expires = expires
            });

            return new TokenResponse(new UserResponse(user.Id, 
                                                      userName, 
                                                      user.UserType),
                                     handler.WriteToken(securityToken),
                                     true,
                                     InitialDate,
                                     expires);
        }
    }
}
