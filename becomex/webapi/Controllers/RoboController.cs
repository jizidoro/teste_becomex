using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi.Controllers
{
    public class RoboController : ApiController
    {
        // GET: api/Robo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Robo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Robo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Robo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Robo/5
        public void Delete(int id)
        {
        }
    }
}
