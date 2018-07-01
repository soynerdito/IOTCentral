using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IotCentral.Data;

namespace IotCentral.Data
{
    /// <summary>
    /// Copied from Identitycontext, just wanted to specify my own IdentityClass
    /// The correct way to do? who knows but it is a way to do so
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<IotDevice> Devices { get; set; }
        public DbSet<DeviceGroup> DeviceGroups { get; set; }
        public DbSet<DeviceToken> DeviceTokens { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

    }

}
