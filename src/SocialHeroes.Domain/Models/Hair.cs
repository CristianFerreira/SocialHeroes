using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class Hair : IEntity
    {
        public Hair() { }
        public Hair(Guid id, string color, string type)
        {
            Id = id;
            Color = color;
            Type = type;
        }

        public Guid Id { get; private set; }
        public string Color { get; set; }
        public string Type { get; set; }


    }
}
