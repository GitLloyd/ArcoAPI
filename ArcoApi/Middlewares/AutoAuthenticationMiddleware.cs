using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Claims;

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
            string secret   = config.GetSection("JwtConfig").GetSection("Secret").Value;
            string expDate  = config.GetSection("JwtConfig").GetSection("ExpirationTime").Value;
            string issuer   = config.GetSection("JwtConfig").GetSection("Issuer").Value;
            string audience = config.GetSection("JwtConfig").GetSection("Audience").Value;

            string token = $"Bearer {GenerateSecurityToken(secret, expDate, issuer, audience)}";

            context.Request.Headers.Remove("Authorization");
            context.Request.Headers.Add("Authorization", token);

            string requestToken = context.Request.Headers["Authorization"].ToString();

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private string GenerateSecurityToken(string _secret, string _expDate, string _issuer, string _audience)
        {
            byte[] secret = Encoding.ASCII.GetBytes(_secret);
            var key = new SymmetricSecurityKey(secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}