using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
    public class DefaultRolesDataSeed
    {
        public static IdentityRole[] SeedData()
        {
            var administrator = new IdentityRole() { Id = "1", Name = "Administrator", NormalizedName = "ADMINISTRATOR" };
            var noRoleUser = new IdentityRole() { Id = "2", Name = "NoRoleUser", NormalizedName = "NoRoleUser" };



            return new IdentityRole[] { administrator, noRoleUser };
        }
    }
}
