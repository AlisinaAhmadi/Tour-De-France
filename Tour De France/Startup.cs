using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France
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
            services.AddRazorPages();
            services.AddDbContext<EventDbContext>();
            services.AddSingleton<DeltagerService, DeltagerService>();
            services.AddSingleton<EventService, EventService>();
            services.AddSingleton<MusikteltService, MusikteltService>();
            services.AddSingleton<SpiseteltService, SpiseteltService>();
            services.AddSingleton<ParkeringspladsService, ParkeringspladsService>();
            services.AddSingleton<TogafgangeService, TogafgangeService>();
            services.AddSingleton<TribuneService,TribuneService>();
            services.AddSingleton<VIPService, VIPService>();
            services.AddTransient<DbGenericService<Togafgang>,DbGenericService<Togafgang>>();
            services.AddTransient<DbGenericService<VIP>,DbGenericService<VIP>>();
            services.AddTransient<DbGenericService<Order>,DbGenericService<Order>>();
            services.AddTransient<DbGenericService<EventOrder>,DbGenericService<EventOrder>>();
            services.AddTransient<DbGenericService<Tribune>,DbGenericService<Tribune>>();
            services.AddTransient<DbGenericService<Event>,DbGenericService<Event>>();
            services.AddTransient<DbGenericService<Parking_plads>,DbGenericService<Parking_plads>>();
            services.AddTransient<DbGenericService<Spisetelt>,DbGenericService<Spisetelt>>();
            services.AddTransient<DbGenericService<Musiktelt>,DbGenericService<Musiktelt>>();
            services.AddSingleton<OrderService, OrderService>();
            services.AddSingleton<EventOrderService, EventOrderService>();
            services.AddTransient<DeltagerDbService, DeltagerDbService>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
            {
                cookieOptions.LoginPath = "/LogIn/LogIn";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "admin"));
            });



            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Home");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
