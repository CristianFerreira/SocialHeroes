namespace SocialHeroes.Domain.Queries
{
    public class DonatorUserHairToNotifyQuery : DonatorUserToNotifyQuery
    {
        public string Color { get; set; }
        public string Type { get; set; }
    }
}
