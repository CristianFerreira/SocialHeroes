﻿using FluentValidation.Results;
using SocialHeroes.Domain.Core.Events;
using System;

namespace SocialHeroes.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
