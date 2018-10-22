using MediatR;
using SocialHeroes.Domain.Core.Events;
using System;

namespace SocialHeroes.Domain.Events
{
    public class HairRegisteredEvent : Event
    {
        public HairRegisteredEvent(Guid id, string color)
        {
            Id = id;
            Color = color;
            AggregateId = id;
        }

        public Guid Id { get; private set; }
        public string Color { get; private set; }
    }
}
