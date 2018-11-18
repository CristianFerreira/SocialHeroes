using Microsoft.AspNetCore.Identity;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;

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
                CreateHairs();
                CreateRoles();

                CreateUser(
                    new User(Guid.NewGuid(), EUserType.Admin, "admin@admin.com.br", true),
                    "admin123456",
                    RolesConfiguration.ROLE_API_ADMIN);
            }
        }

        private void CreateHairs()
        {
            var hairs = new List<Hair>
            {
                new Hair(Guid.NewGuid(),"ULTRA PRETO","LISO"),
                new Hair(Guid.NewGuid(),"ULTRA PRETO","ONDULADO"),
                new Hair(Guid.NewGuid(),"ULTRA PRETO","CACHEADO"),
                new Hair(Guid.NewGuid(),"ULTRA PRETO","CRESPO"),

                new Hair(Guid.NewGuid(),"PRETO","LISO"),
                new Hair(Guid.NewGuid(),"PRETO","ONDULADO"),
                new Hair(Guid.NewGuid(),"PRETO","CACHEADO"),
                new Hair(Guid.NewGuid(),"PRETO","CRESPO"),

                new Hair(Guid.NewGuid(),"CASTANHO ESCURO","LISO"),
                new Hair(Guid.NewGuid(),"CASTANHO ESCURO","ONDULADO"),
                new Hair(Guid.NewGuid(),"CASTANHO ESCURO","CACHEADO"),
                new Hair(Guid.NewGuid(),"CASTANHO ESCURO","CRESPO"),

                new Hair(Guid.NewGuid(),"CASTANHO MÉDIO","LISO"),
                new Hair(Guid.NewGuid(),"CASTANHO MÉDIO","ONDULADO"),
                new Hair(Guid.NewGuid(),"CASTANHO MÉDIO","CACHEADO"),
                new Hair(Guid.NewGuid(),"CASTANHO MÉDIO","CRESPO"),

                new Hair(Guid.NewGuid(),"CASTANHO CLARO","LISO"),
                new Hair(Guid.NewGuid(),"CASTANHO CLARO","ONDULADO"),
                new Hair(Guid.NewGuid(),"CASTANHO CLARO","CACHEADO"),
                new Hair(Guid.NewGuid(),"CASTANHO CLARO","CRESPO"),

                new Hair(Guid.NewGuid(),"LOIRO ESCURO","LISO"),
                new Hair(Guid.NewGuid(),"LOIRO ESCURO","ONDULADO"),
                new Hair(Guid.NewGuid(),"LOIRO ESCURO","CACHEADO"),
                new Hair(Guid.NewGuid(),"LOIRO ESCURO","CRESPO"),

                new Hair(Guid.NewGuid(),"LOIRO MÉDIO","LISO"),
                new Hair(Guid.NewGuid(),"LOIRO MÉDIO","ONDULADO"),
                new Hair(Guid.NewGuid(),"LOIRO MÉDIO","CACHEADO"),
                new Hair(Guid.NewGuid(),"LOIRO MÉDIO","CRESPO"),

                new Hair(Guid.NewGuid(),"LOIRO CLARO","LISO"),
                new Hair(Guid.NewGuid(),"LOIRO CLARO","ONDULADO"),
                new Hair(Guid.NewGuid(),"LOIRO CLARO","CACHEADO"),
                new Hair(Guid.NewGuid(),"LOIRO CLARO","CRESPO"),

                new Hair(Guid.NewGuid(),"LOIRO ULTRA CLARO","LISO"),
                new Hair(Guid.NewGuid(),"LOIRO ULTRA CLARO","ONDULADO"),
                new Hair(Guid.NewGuid(),"LOIRO ULTRA CLARO","CACHEADO"),
                new Hair(Guid.NewGuid(),"LOIRO ULTRA CLARO","CRESPO"),

                new Hair(Guid.NewGuid(),"AZUL","LISO"),
                new Hair(Guid.NewGuid(),"AZUL","ONDULADO"),
                new Hair(Guid.NewGuid(),"AZUL","CACHEADO"),
                new Hair(Guid.NewGuid(),"AZUL","CRESPO"),

                new Hair(Guid.NewGuid(),"VIOLETA","LISO"),
                new Hair(Guid.NewGuid(),"VIOLETA","ONDULADO"),
                new Hair(Guid.NewGuid(),"VIOLETA","CACHEADO"),
                new Hair(Guid.NewGuid(),"VIOLETA","CRESPO"),

                new Hair(Guid.NewGuid(),"DOURADO","LISO"),
                new Hair(Guid.NewGuid(),"DOURADO","ONDULADO"),
                new Hair(Guid.NewGuid(),"DOURADO","CACHEADO"),
                new Hair(Guid.NewGuid(),"DOURADO","CRESPO"),

                new Hair(Guid.NewGuid(),"ACOBREADO","LISO"),
                new Hair(Guid.NewGuid(),"ACOBREADO","ONDULADO"),
                new Hair(Guid.NewGuid(),"ACOBREADO","CACHEADO"),
                new Hair(Guid.NewGuid(),"ACOBREADO","CRESPO"),

                new Hair(Guid.NewGuid(),"VERMELHO ","LISO"),
                new Hair(Guid.NewGuid(),"VERMELHO ","ONDULADO"),
                new Hair(Guid.NewGuid(),"VERMELHO ","CACHEADO"),
                new Hair(Guid.NewGuid(),"VERMELHO","CRESPO"),

                new Hair(Guid.NewGuid(),"MARROM ","LISO"),
                new Hair(Guid.NewGuid(),"MARROM ","ONDULADO"),
                new Hair(Guid.NewGuid(),"MARROM ","CACHEADO"),
                new Hair(Guid.NewGuid(),"MARROM","CRESPO"),

                new Hair(Guid.NewGuid(),"VERDE ","LISO"),
                new Hair(Guid.NewGuid(),"VERDE ","ONDULADO"),
                new Hair(Guid.NewGuid(),"VERDE ","CACHEADO"),
                new Hair(Guid.NewGuid(),"VERDE","CRESPO"),
            };
            foreach (var hair in hairs)
            {
                _context.Hairs.Add(hair);
            }

            _context.SaveChanges();
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
