using IotCentral.Storage;
using IotCentral.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IotCentral.Controllers
{

    public class StorageController<T> : Controller
        where T: IEntity
    {
        private IStorage<T> _Storage;

        public StorageController(IStorage<T> storage)
        {
            _Storage = storage;
        }

        [HttpPost]
        public IActionResult Post([FromBody] T payload)
        {
            if( !ModelState.IsValid)
            {
                return BadRequest(ModelState);                
            }
            var result = _Storage.Add(payload);
            return Ok(payload);
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult Get([FromRoute]Guid? id= null)
        {

            var record = _Storage.Get(id);
            if(record!= null)
            {
                return Ok(record);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}