using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.Library.Configurations
{
    public static class ClientConfiguration
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = { "api1" }       // scopes that client has access to
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = {
                        "https://localhost:5301/home/redirecturi"
                    },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = {
                        "https://localhost:5301/home/logoutredirecturi"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

             
            

            };
        }

    }
}
