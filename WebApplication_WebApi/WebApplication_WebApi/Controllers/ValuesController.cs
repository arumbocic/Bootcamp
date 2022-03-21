using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<Machine> machines = new List<Machine>()
        {
            new Machine
            {
                Id = 1,
                Type = "tractor",
                Brand = "John Deere"
            },
            new Machine
            {
                Id = 2,
                Type = "tractor",
                Brand = "Case"
            },
            new Machine
            {
                Id = 3,
                Type = "combine",
                Brand = "Deutz Fahr"
            }
        };

        // GET api/values
        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            if (machines == null || machines.Count == 0)
            {
                HttpResponseMessage responseMessageBad = Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
                return responseMessageBad;
            }
            HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, machines);
            return responseMessageOk;
        }

        // GET api/values/5
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var response = machines.Find(r => r.Id == id);

            if (response == null)
            {
                HttpResponseMessage responseMessageBad = Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
                return responseMessageBad;
            }
            HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, response);
            return responseMessageOk;
        }

        // POST api/values
        [HttpPost]
        [Route("set")]
        public HttpResponseMessage Post(Machine machine)
        {
            if (machines.Count > 0)
            {
                machine.Id = machines.Max(x => x.Id) + 1;
            }
            else
            {
                machine.Id = 1;
            }
            
            machines.Add(machine);
            HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.Created, machines);
            return responseMessageOk;
        }

        // PUT api/values/5
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutById(int id, Machine machine)
        {
            var item = machines.Find(r => r.Id == id);

            item.Id = machine.Id;
            item.Type = machine.Type;
            item.Brand = machine.Brand;

            if (item == null)
            {
                HttpResponseMessage responseMessageBad = Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
                return responseMessageBad;
            }
            HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, machines);
            return responseMessageOk;
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteById(int id)
        {
            var item = machines.Find(r => r.Id == id);

            machines.Remove(item);

            if (item == null)
            {
                HttpResponseMessage responseMessageBad = Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
                return responseMessageBad;
            }
            HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, machines);
            return responseMessageOk;
        }
    }

    public class Machine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
    }
}
