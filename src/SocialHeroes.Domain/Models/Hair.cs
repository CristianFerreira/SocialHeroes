using SocialHeroes.Domain.Core.Models;
using System;

namespace SocialHeroes.Domain.Models
{
    public class Hair : Entity
    {
        //public Hair(){}
        public Hair(Guid id, string color)
        {
            Id = id;
            Color = color;
        }

        public string Color { get; set; }
    }
}
