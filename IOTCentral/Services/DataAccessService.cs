using IotCentral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Services
{
    public abstract class DataAccessService
    {
        protected readonly ApplicationDbContext DbContext;

        protected DataAccessService(ApplicationDbContext db)
        {
            DbContext = db;
        }
    }
}
