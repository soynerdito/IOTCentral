using IotCentral.Storage;
using IotCentral.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IotCentral.Controllers
{
    [Route("api/device")]
    public class Device2Controller : StorageController<Device>
    {
        public Device2Controller(IStorage<Device> storage) : base(storage)
        {
        }
    }
}
