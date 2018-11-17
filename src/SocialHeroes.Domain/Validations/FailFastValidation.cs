using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Validations
{
    public class FailFastValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Command where TResponse : class
    {
        private readonly IValidator _validators;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public FailFastValidation(IValidator<TRequest> validators, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _validators = validators;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validatorResult = _validators.Validate(request);
            if (validatorResult.IsValid)
                return next();


       
            NotifyValidationErrors(validatorResult, request);
            return Task.FromResult(null as TResponse);
        }

        private void NotifyValidationErrors(ValidationResult result, TRequest request)
        {
            foreach (var error in result.Errors)
                _bus.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
            
        }

    }
}
