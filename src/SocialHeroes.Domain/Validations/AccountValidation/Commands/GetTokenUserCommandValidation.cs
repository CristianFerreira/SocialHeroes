using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class GetTokenUserCommandValidation : UserValidation<TokenUserCommand>
    {
        public GetTokenUserCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
