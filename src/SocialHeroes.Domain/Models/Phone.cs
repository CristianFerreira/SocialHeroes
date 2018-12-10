using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Phone : IEntity
    {
        public Guid Id { get; set; }
        public Guid HospitalUserId { get; set; }
        public string Number { get; set; }

        public HospitalUser HospitalUser { get; set; }
    }
}
