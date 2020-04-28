using IdentityServer4.AccessTokenValidation;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArcoApi.Services
{
    public static class AuthenticationService
    {       
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection jwtConfig = config.GetSection("JwtConfig");
            string wellKnownEndpoint = config.GetSection("WellKnownEndpoint").Value;

            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(wellKnownEndpoint, new OpenIdConnectConfigurationRetriever());
            OpenIdConnectConfiguration openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).Result;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false, // Valida il claim "iss"
                    ValidIssuer = jwtConfig.GetSection("Issuer").Value,
                    ValidateAudience = false, // Valida il claim "aud"
                    ValidAudience = jwtConfig.GetSection("Audience").Value,
                    RequireExpirationTime = false, // Richiede la presenza del claim "exp"
                    ValidateLifetime = false, // Valuta se il token è scaduto
                    ValidateIssuerSigningKey = true, 
                    IssuerSigningKeys = openIdConfig.SigningKeys
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => { throw context.Exception; },
                    //OnForbidden = context => { throw new Exception("Forbidden"); },
                    //OnTokenValidated = context => { throw new Exception("TokenValidated"); },
                    //OnMessageReceived = context => { return Task.CompletedTask; },
                    //OnChallenge = context => { return Task.CompletedTask; }
                };
            }); 

            return services;
        }
    }
}
