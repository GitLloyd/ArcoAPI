using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Threading;
using Microsoft.IdentityModel.Protocols;
using Serilog;

namespace AuthTest.API.Middleware
{
    public class AutoAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AutoAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration config)
        {
            IConfigurationSection jwtConfig = config.GetSection("JwtConfig");
            string expDate  = jwtConfig.GetSection("ExpirationTime").Value;
            string issuer   = jwtConfig.GetSection("Issuer").Value;
            string audience = jwtConfig.GetSection("Audience").Value;

            string wellKnownEndpoint = config.GetSection("WellKnownEndpoint").Value;

            string token = await GenerateSecurityToken(expDate, issuer, audience, wellKnownEndpoint);
            token = "Bearer " + token;

            context.Request.Headers.Remove("Authorization");
            context.Request.Headers.Add("Authorization", token);

            string requestToken = context.Request.Headers["Authorization"].ToString();

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private async Task<string> GenerateSecurityToken(string _expDate, string _issuer, string _audience, string _wellKnownEndpoint)
        {
            Log.Warning("Generazione SecurityToken...\nRichiesta OIDC Configuration...");
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(_wellKnownEndpoint, new OpenIdConnectConfigurationRetriever());
            OpenIdConnectConfiguration openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
            Log.Debug("OIDC Configuration ottenuta.\nImpostazione del token...");
            JsonWebKey key = openIdConfig.JsonWebKeySet.Keys.Last();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                Audience = _audience,
                Issuer = _issuer, 
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            Log.Debug("Token generato.");

            return tokenHandler.WriteToken(token);
        }
    }
}