using SocialHeroes.Domain.Core.Models;
using SocialHeroes.Domain.Core.Notifications;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(bool sucess, Entity data, List<DomainNotification> notifications = null)
        {
            Sucess = sucess;
            Data = data;
            Notifications = notifications;
        }

        public bool Sucess { get; set; }
        public Entity Data { get; set; }
        public List<DomainNotification> Notifications { get; private set; }
    }
}
