using System;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class HospitalAccountCommand : AccountCommand
    {
        public Guid Id { get; set; }
        public string SocialReason { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public bool Actived { get; set; }
        public Guid UserId { get; set; }
    }
}
