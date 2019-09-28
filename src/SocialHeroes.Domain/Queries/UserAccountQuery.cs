using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Queries
{
    public class UserAccountQuery
    {
        public DateTime?LastDonatedBlood { get; set; }
        public DateTime? LastDonatedHair { get; set; }

        public bool ActivedBloodNotification { get; set; }

        public bool ActivedHairNotification { get; set; }

        public string CellPhone { get; set; }

        public ICollection<string> SocialNotificationTypeCodes { get; set; }
    }
}
