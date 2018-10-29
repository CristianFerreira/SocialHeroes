using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;

namespace SocialHeroes.Infra.Data.Configurations
{
    public class IdentityInitializerConfiguration
    {
        private readonly SocialHeroesContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;


        public IdentityInitializerConfiguration(
            SocialHeroesContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                CreateRoles();

                CreateUser(
                    new User(Guid.NewGuid(), EUserType.Admin, "admin@admin.com.br", true),
                    "admin123456",
                    RolesConfiguration.ROLE_API_ADMIN);
            }
        }
        private void CreateRoles()
        {
            if (!_roleManager.RoleExistsAsync(RolesConfiguration.ROLE_API_ADMIN).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new Role(RolesConfiguration.ROLE_API_ADMIN)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {RolesConfiguration.ROLE_API_ADMIN}.");
                }
            }

            if (!_roleManager.RoleExistsAsync(RolesConfiguration.ROLE_API_HOSPITAL).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new Role(RolesConfiguration.ROLE_API_HOSPITAL)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {RolesConfiguration.ROLE_API_HOSPITAL}.");
                }
            }

            if (!_roleManager.RoleExistsAsync(RolesConfiguration.ROLE_API_DONATOR).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new Role(RolesConfiguration.ROLE_API_DONATOR)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {RolesConfiguration.ROLE_API_DONATOR}.");
                }
            }
        }
        private void CreateUser(User user, string password, string initialRole)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
