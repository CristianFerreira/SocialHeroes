using System;

namespace SocialHeroes.Domain.ResponseModels
{
    public class TokenResponse
    {
        public TokenResponse(UserResponse user,
                             string accessToken,
                             bool authenticated,
                             DateTime created,
                             DateTime expiration)
        {
            User = user;
            AccessToken = accessToken;
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
        }
        public UserResponse User { get; }
        public string AccessToken { get; }
        public bool Authenticated { get; }
        public DateTime Created { get; }
        public DateTime Expiration { get; }

    }
}
