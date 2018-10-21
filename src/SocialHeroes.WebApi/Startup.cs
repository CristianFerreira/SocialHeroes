using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.CrossCutting.IoC;
using SocialHeroes.WebApi.Configurations;
using Swashbuckle.AspNetCore.Swagger;
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

            //services.AddDbContext<SocialHeroesContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });

            services.AddResponseCompression();
            // .NET Native DI Abstraction
            RegisterServices(services);

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

            services.AddMediatR(typeof(Startup).Assembly);


            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            //app.UseAuthentication();
          
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Heroes Project API v1.0");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeDependencyInjection.RegisterServices(services);
        }
    }
}
