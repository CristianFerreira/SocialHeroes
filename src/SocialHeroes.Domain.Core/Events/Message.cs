using MediatR;
using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Core.Events
{
    public abstract class Message : IRequest<CommandResult>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {

            MessageType = GetType().Name;
        }
    }
}
