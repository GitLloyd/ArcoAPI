using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcoApi.Business;
using ArcoApi.Business.QlikBusiness;
using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Middlewares.ExtensionMethods;
using ArcoApi.Repositories;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ArcoApi
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
            services.AddSingleton<IBusinessDatiPraticaAudit, BusinessDatiPraticaAudit>();
            services.AddSingleton<IBusinessAuditOperativoAccesso, BusinessAuditOperativoAccesso>();
            services.AddSingleton<IBusinessPraticaGruppo, BusinessPraticaGruppo>();
            services.AddSingleton<IBusinessRilievo, BusinessRilievo>();
            services.AddSingleton<IBusinessTeam, BusinessTeam>();
            services.AddSingleton<IBusinessDomandaValore, BusinessDomandaValore>();
            services.AddSingleton<IBusinessSede, BusinessSede>();

            services.AddScoped<IQlikBusiness, QlikBusiness>();

            services.AddControllers();

            // Database
            string connectionString = Configuration.GetConnectionString("ViewQlikDatabase");
            services.AddDbContext<QlikDbContext>(options => options.UseSqlServer(connectionString));


            string secret = Configuration.GetSection("JwtConfig").GetSection("Secret").Value;
            byte[] key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "www.inail.it",
                    ValidateAudience = true,
                    ValidAudience = "ArcoAPI",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }; 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseAutoAuthentication();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
