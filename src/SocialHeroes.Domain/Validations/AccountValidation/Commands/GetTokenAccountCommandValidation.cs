using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class GetTokenAccountCommandValidation : UserValidation<TokenUserCommand>
    {
        public GetTokenAccountCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
