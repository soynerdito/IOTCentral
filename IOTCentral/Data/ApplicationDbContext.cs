using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTCentral.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IotDevice> Devices { get; set; }
        public DbSet<DeviceGroup> DeviceGroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
