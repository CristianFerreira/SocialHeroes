using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class GetTokenAccountCommandValidation : AccountValidation<GetTokenAccountCommand>
    {
        public GetTokenAccountCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
