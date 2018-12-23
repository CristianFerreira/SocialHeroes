using SocialHeroes.Domain.Core.Commands;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class AddressAccountCommand : Command
    {
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
