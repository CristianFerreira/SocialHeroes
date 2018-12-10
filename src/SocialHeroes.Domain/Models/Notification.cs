using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Notification : IEntity
    {
        public Guid Id { get; set; }
        public Guid HospitalUserId { get; set; }
        public DateTime DateNotification { get; set; }
    }
}
