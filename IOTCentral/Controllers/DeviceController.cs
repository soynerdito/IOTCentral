using IotCentral.Storage;
using IotCentral.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IotCentral.Controllers
{
    [Route("api/device")]
    public class DeviceController : StorageController<Device>
    {
        public DeviceController(IStorage<Device> storage) : base(storage)
        {
        }
    }
}
