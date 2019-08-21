using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Commands.Account;
using SocialHeroes.Domain.Commands.Account.RequestCommand;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class AccountHandler : Handler,
                                  IRequestHandler<RegisterNewDonatorUserCommand, ICommandResult>,
                                  IRequestHandler<RegisterNewInstitutionUserCommand, ICommandResult>,
                                  IRequestHandler<TokenUserCommand, ICommandResult>
    {
        private readonly IMediatorHandler _bus;
        private readonly ITokenService _tokenService;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IInstitutionUserRepository _institutionUserRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserNotificationTypeRepository _userNotificationTypeRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        public AccountHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IDonatorUserRepository donatorUserRepository,
                              IInstitutionUserRepository institutionUserRepository,
                              IAddressRepository addressRepository,
                              IUserNotificationTypeRepository userNotificationTypeRepository,
                              INotificationTypeRepository notificationTypeRepository,
                              IPhoneRepository phoneRepository,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager)
                              : base(uow, bus, notifications)
        {
            _bus = bus;
            _tokenService = tokenService;
            _donatorUserRepository = donatorUserRepository;
            _institutionUserRepository = institutionUserRepository;
            _addressRepository = addressRepository;
            _userNotificationTypeRepository = userNotificationTypeRepository;
            _phoneRepository = phoneRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _notificationTypeRepository = notificationTypeRepository;
        }

        public async Task<ICommandResult> Handle(RegisterNewDonatorUserCommand command, 
                                                 CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (!RegisterUser(command.Email, 
                                      command.Password,
                                      EUserType.Donator, out User user, out IdentityResult resultUser))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         "E-mail já está cadastrado!")));

                    if(!RegisterRole(user, RolesConfiguration.ROLE_DONATOR, out IdentityResult resultRole))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         $"Ocorreu erro ao atribuir uma Role \n: {resultRole.Errors.ToList()[0].Description}")));

                    RegisterUserDonatorNotificationTypes(command, user);

                    RegisterDonatorUser(command, user, out DonatorUser donatorUser);

                    Commit(transaction);
                    return await CompletedTask(donatorUser);
                }
                catch (Exception exception)
                {
                    RollBack(transaction);
                    throw exception;
                }
            }
        }


        public async Task<ICommandResult> Handle(RegisterNewInstitutionUserCommand command, 
                                                 CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (!RegisterUser(command.Email, 
                                      command.Password, 
                                      EUserType.Hospital, out User user, out IdentityResult resultUser))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         "E-mail já está cadastrado!")));

                    if (!RegisterRole(user, RolesConfiguration.ROLE_INSTITUTION, out IdentityResult resultRole))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         $"Ocorreu erro ao atribuir uma Role \n: {resultRole.Errors.ToList()[0].Description}")));

                    RegisterAddress(command.Address, user);

                    RegisterInstitutionUser(command, user, out InstitutionUser institutionUser);

                    RegisterPhones(command.Phones, institutionUser);

                    RegisterUserInstitutionNotificationTypes(command.UserNotificationTypes, user);

                    Commit(transaction);
                        //await _bus.RaiseEvent(new HospitalAccountRegisteredEvent());

                    return await CompletedTask(institutionUser);
                }
                catch (Exception exception)
                {
                    RollBack(transaction);
                    throw exception;
                }
            }
        }

        private void RegisterPhones(ICollection<PhoneCommand> phones, InstitutionUser institutionUser)
        {
            if (phones == null)
                return;

            foreach (var phone in phones)
              _phoneRepository.Add(new Phone(Guid.NewGuid(), institutionUser.Id, phone.Number));
            
        }

        public Task<ICommandResult> Handle(TokenUserCommand command, 
                                           CancellationToken cancellationToken)
        {
            var user = _userManager.FindByNameAsync(command.Email).Result;

            if (user == null)
                return CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                           "O usuário informado não está cadastrado.")));

            var resultSignIn = _signInManager
                                .CheckPasswordSignInAsync(user, command.Password, false)
                                     .Result.Succeeded;

            if (!resultSignIn)
                return CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                           "Senha inválida.")));

            var roles = _userManager.GetRolesAsync(user).Result;
            return CompletedTask((_tokenService.CreateToken(user, 
                                                            roles, 
                                                            UserName(user))));
        }



        #region private methods
        private void RegisterAddress(AddressCommand command, 
                                     User user)
        {
            var address = new Address(Guid.NewGuid(),
                                      user.Id,
                                      command.Number,
                                      command.Complement,
                                      command.Street,
                                      command.City,
                                      command.District,
                                      command.State,
                                      command.Country,
                                      command.ZipCode,
                                      command.Latitude,
                                      command.Longitude);
            _addressRepository.Add(address);
        }

        private void RegisterInstitutionUser(RegisterNewInstitutionUserCommand command,
                                             User user,
                                             out InstitutionUser institutionUser)
        {
            institutionUser = new InstitutionUser(Guid.NewGuid(),
                                                  user.Id,
                                                  command.SocialReason,
                                                  command.FantasyName,
                                                  command.CNPJ);

            _institutionUserRepository.Add(institutionUser);
        }

        private bool RegisterUser(string email, 
                                  string password, 
                                  EUserType userType, 
                                  out User user, 
                                  out IdentityResult resultUser)
        {
            user = new User(Guid.NewGuid(), userType, email);
            resultUser = _userManager.CreateAsync(user, password).Result;
            return resultUser.Succeeded;
        }

        private bool RegisterRole(User user,    
                                  string role, 
                                  out IdentityResult resultRole)
        {
            resultRole = _userManager.AddToRoleAsync(user, role).Result;
            return resultRole.Succeeded;
        }

        private void RegisterUserDonatorNotificationTypes(RegisterNewDonatorUserCommand command,
                                                          User user)
        {
            var notificationsTypes = new List<NotificationType>();
            if (command.ActivedBloodNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.Blood));
            if(command.ActivedHairNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.Hair));
            if(command.ActivedBreastMilkNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.BreastMilk));

            foreach (var notificationType in notificationsTypes)
                _userNotificationTypeRepository.Add(new UserNotificationType(Guid.NewGuid(),
                                                                             notificationType.Id,
                                                                             user.Id));
        }

        private void RegisterInstitutionNotificationTypes(RegisterNewDonatorUserCommand command,
                                                          User user)
        {
            var notificationsTypes = new List<NotificationType>();
            if (command.ActivedBloodNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.Blood));
            if (command.ActivedHairNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.Hair));
            if (command.ActivedBreastMilkNotification) notificationsTypes.Add(_notificationTypeRepository.GetByName(NotificationTypeConfiguration.BreastMilk));

            foreach (var notificationType in notificationsTypes)
                _userNotificationTypeRepository.Add(new UserNotificationType(Guid.NewGuid(),
                                                                             notificationType.Id,
                                                                             user.Id));
        }

        private void RegisterUserInstitutionNotificationTypes(ICollection<UserNotificationTypeCommand> userNotificationTypes,
                                                               User user)
        {
            foreach (var userNotificationType in userNotificationTypes)
                _userNotificationTypeRepository.Add(new UserNotificationType(Guid.NewGuid(),
                                                                             userNotificationType.NotificationTypeId,
                                                                             user.Id));
        }

        private void RegisterDonatorUser(RegisterNewDonatorUserCommand command, 
                                         User user, 
                                         out DonatorUser donatorUser)
        {
            donatorUser = new DonatorUser(Guid.NewGuid(),
                                          user.Id,
                                          command.Name,
                                          command.Genre,
                                          command.ActivedBloodNotification,
                                          command.ActivedHairNotification,
                                          command.ActivedBreastMilkNotification,
                                          command.HairId,
                                          command.BloodId);

            _donatorUserRepository.Add(donatorUser);
        }

        private string UserName(User user)
        {
            switch (user.UserType)
            {
                case EUserType.Donator:
                    return _donatorUserRepository.GetByUserId(user.Id).Name;
                case EUserType.Hospital:
                    return _institutionUserRepository.GetByUserId(user.Id).FantasyName;
                default:
                    return user.UserName;
            }
        }
        #endregion

        public void Dispose()
        {
            _donatorUserRepository.Dispose();
        }

        
    }
}
