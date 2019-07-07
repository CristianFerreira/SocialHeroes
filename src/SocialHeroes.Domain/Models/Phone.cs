using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Phone : IEntity
    {
        public Phone(Guid id, 
                     Guid institutionUserId, 
                     string number)
        {
            Id = id;
            InstitutionUserId = institutionUserId;
            Number = number;
        }

        public Guid Id { get; private set; }
        public Guid InstitutionUserId { get; private set; }
        public string Number { get; private set; }

        public InstitutionUser InstitutionUser { get; private set; }
    }
}
