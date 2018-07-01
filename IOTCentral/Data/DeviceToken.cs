using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Data
{
    
    public class DeviceToken : OwnedModel
    {
        /// <summary>
        /// This is who create it
        /// </summary>
        public int UserId { get; set; }
        public User Owner { get; set; }

        public DateTime? Expiration { get; set; }
        public int TargetDeviceId { get; set; }

    }
}
