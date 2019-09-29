using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Account.RequestCommand
{
    public class UpdateDonatorUserCommand : DonatorUserCommand
    {
        public UpdateDonatorUserCommand(Guid id, string cellPhone, IList<Guid> socialNotificationTypesId)
        {
            Id = id;
            CellPhone = cellPhone;
            SocialNotificationTypesId = socialNotificationTypesId;
        }

        public IList<Guid> SocialNotificationTypesId { get; }
    }
}
