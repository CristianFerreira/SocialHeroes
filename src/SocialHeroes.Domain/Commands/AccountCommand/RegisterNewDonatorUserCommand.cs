using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class RegisterNewDonatorUserCommand : DonatorUserCommand
    {

        public RegisterNewDonatorUserCommand(string name,
                                                DateTime dateBirth,
                                                EGenre genre,
                                                DateTime? lastDonation,
                                                string email,
                                                string password,
                                                string confirmPassword,
                                                ICollection<UserNotificationTypeCommand> userNotificationTypes)
        {
            Name = name;
            DateBirth = dateBirth;
            Genre = genre;
            LastDonation = lastDonation;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserNotificationTypes = userNotificationTypes;  
        }

    }
}
