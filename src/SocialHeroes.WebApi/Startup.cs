using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SocialHeroes.CrossCutting.IoC;
using SocialHeroes.Domain.Core.Configurations;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Configurations;
using SocialHeroes.Infra.Data.Context;
using SocialHeroes.WebApi.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace SocialHeroes.WebApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");         
            Configuration = builder.Build();

            RegisterIdentity(services);




            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });


            services.AddResponseCompression();

            //Injector Dependency
            RegisterServices(services);


            #region TokenConfiguration
            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfiguration"))
                    .Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            RegisterToken(services, signingConfigurations, tokenConfiguration);
            #endregion


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Social Heroes Project",
                    Description = "Social Heroes API Swagger",
                    Contact = new Contact { Name = "Cristian Ferreira", Email = "cristianferreira_gks@hotmail.com", Url = "https://www.linkedin.com/in/cristiansantosferreira/" },               
                });
            });

            AddMediatr(services);
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              SocialHeroesContext context,
                              UserManager<User> userManager,
                              RoleManager<Role> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Criação de estruturas, usuários e permissões
            // na base do ASP.NET Identity Core (caso ainda não
            // existam)
            new IdentityInitializerConfiguration(context, userManager, roleManager)
                .Initialize();

            app.UseMvc();
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Heroes Project API v1.0");
            });
        }

        private static void AddMediatr(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SocialHeroes.Domain"); ;
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddMediatR(typeof(Startup).Assembly);
        }
        private static void RegisterServices(IServiceCollection services)
        {
            NativeDependencyInjection.RegisterServices(services);
        }
        private static void RegisterIdentity(IServiceCollection services)
        {
            IdentityConfigurationService.RegisterIdentityService(services);
        }
        private void RegisterToken(IServiceCollection services, SigningConfiguration signingConfigurations, TokenConfiguration tokenConfiguration)
        {
            TokenConfigurationService.RegisterTokenService(services, signingConfigurations, tokenConfiguration);
        }
    }
}
