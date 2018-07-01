using IotCentral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Services
{
    public interface IDeviceService
    {
        bool Initialize(IotDevice device);
        bool OnMessageReceived(MessagePayload message);
    }
}
