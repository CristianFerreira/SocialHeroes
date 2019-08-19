using SocialHeroes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Account.RequestCommand
{
    public class RegisterNewDonatorUserCommand : DonatorUserCommand
    {

        public RegisterNewDonatorUserCommand(string name,
                                              EGenre genre,
                                              string email,
                                              string password,
                                              string confirmPassword,
                                              bool activedBloodNotification,
                                              bool activedHairNotification,
                                              bool activedBreastMilkNotification,
                                              Guid? hairId = null,
                                              Guid? bloodId = null)
        {
            Name = name;
            Genre = genre;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            ActivedBloodNotification = activedBloodNotification;
            ActivedHairNotification = activedHairNotification;
            ActivedBreastMilkNotification = activedBreastMilkNotification;
            HairId = hairId;
            BloodId = bloodId;



        }

    }
}
