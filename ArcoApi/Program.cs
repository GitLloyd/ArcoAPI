using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ArcoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Debug("Avvio applicazione...");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                          .UseSerilog((hostingContext, loggerConfiguration) => 
                          loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
            });            
    }
}
