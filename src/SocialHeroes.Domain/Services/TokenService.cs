using Microsoft.IdentityModel.Tokens;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SocialHeroes.Domain.Services
{

    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly SigningConfiguration _signingConfiguration;

        public TokenService(TokenConfiguration tokenConfiguration,
                            SigningConfiguration signingConfiguration)
        {                 
            _tokenConfiguration = tokenConfiguration;
            _signingConfiguration = signingConfiguration;
            InitialDate = DateTime.Now;
            ExpirationDate = InitialDate.AddDays(_tokenConfiguration.DaysTokenExpiration);
        }

        public DateTime InitialDate { get; }
        public DateTime ExpirationDate { get; }

        private ClaimsIdentity CreateClaimsIdentity(User user, IList<string> roles)
        {
            Claim[] claims = new[]
                                   {
                                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
                                   };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");
            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return claimsIdentity;
        }

        public TokenResponse CreateToken(Guid genericUserId, User user, IList<string> roles, string userName)
        {

            var handlerToken = new JwtSecurityTokenHandler();
            var securityToken = handlerToken.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = CreateClaimsIdentity(user, roles),
                NotBefore = InitialDate,
                Expires = ExpirationDate
            });

            return new TokenResponse(genericUserId,
                                     new UserResponse(user.Id,
                                                      userName,
                                                      user.UserType),
                                     handlerToken.WriteToken(securityToken),
                                     true,
                                     InitialDate,
                                     ExpirationDate);
        }

   
       
    }
}
