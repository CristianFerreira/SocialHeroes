namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class RegisterNewHospitalAccountCommand : HospitalAccountCommand
    {
        public RegisterNewHospitalAccountCommand(string socialReason, 
                                                 string fantasyName, 
                                                 string cnpj,
                                                 string email,
                                                 string password)
        {
            SocialReason = socialReason;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Email = email;
            Password = password;

        }   
    }
}
