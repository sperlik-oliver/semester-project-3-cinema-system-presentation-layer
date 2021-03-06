using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ABDOTClient.Authentication;
using ABDOTClient.Data;
using ABDOTClient.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ABDOTClient{
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration{ get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services){
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<IMovieService, CloudMovieService>();
            services.AddScoped<IEmployeeService, EmployeeCloudService>();
            services.AddScoped<IBranchService, BranchCloudService>();
            services.AddScoped<IHallService, HallCloudService>();
            services.AddScoped<IPlayService, PlayCloudService>();
            services.AddScoped<ITicketService, TicketCloudService>();



            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeOwner", builder =>
                    builder.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "1"));
                options.AddPolicy("MustBeManager", builder =>
                    builder.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "1","2"));
                options.AddPolicy("MustBeEmployee", builder =>
                    builder.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "3","2","1"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            else{
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}