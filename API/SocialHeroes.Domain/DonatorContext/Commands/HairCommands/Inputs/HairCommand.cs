using FluentValidator;
using FluentValidator.Validation;
using SocialHeroes.Shared.Commands;

namespace SocialHeroes.Domain.DonatorContext.Commands.HairCommands.Inputs
{
    public class HairCommand : Notifiable, ICommand
    {
        public string Color { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                      .HasMinLen(Color, 3, "Color", "A cor deve ter pelo menos 3 caracteres")
                      .HasMaxLen(Color, 20, "Color", "A cor deve ter no máximo 20 caracteres")
            );
            return IsValid;
        }
    }
}
