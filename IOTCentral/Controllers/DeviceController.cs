using IOTCentral.Storage;
using IOTCentral.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IOTCentral.Controllers
{
    [Route("api/device")]
    public class DeviceController : StorageController<Device>
    {
        public DeviceController(IStorage<Device> storage) : base(storage)
        {
        }
    }
}
