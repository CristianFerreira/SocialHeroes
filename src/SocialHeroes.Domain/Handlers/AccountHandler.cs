using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Commands.AccountCommand;
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
using System.Threading;
using System.Threading.Tasks;

namespace SocialHeroes.Domain.Handlers
{
    public class AccountHandler : Handler,
                                  IRequestHandler<RegisterNewDonatorAccountCommand, ICommandResult>,
                                  IRequestHandler<RegisterNewHospitalAccountCommand, ICommandResult>,
                                  IRequestHandler<TokenAccountCommand, ICommandResult>
    {
        private readonly IMediatorHandler _bus;
        private readonly ITokenService _tokenService;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly IHospitalUserRepository _hospitalUserRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IDonatorUserRepository donatorUserRepository,
                              IHospitalUserRepository hospitalUserRepository,
                              IAddressRepository addressRepository,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager)
                              : base(uow, bus, notifications)
        {
            _bus = bus;
            _tokenService = tokenService;
            _donatorUserRepository = donatorUserRepository;
            _hospitalUserRepository = hospitalUserRepository;
            _addressRepository = addressRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ICommandResult> Handle(RegisterNewDonatorAccountCommand command, 
                                                 CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var user = new User(Guid.NewGuid(), EUserType.Donator, command.Email);
                    await _userManager.CreateAsync(user, command.Password);

                    var donatorUser = new DonatorUser(Guid.NewGuid(),
                                                      user.Id,
                                                      command.Name,
                                                      command.Genre,
                                                      command.DateBirth,
                                                      command.LastDonation);

                    _donatorUserRepository.Add(donatorUser);

                    await _userManager.AddToRoleAsync(user,
                                                      RolesConfiguration.ROLE_DONATOR);

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

        public async Task<ICommandResult> Handle(RegisterNewHospitalAccountCommand command, 
                                                 CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var user = new User(Guid.NewGuid(), EUserType.Hospital, command.Email);
                    await _userManager.CreateAsync(user, command.Password);

                    var hospitalUser = new HospitalUser(Guid.NewGuid(),
                                                        user.Id,
                                                        command.SocialReason,
                                                        command.FantasyName,
                                                        command.CNPJ);
                                                         
                    _hospitalUserRepository.Add(hospitalUser);

                    await _userManager.AddToRoleAsync(user, 
                                                      RolesConfiguration.ROLE_HOSPITAL);

                    var address = new Address(Guid.NewGuid(), 
                                              user.Id, 
                                              command.Address.Number, 
                                              command.Address.Complement, 
                                              command.Address.Street, 
                                              command.Address.City, 
                                              command.Address.State, 
                                              command.Address.Country, 
                                              command.Address.ZipCode, 
                                              command.Address.Latitude, 
                                              command.Address.Longitude);
                    _addressRepository.Add(address);
                    
                    if(Commit(transaction))
                        await _bus.RaiseEvent(new HospitalAccountRegisteredEvent());

                    return await CompletedTask(hospitalUser);
                }
                catch (Exception exception)
                {
                    RollBack(transaction);
                    throw exception;
                }
            }
        }

        public Task<ICommandResult> Handle(TokenAccountCommand command, 
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

        private string UserName(User user)
        {
            switch (user.UserType)
            {
                case EUserType.Donator:
                    return _donatorUserRepository.GetByUserId(user.Id).Name;
                case EUserType.Hospital:
                    return "";
                case EUserType.Admin:
                    return user.UserName;
                default:
                    return "";
            }
        }

        public void Dispose()
        {
            _donatorUserRepository.Dispose();
        }

        
    }
}
