using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4;
using System.Security.Claims;

namespace Identity.Main
{
    public class Config
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
        {
              new Client
              {
                        ClientId = "movieClient",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "movieAPI" }
              }
    };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("movieAPI", "Movie API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
               //new ApiResource("movieAPI", "Movie API")
          };
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
      new List<IdentityResource>
      {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile()
      };
        //public static IEnumerable<IdentityResource> GetIdentityResources =>
        //  new IdentityResource[]
        //  {
        //      new IdentityResources.OpenId(),
        //      new IdentityResources.Profile(),
        //      //new IdentityResources.Address(),
        //      //new IdentityResources.Email(),
        //      //new IdentityResource(
        //      //      "roles",
        //      //      "Your role(s)",
        //      //      new List<string>() { "role" })
        //  };

        //public static List<TestUser> TestUsers =>
        //    new List<TestUser>
        //    {
        //        new TestUser
        //        {
        //            SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
        //            Username = "mehmet",
        //            Password = "swn",
        //            Claims = new List<Claim>
        //            {
        //                new Claim(JwtClaimTypes.GivenName, "mehmet"),
        //                new Claim(JwtClaimTypes.FamilyName, "ozkaya")
        //            }
        //        }
        //    };
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {

            new TestUser
            {
                SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                Username = "Mick",
                Password = "MickPassword",
                Claims = new List<Claim>
                {
                    new Claim("given_name", "Mick"),
                    new Claim("family_name", "Mining")
                }
            },
            new TestUser
            {
                SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                Username = "Jane",
                Password = "JanePassword",
                Claims = new List<Claim>
                {
                    new Claim("given_name", "Jane"),
                    new Claim("family_name", "Downing")
                }
            }
        };

        }

    }
}
