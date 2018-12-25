using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Phone : IEntity
    {
        public Phone(Guid id, 
                     Guid hospitalUserId, 
                     string number)
        {
            Id = id;
            HospitalUserId = hospitalUserId;
            Number = number;
        }

        public Guid Id { get; private set; }
        public Guid HospitalUserId { get; private set; }
        public string Number { get; private set; }

        public HospitalUser HospitalUser { get; private set; }
    }
}
