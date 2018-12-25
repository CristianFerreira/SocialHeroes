using FluentValidation;
using FluentValidation.Results;
using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            if (context.InstanceToValidate == null)
                return new ValidationResult(new[] { new ValidationFailure("Account", "Por favor informe os dados da conta do usuario!") });

           return base.Validate(context);
        }

        protected void ValidateEmail()
        => RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira um valor para o e-mail")
                .EmailAddress().WithMessage("Por favor informe um e-mail valido!")
                .MaximumLength(256).WithMessage("O E-mail deve ter no máximo 256 caracteres");


        protected void ValidatePasswordEqualsConfirmPassword()
        => RuleFor(c => c.Password)
                .Equal(c => c.ConfirmPassword).WithMessage("A senha e a confirmação de senha devem ter o mesmo valor");


        protected void ValidatePassword()
        => RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor insira um valor para a senha")
                .Length(6, 12).WithMessage("A senha deve ter entre 6 e 12 caracteres");


        protected void ValidateCity()
        => RuleFor(c => c.Address.City)
           .NotEmpty().WithMessage("Por favor insira uma cidade")
           .Length(1, 100).WithMessage("A cidade deve ter entre 1 e 100 caracteres");


        protected void ValidateComplement()
        => RuleFor(c => c.Address.Complement)
             .MaximumLength(100).WithMessage("A complemento deve ter no máximo 100 caracteres");

        protected void ValidateCountry()
        => RuleFor(c => c.Address.Country)
              .NotEmpty().WithMessage("Por favor insira um País")
              .Length(1, 100).WithMessage("O país deve ter entre 1 e 100 caracteres");

        protected void ValidateStreet()
        => RuleFor(c => c.Address.Street)
              .NotEmpty().WithMessage("Por favor insira um endereço")
             .Length(1, 100).WithMessage("O endereço deve ter entre 1 e 100 caracteres");

        protected void ValidateAddressNumber()
         => RuleFor(c => c.Address.Number)
              .NotEmpty().WithMessage("Por favor insira um numero de endereço")
              .Length(1, 20).WithMessage("O numero de endereço deve ter entre 1 e 100 caracteres");

        protected void ValidateZipCode()
         => RuleFor(c => c.Address.ZipCode)
              .NotEmpty().WithMessage("Por favor insira um CEP")
              .Length(9).WithMessage("O CEP deve ter 9 caracteres");

        protected void ValidateState()
        => RuleFor(c => c.Address.State)
              .NotEmpty().WithMessage("Por favor insira um estado")
              .Length(1, 100).WithMessage("O estado deve ter entre 1 e 100 caracteres");

        protected void ValidateLatitude()
        => RuleFor(c => c.Address.Latitude)
             .NotEmpty().WithMessage("Por favor insira a latitude");

        protected void ValidateLongitude()
        => RuleFor(c => c.Address.Longitude)
             .NotEmpty().WithMessage("Por favor insira a longitude");

        protected void ValidateUserNotificationType()
        => RuleForEach(c => c.UserNotificationTypes).SetValidator(new UserNotificationTypeValidation());

        protected void ValidatePhone()
        => RuleForEach(c => c.Phones).SetValidator(new PhoneValidation());
    }
}
