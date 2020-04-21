using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProviderMock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IdentityProviderMock.Controllers
{
    [Route("identitymockapi")]
    [ApiController]
    public class IdentityMockController : ControllerBase
    {
        [Route(".well-known/inail-configuration")]
        [Produces("application/json")]
        public async Task<OpenIdConnectConfiguration> WellKnownEndpoint()
        {
            using var reader = new StreamReader("Mocks\\inail_openid_config.json");
            string fileContent = await reader.ReadToEndAsync();
            var openIdConfig = OpenIdConnectConfiguration.Create(fileContent);
            //OpenIdConnectConfiguration openIdConfig = JsonConvert.DeserializeObject<OpenIdConnectConfiguration>(fileContent);

            return openIdConfig;
        }

        [Route("jwks")]
        [Produces("application/json")]
        public async Task<ICollection<JsonWebKey>> JwksURI()
        {
            using var reader = new StreamReader("Mocks\\jwks.json");
            string fileContent = await reader.ReadToEndAsync();
            Jwks jwks = JsonConvert.DeserializeObject<Jwks>(fileContent);

            return jwks.Keys;
        }
    }
}