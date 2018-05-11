using IOTCentral.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IOTCentral.Controllers
{
   
    [Produces("application/json")]
    [Route("api/open")]
    public class OpenController : Controller
    {
        private readonly OpenStorage _Storage;

        public OpenController(OpenStorage storage)
        {
            this._Storage = storage;
        }

        [HttpGet]
        [Route("{endpoint}")]
        public IActionResult Target([FromRoute] string endpoint)
        {
            //Get Raw Query
            var query = HttpContext.Request.Query;
            
            var filterFunc = new Func<dynamic, bool>( new MagicFilter(query).Evaluate );
            

            return Ok(_Storage.Get(endpoint, filterFunc));
        }

        

        [HttpPost]
        [Route("{endpoint}")]
        public IActionResult Post([FromRoute]string endpoint, [FromBody] dynamic payload)
        {
            if( _Storage.Add(endpoint, payload))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }            
        }
    }
}