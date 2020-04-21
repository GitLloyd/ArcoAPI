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
        public async Task<OpenIdConfigMock> WellKnownEndpoint()
        {
            using var reader = new StreamReader("Mocks\\inail_openid_config.json");
            string fileContent = await reader.ReadToEndAsync();
            OpenIdConfigMock openIdConfig = JsonConvert.DeserializeObject<OpenIdConfigMock>(fileContent);

            return openIdConfig;
        }

        [Route("jwks")]
        [Produces("application/json")]
        public async Task<JsonWebKeySet> JwksURI()
        {
            using var reader = new StreamReader("Mocks\\jwks.json");
            string fileContent = await reader.ReadToEndAsync();
            JsonWebKeySet set = new JsonWebKeySet(fileContent);
            return set;

            //Jwks jwks = JsonConvert.DeserializeObject<Jwks>(fileContent);
            //ICollection<JsonWebKey> keys = jwks.Keys;
            //return jwks.Keys;
        }
    }
}