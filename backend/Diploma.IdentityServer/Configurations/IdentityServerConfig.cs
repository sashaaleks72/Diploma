using IdentityServer4;
using IdentityServer4.Models;

namespace Diploma.IdentityServer.Configurations
{
    public sealed class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>{
                new ApiResource("api", "My_Api_Client")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client> {
                new Client
                {
                    AllowedCorsOrigins = { "https://localhost:44374" },
                    AccessTokenLifetime = 1800,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientId = "swagger_login",
                    ClientSecrets = { new Secret("swagger_pass".Sha256())},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId
                    }
                },
                new Client
                {
                    AccessTokenLifetime = 1800,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientId = "react_login",
                    ClientSecrets = { new Secret("react_pass".Sha256())},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            };
        }
    }
}
