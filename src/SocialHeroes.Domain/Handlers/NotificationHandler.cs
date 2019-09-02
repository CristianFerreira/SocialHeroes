using MediatR;
using SocialHeroes.Domain.Commands.Notification;
using SocialHeroes.Domain.Commands.Notification.RequestCommand;
using SocialHeroes.Domain.Configurations;
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
        private readonly IInstitutionUserRepository _institutionUserRepository;
        private readonly IHairRepository _hairRepository;

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
                                  IInstitutionUserRepository institutionUserRepository,
                                  IHairRepository hairRepository) : base(uow, bus, notifications)
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
            _institutionUserRepository = institutionUserRepository;
            _hairRepository = hairRepository;
        }

        public Task<ICommandResult> Handle(NotifyDonatorUserCommand command,
                                           CancellationToken cancellationToken)
        {

            RegisterNotification(command.InstitutionUserId,
                                 command.EnableRequestOnPage,
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
            var institutionUser = _institutionUserRepository.Get(command.InstitutionUserId);
            var institutionUserAddress = institutionUser.User.Address;

            if(institutionUserAddress != null)
            {
                notifyDonatorUserEvent = new NotifyDonatorUserEvent(institutionUser.FantasyName,
                                                               institutionUserAddress.Street,
                                                               institutionUserAddress.Number,
                                                               institutionUserAddress.City,
                                                               institutionUserAddress.State,
                                                               institutionUserAddress.Country);
            }
            else notifyDonatorUserEvent = new NotifyDonatorUserEvent(institutionUser.FantasyName);
            
           
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
                Guid? hairId = null;
                if (command.HairNotifications.Any(x=>x.HairId == null))
                    hairId = _hairRepository.GetAll().FirstOrDefault().Id;

                foreach (var hairNotification in command.HairNotifications)
                    if(hairNotification.HairId == null)
                         hairNotification.HairId = hairId;

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

        #region Blood
        private void RegisterDonatorUserBloodNotifications(ICollection<BloodNotification> bloodNotifications,
                                                          NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            foreach (var bloodNotification in bloodNotifications)
            {
                var usersToBloodNotification = _donatorUserRepository.GetToBloodNotification(bloodNotification.BloodId, bloodNotification.AmountBlood);
                foreach (var userToNotification in usersToBloodNotification)
                {
                    var donatorUserBloodNotification = new DonatorUserBloodNotification(Guid.NewGuid(),
                                                                                        userToNotification.DonatorUserId,
                                                                                        bloodNotification.Id);

                    var donatorUserNotificationEvent = new DonatorUserNotificationEvent(userToNotification.Name,
                                                                                        userToNotification.Email,
                                                                                        NotificationsTypeConfiguration.TYPE_BLOOD,
                                                                                        userToNotification.Type);

                    notifyDonatorUserEvent.AddDonatorUserNotificationEvent(donatorUserNotificationEvent);

                    UpdateLastBloodNotificationDonatorUser(userToNotification.DonatorUserId);

                    _donatorUserBloodNotificationRepository.Add(donatorUserBloodNotification);
                }
            }
        }

        private void UpdateLastBloodNotificationDonatorUser(Guid donatorUserId)
        {
            var donatorUser = _donatorUserRepository.GetById(donatorUserId);
            donatorUser.AddLastBloodNotification();
            _donatorUserRepository.Update(donatorUser);
        }
        #endregion

        #region Hair
        private void RegisterDonatorUserHairNotifications(ICollection<HairNotification> hairNotifications,
                                                          NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            foreach (var hairNotification in hairNotifications)
            {
                var usersToHairNotification = _donatorUserRepository.GetToHairNotification(hairNotification.HairId, hairNotification.AmountHair);

                foreach (var userToNotification in usersToHairNotification)
                {
                    var donatorUserHairNotification = new DonatorUserHairNotification(Guid.NewGuid(),
                                                                                      userToNotification.DonatorUserId,
                                                                                      hairNotification.Id);

                    var donatorUserNotificationEvent = new DonatorUserNotificationEvent(userToNotification.Name,
                                                                                        userToNotification.Email,
                                                                                        NotificationsTypeConfiguration.TYPE_HAIR,
                                                                                        $"{userToNotification.Color} - {userToNotification.Type}");

                    notifyDonatorUserEvent.AddDonatorUserNotificationEvent(donatorUserNotificationEvent);

                    UpdateLastHairNotificationDonatorUser(userToNotification.DonatorUserId);

                    _donatorUserHairNotificationRepository.Add(donatorUserHairNotification);
                }
            }
        }

        private void UpdateLastHairNotificationDonatorUser(Guid donatorUserId)
        {
            var donatorUser = _donatorUserRepository.GetById(donatorUserId);
            donatorUser.AddLastHairNotification();
            _donatorUserRepository.Update(donatorUser);
        }

        #endregion

        #region BreastMilkNotification
        private void RegisterDonatorUserBreastMilkNotification(BreastMilkNotification breastMilkNotification,
                                                              NotifyDonatorUserEvent notifyDonatorUserEvent)
        {
            var usersToBreastMilkNotification = _donatorUserRepository.GetToBreastMilkNotification(breastMilkNotification.AmountBreastMilk);

            foreach (var userDonatorToNotify in usersToBreastMilkNotification)
            {
                var donatorUserBreastMilkNotification = new DonatorUserBreastMilkNotification(Guid.NewGuid(),
                                                                                              userDonatorToNotify.DonatorUserId,
                                                                                              breastMilkNotification.Id);

                notifyDonatorUserEvent.AddDonatorUserNotificationEvent(new DonatorUserNotificationEvent(userDonatorToNotify.Name,
                                                                                                        userDonatorToNotify.Email,
                                                                                                        NotificationsTypeConfiguration.TYPE_BREASTMILK));

                UpdateLastNotificationDonatorUser(userDonatorToNotify.DonatorUserId);

                _donatorUserBreastMilkNotificationRepository.Add(donatorUserBreastMilkNotification);
            }
        }

        private void UpdateLastNotificationDonatorUser(Guid donatorUserId)
        {
            var donatorUser = _donatorUserRepository.GetById(donatorUserId);
            donatorUser.AddLastBreastMilkNotification();
            _donatorUserRepository.Update(donatorUser);
        }
        #endregion

        #endregion

        #region Register Request Notifications

        private void RegisterBreastMilkNotification(Notification notification,
                                                    BreastMilkNotificationCommand command)
        {
            notification.SetBreastMilkNotification(new BreastMilkNotification(Guid.NewGuid(),
                                                                              notification.Id,
                                                                              command.Amount,
                                                                              command.ShareOnFacebook,
                                                                              command.ShareOnLinkedin,
                                                                              command.ShareOnTwitter));
            _breastMilkNotificationRepository.Add(notification.BreastMilkNotification);
        }

        private void RegisterHairNotifications(Notification notification,
                                               ICollection<HairNotificationCommand> commands)
        {
            foreach (var command in commands)
            {
                var hairNotification = new HairNotification(Guid.NewGuid(),
                                                            notification.Id,
                                                            command.HairId ?? Guid.NewGuid(),
                                                            command.Amount,
                                                            command.ShareOnFacebook,
                                                            command.ShareOnLinkedin,
                                                            command.ShareOnTwitter);
                _hairNotificationRepository.Add(hairNotification);
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
                                                              command.Amount,
                                                              command.ShareOnFacebook,
                                                              command.ShareOnLinkedin,
                                                              command.ShareOnTwitter);
                _bloodNotificationRepository.Add(bloodNotification);
            }
        }

        private void RegisterNotification(Guid institutionUserId, bool enableRequestOnPage, out Notification notification)
        {
            notification = new Notification(Guid.NewGuid(), institutionUserId, enableRequestOnPage);
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
