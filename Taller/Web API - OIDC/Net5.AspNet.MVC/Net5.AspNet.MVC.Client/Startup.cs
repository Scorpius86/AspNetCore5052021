using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net5.AspNet.MVC.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Net5.AspNet.MVC.Client.Helper;
using Net5.AspNet.MVC.Infrastructure.Data.Blog.Repositories;
using Net5.AspNet.MVC.Infrastructure.Data.Audit.Repositories;
using Net5.AspNet.MVC.Infrastructure.Helper.Log;
using Net5.AspNet.MVC.Infrastructure.Helper.Error;
using Net5.AspNet.MVC.Infrastructure.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using IdentityModel;
using static IdentityModel.OidcConstants;

namespace Net5.AspNet.MVC.Client
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(opt => {
                opt.Filters.Add(new AuthorizeFilter());
             })
                .AddRazorRuntimeCompilation();
            
            services.AddHttpContextAccessor();
            services.AddBlogRepositories(opt=> opt.ConnectionString = Configuration.GetConnectionString("BlogContextConnection"));
            services.AddAuditRepositories(opt => opt.ConnectionString = Configuration.GetConnectionString("AuditContextConnection"));
            services.AddServices();

            services.AddScoped<LogFilter>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(Policies.EditPost, policy => policy.RequireClaim("GrantAccess", GrantAccess.Edit));
                opt.AddPolicy(Policies.DeletePost, policy => policy.RequireClaim("GrantAccess", GrantAccess.Delete));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(opt=>
            {
                opt.AccessDeniedPath = "/Account/AccessDenied";
            })
            .AddOpenIdConnect(opt =>
            {
                opt.Authority = "https://localhost:44320";
                opt.ClientId = "Net5.AspNet.MVC.Client";

                opt.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                opt.Scope.Add("Net5.AspNet.MVC");

                opt.SaveTokens = true;

                opt.GetClaimsFromUserInfoEndpoint = true;
                opt.ClaimActions.MapJsonKey(ClaimTypes.Role, ClaimTypes.Role);
                opt.ClaimActions.MapJsonKey(JwtClaimTypes.Role, JwtClaimTypes.Role);
                opt.ClaimActions.MapJsonKey(SecurityClaimType.GrantAccess, SecurityClaimType.GrantAccess);

                opt.ResponseType = ResponseTypes.Code;
                opt.ResponseMode = ResponseModes.FormPost;

                opt.UsePkce = true;
                opt.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
                opt.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandlerMiddleware();
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

            app.UseAuthentication();
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
