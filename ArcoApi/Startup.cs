using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcoApi.Business;
using ArcoApi.Business.QlikBusiness;
using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Middlewares.ExtensionMethods;
using ArcoApi.Repositories;
using ArcoApi.Services;
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
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
        public async void ConfigureServices(IServiceCollection services)
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

            await services.AddTokenAuthentication(Configuration);
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
