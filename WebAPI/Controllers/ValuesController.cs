using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.IServices;
using WebAPI.IRepository;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private IPersonServices Service;

        public ValuesController(IPersonServices  _service)
        {
            Service = _service;
        }
      
        // GET api/values
        public IHttpActionResult Get()
        {
            var list = Service.GetAll();
            // return new string[] { "value1", "value2" };
            return Ok(list);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
