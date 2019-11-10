using System.Reflection;
using BlazorState;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourOfHeroes.Web.Common.State.Heroes;
using TourOfHeroes.Web.Common.State.Details;
using TourOfHeroes.Web.Common.State;

namespace TourOfHeroes.Web
{
    /// <summary>
    /// Configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup method for the application.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to startup with.</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The applications <see cref="IConfiguration"/>.
        /// </summary>
        private static IConfiguration _configuration;

        /// <summary>
        /// Configures the app's services.
        /// </summary>
        /// <param name="services">The container to add additional service to.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
#if (DEBUG == false)
            var azureSignalRConnectionString =  _configuration
                .GetSection("Azure")
                .GetSection("SignalR")
                .GetSection("ConnectionString")
                .Value;

            services
                .AddSignalR()
                .AddAzureSignalR(
                    azureSignalRConnectionString
                );
#endif

            services.AddBlazorState((options) =>
                options.Assemblies = new Assembly[]
                {
                    typeof(BaseHandler<IAction>).GetTypeInfo().Assembly
                });

            services.AddScoped<HeroesState>();
            services.AddScoped<DetailsState>();
        }

        /// <summary>
        /// Configures how the app responds to HTTP requests.
        /// </summary>
        /// <param name="app">The middleware components to configure the request pipeline with.</param>
        /// <param name="env">The environment in which the application is run.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
