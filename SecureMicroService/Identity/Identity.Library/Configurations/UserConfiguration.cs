using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Library.Configurations
{
    public static class UserConfiguration
    {
        public static IEnumerable<TestUser> GetTestUsers()
        {

            return new List<TestUser>
            {
                new TestUser{
                    SubjectId = "818727",
                    Username = "sowad",
                    Password = "123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Sowad Islam"),
                        new Claim(JwtClaimTypes.GivenName, "Sowad"),
                        new Claim(JwtClaimTypes.FamilyName, "Islam"),
                        new Claim(JwtClaimTypes.Email, "sowad@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                    }
                },
                new TestUser{
                    SubjectId = "88421113",
                    Username = "bob",
                    Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "bob@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "somewhere")
                    }
                }
            };

        }

    }
}

