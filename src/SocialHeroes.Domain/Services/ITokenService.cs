using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Responses;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Services
{
    public interface ITokenService
    {
        DateTime InitialDate { get; }
        DateTime ExpirationDate { get; }

        TokenResponse CreateToken(User user, IList<string> roles, string userName);
    }
}
