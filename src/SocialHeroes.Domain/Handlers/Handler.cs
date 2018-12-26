using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class Handler
    {
        protected readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        protected readonly DomainNotificationHandler _notifications;

        public Handler(IUnitOfWork uow, 
                       IMediatorHandler bus, 
                       INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }     

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um problema ao salvar seus dados."));
            return false;
        }

        protected bool Commit(IDbContextTransaction transaction)
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit(transaction)) return true;

            _uow.Rollback(transaction);
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um problema ao salvar seus dados."));
            return false;
        }

        protected void RollBack(IDbContextTransaction transaction)
            => _uow.Rollback(transaction);

        protected async Task<ICommandResult> CompletedTask(IEntity data = null)
            => await Task.FromResult(new CommandResult(data));


        protected Task<ICommandResult> CanceledTask(Task task) 
            => Task.FromResult(null as ICommandResult);

        protected Task<ICommandResult> CanceledTask()
            => Task.FromResult(null as ICommandResult);

    }
}
