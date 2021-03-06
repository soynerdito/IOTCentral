﻿using IotCentral.Storage;
using IotCentral.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using IotCentral.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using IotCentral.Services;

using NSwag.AspNetCore;

namespace IotCentral
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //In memory database for the time beeing
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase() );

            services.AddIdentity<User, IdentityRole>(
                options => options.Stores.MaxLengthForKeys = 128
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddClaimsPrincipalFactory<AppClaimFactory>()
                .AddDefaultTokenProviders( );

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Iot Central Api";
                    document.Info.Description = "Basic project to play on the web";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Soynerdito",
                        Email = string.Empty,
                        Url = "https://twitter.com/soynerdito"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Creative Commons Attribution 4.0 International (CC BY 4.0)",
                        Url = "https://creativecommons.org/licenses/by/4.0/"
                    };
                };
            });
           

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IStorage<Device>>(new GenericStorage<Device>());
            services.AddSingleton<OpenStorage>();
            services.AddMvc();
            
            //Stuff for Messaging
            services.AddSignalR();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            /*app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Requires the following import:
                    // using Microsoft.AspNetCore.Http;
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
                }
            });*/
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<IotMessageHub>("/iothub");
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUi3();


            app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
