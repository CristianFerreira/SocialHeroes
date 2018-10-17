using FluentValidator;
using SocialHeroes.Domain.Commands.HairCommands.Outputs;
using SocialHeroes.Domain.DonatorContext.Commands.HairCommands.Inputs;
using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Repositories;
using SocialHeroes.Shared.Commands;

namespace SocialHeroes.Domain.DonatorContext.Handlers.HairHandlers
{
    public class HairHandler : Notifiable, ICommandHander<RegisterNewHairCommand>
    {
        private readonly IHairRepository _repository;
        public HairHandler(IHairRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterNewHairCommand command)
        {             

            if (!command.Valid())
                return new CommandResult(
                    false, 
                    "Por favor corrija os campos abaixo", 
                    new { command.Notifications });

            var hair = new Hair(command.Color);

            _repository.Save(hair);

            return new CommandResult(true, "" , new { Hair = hair });
        }
    }
}
