using SocialHeroes.Domain.Commands.Account.RequestCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class UpdateDonatorUserCommandValidation : DonatorUserValidation<UpdateDonatorUserCommand>
    {
        public UpdateDonatorUserCommandValidation()
        {
            ValidateId();
        }
    }
}
