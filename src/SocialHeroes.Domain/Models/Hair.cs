using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class Hair : IEntity
    {
        public Hair(Guid id, string color)
        {
            Id = id;
            Color = color;
        }

        public string Color { get; private set; }
        public Guid Id { get; private set;}
    }
}
