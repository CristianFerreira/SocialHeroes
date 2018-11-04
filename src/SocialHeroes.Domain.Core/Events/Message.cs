using MediatR;
using SocialHeroes.Domain.Core.Commands;

namespace SocialHeroes.Domain.Core.Events
{
    public abstract class Message : IRequest<CommandResult>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
