using System;

namespace SocialHeroes.Domain.Commands.Account
{
    public class HospitalUserCommand : UserCommand
    {
        public Guid Id { get; set; }
        public string SocialReason { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public bool Actived { get; set; }
        public Guid UserId { get; set; }
    }
}
