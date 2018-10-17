using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.DonatorContext.Handlers.HairHandlers;
using SocialHeroes.Domain.DonatorContext.Repositories;
using SocialHeroes.Infra;
using SocialHeroes.Infra.SharedContext.DataContexts;

namespace SocialHeroes.Api
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IHairRepository, HairRepository>(); ;
            services.AddTransient<HairHandler, HairHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
