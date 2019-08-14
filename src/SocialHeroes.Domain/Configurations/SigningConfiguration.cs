using Microsoft.IdentityModel.Tokens;
using SocialHeroes.Domain.Core.Interfaces;
using System.Security.Cryptography;

namespace SocialHeroes.Domain.Configurations
{
    public class SigningConfiguration : ISigningConfiguration
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
