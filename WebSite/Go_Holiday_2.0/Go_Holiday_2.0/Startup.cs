using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go_Holiday_2._0.Utils.Controller.API;
using Go_Holiday_2._0.Utils.Controller.API.Login;
using Go_Holiday_2._0.Utils.Security;
using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Go_Holiday_2._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddSingleton(p => new Uri("https://localhost:44393/")); //URL de base de l'api  ---- IIS Express
            services.AddSingleton(p => new Uri("https://localhost:5001/")); //URL de base de l'api ----- Self contained


            services.AddSingleton<IControllerAPI, ControllerAPI>(); //controller, g�re les appel au api controller
            services.AddSingleton<LoginSystemAPI>();
            services.AddSingleton<SignUpSystemAPI>();
            services.AddTransient<EditUserSystemAPI>();

            services.AddSingleton<CryptingRSA>(); //permettra de crypter le mot de passe / donn�e sensible du user


            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromDays(1); // on garde une session active 1 jour max
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                }
            );
            
            services.AddTransient<ISessionManager, SessionManager>(); // on ajout le session manager en injection de d�p, en transient, permet 
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
