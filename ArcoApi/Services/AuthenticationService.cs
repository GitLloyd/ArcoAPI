using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArcoApi.Services
{
    public static class AuthenticationService
    {       
        public static async Task<IServiceCollection> AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection jwtConfig = config.GetSection("JwtConfig");
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.GetSection("Secret").Value);
            string wellknownEndpoint = config.GetSection("WellKnownEndpoint").Value;

            AuthenticationBuilder builder = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(wellknownEndpoint, new OpenIdConnectConfigurationRetriever());
            OpenIdConnectConfiguration openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.GetSection("Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.GetSection("Audience").Value,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = openIdConfig.SigningKeys
                };
            }); 

            return services;
        }
    }
}
