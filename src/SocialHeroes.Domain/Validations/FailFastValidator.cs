using FluentValidation;
using MediatR;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace SocialHeroes.Domain.Validations
{
    public class FailFastValidator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Command where TResponse : CommandResult
    {
        private readonly IValidator _validators;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public FailFastValidator(IValidator<TRequest> validators, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _validators = validators;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validatorResult = _validators.Validate(request);
            var x = validatorResult.IsValid;
            return !validatorResult.IsValid
                ? NotifyValidationErrors(validatorResult, request)
                : next();
        }


        private Task<TResponse> NotifyValidationErrors(ValidationResult result, TRequest request)
        {
            foreach (var error in result.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return Task.FromResult(new CommandResult(false, null, _notifications.GetNotifications()) as TResponse);
        }

    }
}
