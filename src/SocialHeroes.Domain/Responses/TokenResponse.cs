using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Responses
{
    public class TokenResponse : IEntity
    {
        public TokenResponse(UserResponse user,
                             string accessToken,
                             bool authenticated,
                             DateTime created,
                             DateTime expiration)
        {
            Id = Guid.NewGuid();
            User = user;
            AccessToken = accessToken;
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
        }
        public Guid Id { get; }
        public UserResponse User { get; }
        public string AccessToken { get; }
        public bool Authenticated { get; }
        public DateTime Created { get; }
        public DateTime Expiration { get; }

       
    }
}
