namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ITokenConfiguration
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        int Seconds { get; set; }
        int DaysTokenExpiration { get; set; }
    }
}
