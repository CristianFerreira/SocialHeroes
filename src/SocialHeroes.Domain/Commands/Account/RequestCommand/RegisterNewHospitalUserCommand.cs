using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Account.RequestCommand
{
    public class RegisterNewInstitutionUserCommand : InstitutionUserCommand
    {
        public RegisterNewInstitutionUserCommand(string socialReason, 
                                                 string fantasyName, 
                                                 string cnpj,
                                                 string email,
                                                 string password,
                                                 string confirmPassword,
                                                 AddressCommand address,
                                                 ICollection<UserNotificationTypeCommand> userNotificationTypes,
                                                 ICollection<PhoneCommand> phones)
        {
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Address = address;
            UserNotificationTypes = userNotificationTypes;
            Phones = phones;
        }   
    }
}
