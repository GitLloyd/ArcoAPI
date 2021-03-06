using ArcoApi.Business;
using ArcoApi.Business.QlikBusiness;
using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Repositories;
using ArcoApi.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

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
            Log.Debug("Configurazione dei servizi avviata. Aggiunta delle dipendenze...");
            services.AddSingleton<IBusinessDatiPraticaAudit, BusinessDatiPraticaAudit>();
            services.AddSingleton<IBusinessAuditOperativoAccesso, BusinessAuditOperativoAccesso>();
            services.AddSingleton<IBusinessPraticaGruppo, BusinessPraticaGruppo>();
            services.AddSingleton<IBusinessRilievo, BusinessRilievo>();
            services.AddSingleton<IBusinessTeam, BusinessTeam>();
            services.AddSingleton<IBusinessDomandaValore, BusinessDomandaValore>();
            services.AddSingleton<IBusinessSede, BusinessSede>();
            services.AddScoped<IQlikBusiness, QlikBusiness>();

            Log.Debug("Dipendenze configurate. Aggiunta dei controller...");
            services.AddControllers();

            // Database
            Log.Debug("Controller creati. Aggiunta del database...");
            string connectionString = Configuration.GetConnectionString("ViewQlikDatabase");
            services.AddDbContext<QlikDbContext>(options => options.UseSqlServer(connectionString));

            Log.Debug("Database impostato. Aggiunta dell'autenticazione tramite token...");
            services.AddTokenAuthentication(Configuration);
            Log.Debug("Autenticazione con token impostata.");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.UseAutoAuthentication();
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
