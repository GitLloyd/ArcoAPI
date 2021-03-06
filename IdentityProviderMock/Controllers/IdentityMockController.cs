﻿using System.IO;
using System.Threading.Tasks;
using IdentityProviderMock.Models;
using Microsoft.AspNetCore.Mvc;
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
            string jwksJson = await reader.ReadToEndAsync();
            JsonWebKeySet jwks = new JsonWebKeySet(jwksJson);

            return jwks;
        }
    }
}