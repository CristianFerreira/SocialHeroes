using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class GetTokenAccountCommandValidation : UserAccountValidation<GetTokenAccountCommand>
    {
        public GetTokenAccountCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
