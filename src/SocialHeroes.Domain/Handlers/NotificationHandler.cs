﻿using MediatR;
using SocialHeroes.Domain.Commands.Notification;
using SocialHeroes.Domain.Commands.Notification.RequestCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Events.NotificationEvent;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class NotificationHandler : Handler,
                 IRequestHandler<NotifyDonatorUserCommand, ICommandResult>
    {
        private readonly IMediatorHandler _bus;
        private readonly INotificationRepository _notificationRepository;
        private readonly IBloodNotificationRepository _bloodNotificationRepository;
        private readonly IHairNotificationRepository _hairNotificationRepository;
        private readonly IBreastMilkNotificationRepository _breastMilkNotificationRepository;
        private readonly IDonatorUserBloodNotificationRepository _donatorUserBloodNotificationRepository;
        private readonly IDonatorUserHairNotificationRepository _donatorUserHairNotificationRepository;
        private readonly IDonatorUserBreastMilkNotificationRepository _donatorUserBreastMilkNotificationRepository;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IHospitalUserRepository _hospitalUserRepository;

        public NotificationHandler(IUnitOfWork uow,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications,
                                  INotificationRepository notificationRepository,
                                  IBloodNotificationRepository bloodNotificationRepository,
                                  IHairNotificationRepository hairNotificationRepository,
                                  IBreastMilkNotificationRepository breastMilkNotificationRepository,
                                  IDonatorUserBloodNotificationRepository donatorUserBloodNotificationRepository,
                                  IDonatorUserHairNotificationRepository donatorUserHairNotificationRepository,
                                  IDonatorUserBreastMilkNotificationRepository donatorUserBreastMilkNotificationRepository,
                                  IDonatorUserRepository donatorUserRepository,
                                  IHospitalUserRepository hospitalUserRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _notificationRepository = notificationRepository;
            _bloodNotificationRepository = bloodNotificationRepository;
            _hairNotificationRepository = hairNotificationRepository;
            _breastMilkNotificationRepository = breastMilkNotificationRepository;
            _donatorUserBloodNotificationRepository = donatorUserBloodNotificationRepository;
            _donatorUserHairNotificationRepository = donatorUserHairNotificationRepository;
            _donatorUserBreastMilkNotificationRepository = donatorUserBreastMilkNotificationRepository;
            _donatorUserRepository = donatorUserRepository;
            _hospitalUserRepository = hospitalUserRepository;
        }

        public Task<ICommandResult> Handle(NotifyDonatorUserCommand command,
                                           CancellationToken cancellationToken)
        {

            RegisterNotification(command.HospitalUserId,
                                 out Notification notification);

            CreateInstanceToNotifyDonatorUserEvent(command,
                                                   out NotifyDonatorUserEvent notifyDonatorUserEvent);

            AddBloodNotifications(command,
                                  notification,
                                  notifyDonatorUserEvent);

            AddHairNotifications(command,
                                 notification,
                                 notifyDonatorUserEvent);

            AddBreastMilkNotifications(command,
                                       notification,
                                       notifyDonatorUserEvent);

            if (Commit())
                _bus.RaiseEvent(notifyDonatorUserEvent);

            return CompletedTask();
        }

        private NotifyDonatorUserEvent CreateInstanceToNotifyDonatorUserEvent(NotifyDonatorUserCommand command,
                                                                              out NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            var hospitalUser = _hospitalUserRepository.Get(command.HospitalUserId);
            var hospitalUserAddress = hospitalUser.User.Address;

            notifyDonatorUserEvent = new NotifyDonatorUserEvent(hospitalUser.FantasyName,
                                                                hospitalUserAddress.Street,
                                                                hospitalUserAddress.Number,
                                                                hospitalUserAddress.City,
                                                                hospitalUserAddress.State,
                                                                hospitalUserAddress.Country);
            return notifyDonatorUserEvent;
        }

        #region Add Notifications
        private void AddBreastMilkNotifications(NotifyDonatorUserCommand command,
                                                Notification notification,
                                                NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            if (HasBreastMilkNotification(command.BreastMilkNotification))
            {
                RegisterBreastMilkNotification(notification,
                                               command.BreastMilkNotification);

                RegisterDonatorUserBreastMilkNotification(notification.BreastMilkNotification,
                                                          notifyDonatorUserEvent);
            }
        }

        private void AddHairNotifications(NotifyDonatorUserCommand command,
                                         Notification notification,
                                         NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            if (HasHairNotifications(command.HairNotifications))
            {
                RegisterHairNotifications(notification,
                                      command.HairNotifications);

                RegisterDonatorUserHairNotifications(notification.HairNotifications,
                                                     notifyDonatorUserEvent);
            }
        }

        private void AddBloodNotifications(NotifyDonatorUserCommand command,
                                           Notification notification,
                                           NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            if (HasBloodNotifications(command.BloodNotifications))
            {
                RegisterBloodNotifications(notification,
                                           command.BloodNotifications);

                RegisterDonatorUserBloodNotifications(notification.BloodNotifications,
                                                      notifyDonatorUserEvent);
            }
        }
        #endregion

        #region Register Donator User Notifications
        private void RegisterDonatorUserBloodNotifications(ICollection<BloodNotification> bloodNotifications,
                                                           NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            foreach (var bloodNotification in bloodNotifications)
            {
                var donatorUsers = _donatorUserRepository.GetToBloodNotification(bloodNotification.BloodId);
                foreach (var donatorUser in donatorUsers)
                {
                    var donatorUserBloodNotification = new DonatorUserBloodNotification(Guid.NewGuid(),
                                                                                        donatorUser.Id,
                                                                                        bloodNotification.Id);
                    var donatorUserNotificationEvent = new DonatorUserNotificationEvent(donatorUser.Name, donatorUser.User.Email, donatorUser.Blood.Type);

                    //notifyDonatorUserEvent.AddDonatorUserNotificationEvent();

                    _donatorUserBloodNotificationRepository.Add(donatorUserBloodNotification);
                }
            }
        }

        private void RegisterDonatorUserHairNotifications(ICollection<HairNotification> hairNotifications,
                                                          NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            foreach (var hairNotification in hairNotifications)
            {
                //Get user list 

                var donatorUserHairNotification = new DonatorUserHairNotification(Guid.NewGuid(),
                                                                                  Guid.NewGuid(),
                                                                                  hairNotification.Id);

                _donatorUserHairNotificationRepository.Add(donatorUserHairNotification);
            }
        }

        private void RegisterDonatorUserBreastMilkNotification(BreastMilkNotification breastMilkNotification,
                                                               NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            var usersToBreastMilkNotification = _donatorUserRepository.GetToBreastMilkNotification(breastMilkNotification.AmountBreastMilk);

            foreach (var userDonator in usersToBreastMilkNotification)
            {
                var donatorUserBreastMilkNotification = new DonatorUserBreastMilkNotification(Guid.NewGuid(),
                                                                                              userDonator.Id,
                                                                                              breastMilkNotification.Id);

                notifyDonatorUserEvent.AddDonatorUserNotificationEvent(new DonatorUserNotificationEvent(userDonator.Name,
                                                                                                        userDonator.User.Email, 
                                                                                                        "Leite Materno"));

                _donatorUserBreastMilkNotificationRepository.Add(donatorUserBreastMilkNotification);
            }
        }
        #endregion

        #region Register Request Notifications
        private void RegisterBreastMilkNotification(Notification notification,
                                                    BreastMilkNotificationCommand command)
        {
            notification.SetBreastMilkNotification(new BreastMilkNotification(Guid.NewGuid(),
                                                                              notification.Id,
                                                                              command.Amount));
            _breastMilkNotificationRepository.Add(notification.BreastMilkNotification);
        }

        private void RegisterHairNotifications(Notification notification,
                                               ICollection<HairNotificationCommand> commands)
        {
            foreach (var command in commands)
            {
                var hairNotification = new HairNotification(Guid.NewGuid(),
                                                            notification.Id,
                                                            command.HairId,
                                                            command.Amount);
                _hairNotificationRepository.Add(hairNotification);

                notification.HairNotifications.Add(hairNotification);
            }
        }

        private void RegisterBloodNotifications(Notification notification,
                                                ICollection<BloodNotificationCommand> commands)
        {
            foreach (var command in commands)
            {
                var bloodNotification = new BloodNotification(Guid.NewGuid(),
                                                              notification.Id,
                                                              command.BloodId,
                                                              command.Amount);
                _bloodNotificationRepository.Add(bloodNotification);

                notification.BloodNotifications.Add(bloodNotification);
            }
        }

        private void RegisterNotification(Guid hospitalUserId, out Notification notification)
        {
            notification = new Notification(Guid.NewGuid(), hospitalUserId);
            _notificationRepository.Add(notification);
        }
        #endregion

        #region Verify if exist notifications!
        private bool HasBloodNotifications(ICollection<BloodNotificationCommand> bloodNotifications)
           => bloodNotifications != null && bloodNotifications.Count > 0;

        private bool HasHairNotifications(ICollection<HairNotificationCommand> hairNotifications)
           => hairNotifications != null && hairNotifications.Count > 0;

        private bool HasBreastMilkNotification(BreastMilkNotificationCommand breastMilkNotification)
            => breastMilkNotification != null;
        #endregion

    }
}
