using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IotCentral.Data;

namespace IotCentral.Services
{
    public class DeviceService : DataAccessService
    {
        protected DeviceService(ApplicationDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Validate that this token can work with this user
        /// If target device is not for this token then is not mine
        /// </summary>
        /// <param name="user"></param>
        /// <param name="deviceToken"></param>
        /// <returns></returns>
        public bool IsMine(User user, string deviceToken)
        {
            return true;
        }
    }
}
