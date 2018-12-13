using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class NotificationType : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
