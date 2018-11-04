using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.ResponseModels;
using System;

namespace SocialHeroes.Domain.Services
{
    public interface ITokenService
    {
        DateTime InitialDate { get; }
        DateTime ExpirationDate { get; }

        TokenResponse CreateToken(User user, string userName, int daysTokenExpiration);
    }
}
