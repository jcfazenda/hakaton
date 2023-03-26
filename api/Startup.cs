
using api.Domain.Configure;
using api.Domain.Models;
using api.Domain.Tenant;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /* Authentication */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 
             
            services.AddAutoMapper();
            RegisterServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }
            );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddOptions();
            services.AddSignalR(); /* HUB SignalR */

            /* TENANT */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCustomerDbContext(Configuration);

            /* Swagger */
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "EGRC API"
                });
            });

            RegisterSecurity(services, Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMvc();
            app.UseCookiePolicy();

            app.UseCors("CorsPolicy");
            app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            /* HUB SignalR */
            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalR>("/SignalR");
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(CacheSegments));
            NativeInjector.RegisterServices(services);
        }

        private static void RegisterSecurity(IServiceCollection services, IConfiguration configuration)
        {
            //var key = Encoding.ASCII.GetBytes(configuration["JWT:Apikey"]);

            var key = Encoding.ASCII.GetBytes("d66d1a9c-27ae-4115-a443-5956dc4deb55-fa3ca3ea-e693-4a66-9054-b2e60e9bc51e");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}