using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class GetTokenAccountCommandValidation : AccountValidation<TokenAccountCommand>
    {
        public GetTokenAccountCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
