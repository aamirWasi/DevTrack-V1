using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        // GET: api/<KeyboardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<KeyboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KeyboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KeyboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KeyboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
