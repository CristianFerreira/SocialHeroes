using SocialHeroes.Shared.Models;
using System;

namespace SocialHeroes.Domain.DonatorContext.Models
{
    public class Hair : Entity
    {
        public Hair(string color)
        {
            this.Color = color;
        }

        public string Color { get; set; }
    }
}
