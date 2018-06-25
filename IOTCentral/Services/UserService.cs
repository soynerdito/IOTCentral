using IOTCentral.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTCentral.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext DbContext;

        public UserService(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public Organization GetUserOrganization( User user)
        {
            return DbContext.Organization.Where(x => x.Users.Contains( user))?.FirstOrDefault();
        }
    }
}
