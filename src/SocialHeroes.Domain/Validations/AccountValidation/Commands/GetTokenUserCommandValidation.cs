using SocialHeroes.Domain.Commands.Account.RequestCommand;

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
