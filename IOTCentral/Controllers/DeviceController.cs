using IotCentral.Storage;
using IotCentral.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IotCentral.Controllers
{
    [Route("api/device3")]
    [ApiController]
    public class DeviceController : StorageHandler<Device>
    {
        public DeviceController(IStorage<Device> storage) : base(storage)
        {
        }
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok();
        }

    }
}
