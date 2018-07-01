using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IotCentral.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IotCentral.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        /// <summary>
        /// Receives a Message
        /// Is Message Valid
        /// Add to process pipeline
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]MessageDto message)
        {
            
            return Ok();
        }
    }
}