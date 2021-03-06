﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Commands.Account;
using SocialHeroes.Domain.Commands.Account.RequestCommand;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Events.AccountEvent;
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
                                  IRequestHandler<UpdateDonatorUserCommand, ICommandResult>,
                                  IRequestHandler<TokenUserCommand, ICommandResult>,
                                  IRequestHandler<ActiveUserCommand, ICommandResult>
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
        private readonly IUserRepository _userRepository;
        private readonly IUserSocialNotificationTypeRepository _userSocialNotificationTypeRepository;
        private readonly ISocialNotificationTypeRepository _socialNotificationTypeRepository;

        public AccountHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IDonatorUserRepository donatorUserRepository,
                              IInstitutionUserRepository institutionUserRepository,
                              IAddressRepository addressRepository,
                              IUserNotificationTypeRepository userNotificationTypeRepository,
                              IUserSocialNotificationTypeRepository userSocialNotificationTypeRepository,
                              ISocialNotificationTypeRepository socialNotificationTypeRepository,
                              INotificationTypeRepository notificationTypeRepository,
                              IPhoneRepository phoneRepository,
                              IUserRepository userRepository,
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
            _userSocialNotificationTypeRepository = userSocialNotificationTypeRepository;
            _socialNotificationTypeRepository = socialNotificationTypeRepository;
            _phoneRepository = phoneRepository;
            _userRepository = userRepository;
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

                    RegisterUserSocialNotificationTypes(user);

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
                                      EUserType.Institution, out User user, out IdentityResult resultUser))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         "E-mail já está cadastrado!")));

                    if (!RegisterRole(user, RolesConfiguration.ROLE_INSTITUTION, out IdentityResult resultRole))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         $"Ocorreu erro ao atribuir uma Role \n: {resultRole.Errors.ToList()[0].Description}")));

                    RegisterAddress(command.Address, user);

                    RegisterInstitutionUser(command, user, out InstitutionUser institutionUser);

                    RegisterPhones(command.Phones, institutionUser);

                    RegisterUserInstitutionNotificationTypes(command.UserNotificationTypes, user);

                    if(Commit(transaction))
                        await _bus.RaiseEvent(new PendingUserAccountEvent(user.Email));

                    return await CompletedTask(institutionUser);
                }
                catch (Exception exception)
                {
                    RollBack(transaction);
                    throw exception;
                }
            }
        }


        public async Task<ICommandResult> Handle(UpdateDonatorUserCommand command, CancellationToken cancellationToken)
        {
            var donatorUser = _donatorUserRepository.GetById(command.Id);
            donatorUser.AddCellPhone(command.CellPhone);

            _donatorUserRepository.Update(donatorUser);

            DeleteUserSocialNotificationTypes(donatorUser.UserId);
            AddUserSocialNotificationTypes(donatorUser.UserId, command.SocialNotificationTypesId);

            Commit();

            return await CompletedTask(donatorUser);
        }

        private void AddUserSocialNotificationTypes(Guid userId, IList<Guid> socialNotificationTypesId)
        {
            foreach (var socialNotificationTypeId in socialNotificationTypesId)
            {
                _userSocialNotificationTypeRepository.Add(new UserSocialNotificationType(Guid.NewGuid(), socialNotificationTypeId, userId));
            }
        }

        private void DeleteUserSocialNotificationTypes(Guid userId)
        {
            var userSocialNotificationTypes = _userSocialNotificationTypeRepository.GetUserSocialNotificationTypeByUserId(userId);
            foreach (var userSocialNotificationType in userSocialNotificationTypes)
            {
                _userSocialNotificationTypeRepository.Remove(userSocialNotificationType.Id);
            }
        }

        public Task<ICommandResult> Handle(TokenUserCommand command, 
                                           CancellationToken cancellationToken)
        {
            var user = _userManager.FindByNameAsync(command.Email).Result;

            if (user == null)
                return CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                           "O usuário informado não está cadastrado.")));

            if(user.UserStatus.Equals(EUserStatus.Pending))
                return CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                           "A conta encontra-se pendente, aguarde a ativação da sua conta!")));

            var resultSignIn = _signInManager
                                .CheckPasswordSignInAsync(user, command.Password, false)
                                     .Result.Succeeded;

            if (!resultSignIn)
                return CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                           "Senha inválida.")));

            var roles = _userManager.GetRolesAsync(user).Result;
            return CompletedTask((_tokenService.CreateToken(GenericUserId(user),
                                                            user, 
                                                            roles, 
                                                            UserName(user))));
        }

        public Task<ICommandResult> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {

            var user = _userRepository.GetByEmail(request.Email);
            user.ActivateUser();

            _userRepository.Update(user);

            if (Commit())
                _bus.RaiseEvent(new ActiveUserAccountEvent(user.Email));

            return CompletedTask();
        }



        #region private methods
        private void RegisterPhones(ICollection<PhoneCommand> phones, InstitutionUser institutionUser)
        {
            if (phones == null)
                return;

            foreach (var phone in phones)
                _phoneRepository.Add(new Phone(Guid.NewGuid(), institutionUser.Id, phone.Number));

        }
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

        private void RegisterUserSocialNotificationTypes(User user)
        {
            var socialNotificationType =_socialNotificationTypeRepository.GetAll().FirstOrDefault(x => x.Code.Equals(SocialNotificationTypeConfiguration.Email));
            _userSocialNotificationTypeRepository.Add(new UserSocialNotificationType(Guid.NewGuid(), socialNotificationType.Id, user.Id));
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
                case EUserType.Institution:
                    return _institutionUserRepository.GetByUserId(user.Id).FantasyName;
                default:
                    return user.UserName;
            }
        }

        private Guid GenericUserId(User user)
        {
            switch (user.UserType)
            {
                case EUserType.Donator:
                    return _donatorUserRepository.GetByUserId(user.Id).Id;
                case EUserType.Institution:
                    return _institutionUserRepository.GetByUserId(user.Id).Id;
                case EUserType.Admin:
                    return Guid.NewGuid();
                default: throw new ArgumentException("Nenhum identificador generico foi encontrado. Por favor, Contate o suporte!");
            }
        }
        #endregion

        public void Dispose()
        {
            _donatorUserRepository.Dispose();
        }

        
    }
}
