using FluentValidator;
using SocialHeroes.Domain.DonatorContext.Commands.HairCommands.Inputs;
using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Repositories;
using SocialHeroes.Shared.Commands;

namespace SocialHeroes.Domain.DonatorContext.Handlers.HairHandlers
{
    public class HairHandler : Notifiable, ICommandHander<HairCommandRequest>
    {
        private readonly IHairRepository _repository;
        public HairHandler(IHairRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(HairCommandRequest command)
        {      
            var hair = new Hair(command.Color);

            AddNotifications(hair.Notifications);

            if (Invalid)
                return null;

            _repository.Save(hair);

            return new HairCommandResult(new System.Guid(), hair.Color);
        }
    }
}
