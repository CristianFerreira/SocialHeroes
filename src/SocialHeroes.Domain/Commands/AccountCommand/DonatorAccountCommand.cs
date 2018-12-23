using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class DonatorAccountCommand : UserCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CellPhone { get; set; }
        public EGenre Genre { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime? LastDonation { get; set; }
        public Guid UserId { get; set; }
    }
}
