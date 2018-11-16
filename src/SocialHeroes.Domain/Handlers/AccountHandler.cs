using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Commands.AccountCommand;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Enums;
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
        IRequestHandler<GetTokenAccountCommand, ICommandResult>
    {
        private readonly IMediatorHandler _bus;
        private readonly ITokenService _tokenService;
        private readonly IDonatorUserRepository _donatorUserRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IDonatorUserRepository donatorUserRepository,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager)
                              : base(uow, bus, notifications)
        {
            _bus = bus;
            _tokenService = tokenService;
            _donatorUserRepository = donatorUserRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ICommandResult> Handle(RegisterNewDonatorAccountCommand command, CancellationToken cancellationToken)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var user = new User(Guid.NewGuid(), EUserType.Donator, command.Email, true);
                    await _userManager.CreateAsync(user, command.Password);

                    var donatorUser = new DonatorUser(Guid.NewGuid(),
                                                      user,
                                                      command.Name,
                                                      command.Genre,
                                                      command.DateBirth,
                                                      command.LastDonation);

                    _donatorUserRepository.Add(donatorUser);

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

        public Task<ICommandResult> Handle(GetTokenAccountCommand command, CancellationToken cancellationToken)
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
