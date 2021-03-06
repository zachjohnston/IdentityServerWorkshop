using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;

namespace IdentityProvider
{
    public static class IdentityConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("protectedApi", "Sample API"),
                new ApiResource("apiResource", "API Resource")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ConsoleClient",
                    ClientName = "Identity Server Console Client",
                    ClientSecrets =
                    {
                        new Secret("secretKey".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "apiResource" }
                },
                new Client
                {
                    ClientId = "IdentityResourceClient",
                    ClientName = "Identity Resource Console Client",
                    ClientSecrets =
                    {
                        new Secret("secretKey".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "openid", "profile" }
                },
                new Client
                {
                    ClientId = "WebClient",
                    ClientName = "Identity Resource Web Client",
                    ClientSecrets =
                    {
                        new Secret("secretKey".Sha256())
                    },
                    RequireConsent = false,
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5020/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5020/signout-callback-oidc" },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid","profile" }
                }
            };
        }
    }
}