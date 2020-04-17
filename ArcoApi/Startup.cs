using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcoApi.Business;
using ArcoApi.Business.QlikBusiness;
using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

            services.AddSingleton<IQlikBusiness, QlikBusiness>();

            services.AddControllers();

            services.AddDbContext<QlikDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ViewQlikDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
