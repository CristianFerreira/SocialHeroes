using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class RegisterNewHospitalAccountCommand : HospitalAccountCommand
    {
        public RegisterNewHospitalAccountCommand(string socialReason, 
                                                 string fantasyName, 
                                                 string cnpj,
                                                 string email,
                                                 string password,
                                                 string confirmPassword,
                                                 AddressAccountCommand address,
                                                 ICollection<UserNotificationTypeCommand> userNotificationTypes)
        {
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Address = address;
            UserNotificationTypes = userNotificationTypes;
        }   
    }
}
