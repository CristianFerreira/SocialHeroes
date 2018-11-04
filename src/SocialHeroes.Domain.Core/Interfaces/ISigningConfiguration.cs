using Microsoft.IdentityModel.Tokens;

namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ISigningConfiguration
    {
        SecurityKey Key { get; }
        SigningCredentials SigningCredentials { get;}
    }
}
