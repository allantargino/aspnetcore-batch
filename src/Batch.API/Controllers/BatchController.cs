using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batch.Processor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch.API.Controllers
{
    [Route("api/[controller]")]
    public class BatchController : Controller
    {

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BatchRequest request)
        {

        }
    }
}
