using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(bool sucess, IEntity data, List<DomainNotification> notifications = null)
        {
            Sucess = sucess;
            Data = data;
            Notifications = notifications;
        }

        public bool Sucess { get; set; }
        public IEntity Data { get; set; }
        public List<DomainNotification> Notifications { get; private set; }
    }
}
