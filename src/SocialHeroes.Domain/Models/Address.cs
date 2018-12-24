using System;
using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Address : IEntity
    {
        public Address(Guid id,
                       Guid userId,
                       string number,
                       string complement,
                       string street,
                       string city,
                       string state,
                       string country,
                       string zipCode,
                       decimal latitude,
                       decimal longitude) 
        {
            Id = id;
            UserId = userId;
            Number = number;
            Complement = complement;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [JsonIgnore]
        public User User { get; private set; }
    }
}
