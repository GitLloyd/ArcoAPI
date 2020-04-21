using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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
            using var reader = new StreamReader("Mocks\\inail_opeind_config.json");
            string line = await reader.ReadToEndAsync();
            OpenIdConnectConfiguration openIdConfig = new OpenIdConnectConfiguration(line);

            return openIdConfig;
        }

        [Route("jwks")]
        [Produces("application/json")]
        public async Task<string> JwksURI()
        {
            using var reader = new StreamReader("Mocks\\jwks.json");
            string line = await reader.ReadToEndAsync();

            return line;
        }
    }
}