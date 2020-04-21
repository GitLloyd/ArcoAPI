using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProviderMock.Models
{
    public class OpenIdConfigMock
    {
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("authorization_endpoint")]
        public string authorization_endpoint { get; set; }

        [JsonProperty("jwks_uri")]
        public string jwks_uri { get; set; }

        [JsonProperty("id_token_signing_alg_values_supported")]
        public ICollection<string> id_token_signing_alg_values_supported { get; set; }

        [JsonProperty("id_token_encryption_enc_values_supported")]
        public ICollection<string> id_token_encryption_enc_values_supported { get; set; }

        [JsonProperty("id_token_encryption_alg_values_supported")]
        public ICollection<string> id_token_encryption_alg_values_supported { get; set; }

        [JsonProperty("grant_types_supported")]
        public ICollection<string> grant_types_supported { get; set; }

        [JsonProperty("userinfo_endpoint")]
        public string userinfo_endpoint { get; set; }

        [JsonProperty("introspection_endpoint")]
        public string introspection_endpoint { get; set; }

        [JsonProperty("token_endpoint_auth_signing_alg_values_supported")]
        public ICollection<string> token_endpoint_auth_signing_alg_values_supported { get; set; }

        [JsonProperty("token_endpoint_auth_methods_supported")]
        public ICollection<string> token_endpoint_auth_methods_supported { get; set; }

        [JsonProperty("subject_types_supported")]
        public ICollection<string> subject_types_supported { get; set;  }

        [JsonProperty("scopes_supported")]
        public ICollection<string> scopes_supported { get; set; }

        [JsonProperty("service_catalog")]
        public string service_catalog { get; set; }

        [JsonProperty("response_types_supported")]
        public ICollection<string> response_types_supported { get; set; }

        [JsonProperty("cdn_endpoint")]
        public string cdn_endpoint { get; set; }

        [JsonProperty("end_session_endpoint")]
        public string end_session_endpoint { get; set; }

        [JsonProperty("jwks_CA")]
        public string jwks_CA { get; set; }

        [JsonProperty("wellknowninail_endpoint")]
        public string wellknowninail_endpoint { get; set; }

        [JsonProperty("Wellknownb2b_endpoint")]
        public string Wellknownb2b_endpoint { get; set; }



        [JsonProperty("webkit_endpoint")]
        public string WebkitEndpoint { get; set; }

        [JsonProperty("be_endpoint")]
        public string BeEndpoint { get; set; }

        public string MaxTimeout { get; set; }
        public string IdleTimeout { get; set; }
        public string JWTTimeout { get; set; }
        public string AnalyticsID { get; set; }
    }
}
