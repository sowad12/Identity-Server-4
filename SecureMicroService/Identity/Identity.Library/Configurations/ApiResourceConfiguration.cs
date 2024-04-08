using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.Library.Configurations
{
    public static class ApiResourceConfiguration
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                   new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };
        }

    }
}

