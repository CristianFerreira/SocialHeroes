using MediatR;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Core.Events
{
    public abstract class Message : IRequest<ICommandResult>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
