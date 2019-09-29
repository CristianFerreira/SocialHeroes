using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Commands.Account
{
    public class DonatorUserCommand : UserCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EGenre Genre { get; set; }
        public Guid UserId { get; set; }
        public bool ActivedHairNotification { get; set; }
        public bool ActivedBreastMilkNotification { get; set; }
        public bool ActivedBloodNotification { get; set; }
        public Guid? HairId { get; set; }
        public Guid? BloodId { get; set; }

        public string CPF { get; set; }
        public string CellPhone { get; set; }

        public DateTime? LastDonatedBlood { get; set; }
        public DateTime? LastDonatedHair { get; set; }
        public DateTime? LastDonatedBreastMilk { get; set; }

        public DateTime DateBirth { get; set; }

    }
}
