using System.Reflection;
using BlazorState;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlazorApp.Client.Features.Base;
using TourOfHeroes.Components.Heroes.State;

namespace TourOfHeroes.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // If you're getting Error: Handler was not found for request of type MediatR.IRequestHandler`2[YourAction,MediatR.Unit]. Register your handlers with the container.
            // Then you need to add the assemblies where the handlers live. Blazor State will then scan for Handlers in that assembly.
            // You essentially could add any class in here providing it lives in the same assembly... I'm using the base handler as that makes most sense.
            services.AddBlazorState((options) => 
                options.Assemblies = new Assembly[] 
                {
                    typeof(BaseHandler<IAction>).GetTypeInfo().Assembly
                });

            services.AddScoped<HeroState>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
