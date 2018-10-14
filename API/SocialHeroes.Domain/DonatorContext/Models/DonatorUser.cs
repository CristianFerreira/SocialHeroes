using FluentValidator;
using System;

namespace SocialHeroes.Domain.DonatorContext.Models
{
    public class DonatorUser :Notifiable
    {
        public DonatorUser(string firstName, string lastName, string CPF)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CPF = CPF;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }

    }
}
