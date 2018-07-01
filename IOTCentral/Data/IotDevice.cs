using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Data
{
    public class IotDevice : OwnedModel
    {
        
        public string Name { get; set; }
        public EnumDeviceType DeviceType { get; set; }
        public DeviceGroup Group { get; set; }


    }
}
