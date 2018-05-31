using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batch.Processor.Tests.SampleAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch.Processor.Tests.SampleAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // POST api/User
        [HttpPost]
        public ActionResult Post([FromBody]User user)
        {
            return Ok();
        }

        public User Get()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Name = "Jonny",
                Age = new Random().Next(0, 100)
            };
        }
    }
}