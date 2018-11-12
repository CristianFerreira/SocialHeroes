using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Configurations
{
    public class TokenConfiguration : ITokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public int DaysTokenExpiration { get; set; }
    }
}
