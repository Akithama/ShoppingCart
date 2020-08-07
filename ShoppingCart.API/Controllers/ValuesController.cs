using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "API", "Working" };
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> list = new List<string>(){ "API", "Working" };

            return list;
            //return NotFound("Not Found");
        }

        //// http://localhost:4000/Values/category?=id=2
        //[HttpGet("category")]
        //public string Get(int id)
        //{
        //    return "With Para";
        //}

        //[HttpGet]
        //public string Get()
        //{
        //    return "No para";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
