using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProviderMock.Models
{
    public class Jwks
    {
        [JsonProperty("keys")]
        public ICollection<JsonWebKey> Keys { get; set; }
    }
}
