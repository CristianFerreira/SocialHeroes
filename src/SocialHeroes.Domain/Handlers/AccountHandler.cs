﻿using MediatR;
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
                                  IRequestHandler<RegisterNewHospitalUserCommand, ICommandResult>,
                                  IRequestHandler<TokenUserCommand, ICommandResult>
    {
        private readonly IMediatorHandler _bus;
        private readonly ITokenService _tokenService;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IHospitalUserRepository _hospitalUserRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserNotificationTypeRepository _userNotificationTypeRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IDonatorUserRepository donatorUserRepository,
                              IHospitalUserRepository hospitalUserRepository,
                              IAddressRepository addressRepository,
                              IUserNotificationTypeRepository userNotificationTypeRepository,
                              IPhoneRepository phoneRepository,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager)
                              : base(uow, bus, notifications)
        {
            _bus = bus;
            _tokenService = tokenService;
            _donatorUserRepository = donatorUserRepository;
            _hospitalUserRepository = hospitalUserRepository;
            _addressRepository = addressRepository;
            _userNotificationTypeRepository = userNotificationTypeRepository;
            _phoneRepository = phoneRepository;
            _userManager = userManager;
            _signInManager = signInManager;
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

                    RegisterUserNotificationTypes(command.UserNotificationTypes, user);

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

        public async Task<ICommandResult> Handle(RegisterNewHospitalUserCommand command, 
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

                    if (!RegisterRole(user, RolesConfiguration.ROLE_HOSPITAL, out IdentityResult resultRole))
                        return await CanceledTask(_bus.RaiseEvent(new DomainNotification(command.MessageType,
                                                                                         $"Ocorreu erro ao atribuir uma Role \n: {resultRole.Errors.ToList()[0].Description}")));

                    RegisterAddress(command.Address, user);

                    RegisterHospital(command, user, out HospitalUser hospitalUser);

                    RegisterPhones(command.Phones, hospitalUser);

                    Commit(transaction);
                        //await _bus.RaiseEvent(new HospitalAccountRegisteredEvent());

                    return await CompletedTask(hospitalUser);
                }
                catch (Exception exception)
                {
                    RollBack(transaction);
                    throw exception;
                }
            }
        }

        private void RegisterPhones(ICollection<PhoneCommand> phones, HospitalUser hospitalUser)
        {
            if (phones == null)
                return;

            foreach (var phone in phones)
              _phoneRepository.Add(new Phone(Guid.NewGuid(), hospitalUser.Id, phone.Number));
            
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
                                      command.State,
                                      command.Country,
                                      command.ZipCode,
                                      command.Latitude,
                                      command.Longitude);
            _addressRepository.Add(address);
        }

        private void RegisterHospital(RegisterNewHospitalUserCommand command,
                                      User user,
                                      out HospitalUser hospitalUser)
        {
            hospitalUser = new HospitalUser(Guid.NewGuid(),
                                            user.Id,
                                            command.SocialReason,
                                            command.FantasyName,
                                            command.CNPJ);

            _hospitalUserRepository.Add(hospitalUser);
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

        private void RegisterUserNotificationTypes(ICollection<UserNotificationTypeCommand> userNotificationTypes,
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
                                              command.DateBirth,
                                              command.LastDonation);

            _donatorUserRepository.Add(donatorUser);
        }

        private string UserName(User user)
        {
            switch (user.UserType)
            {
                case EUserType.Donator:
                    return _donatorUserRepository.GetByUserId(user.Id).Name;
                case EUserType.Hospital:
                    return _hospitalUserRepository.GetByUserId(user.Id).FantasyName;
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
