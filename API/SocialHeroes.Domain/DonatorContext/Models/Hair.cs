using System;

namespace SocialHeroes.Domain.DonatorContext.Models
{
    public class Hair
    {
        public Hair(string color)
        {
            this.Color = color;
        }

        public Guid Id { get; set; }
        public string Color { get; set; }
    }
}
