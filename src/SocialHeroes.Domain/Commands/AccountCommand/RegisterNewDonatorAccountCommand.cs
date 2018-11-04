using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class RegisterNewDonatorAccountCommand : DonatorAccountCommand
    {
        public RegisterNewDonatorAccountCommand(string name,
                                                DateTime dateBirth,
                                                EGenre genre,
                                                DateTime? lastDonation,
                                                string email,
                                                string password,
                                                string confirmPassword)
        {
            Name = name;
            DateBirth = dateBirth;
            Genre = genre;
            LastDonation = lastDonation;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

    }
}
