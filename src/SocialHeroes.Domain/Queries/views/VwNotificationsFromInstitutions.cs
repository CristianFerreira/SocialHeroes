using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHeroes.Domain.Queries.views
{
    public class VwNotificationsFromInstitutions
    {
        public Guid InstitutionUserId { get; set; }
        public DateTime DateNotification { get; set; }
        public string TypeNotification { get; set; }
        public string TypeRequested { get; set; }
        public int CountRequested { get; set; }

    }
}
