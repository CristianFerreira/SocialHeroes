using System;

namespace SocialHeroes.Domain.Queries
{
    public class DonatorUserToNotifyQuery
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public Guid DonatorUserId { get; set; }
        public Guid UserId { get; set; }
    }
}
