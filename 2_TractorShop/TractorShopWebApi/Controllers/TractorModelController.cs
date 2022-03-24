using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class TractorModelController : ApiController
    {
        static List<TractorModel> machines = new List<TractorModel>()
        {
            new TractorModel ("tractor", "John Deere"),
            new TractorModel ("tractor", "CaseIH"),
            new TractorModel ("tractor", "New Holland")
        };

        // GET api/values
        [HttpGet]
        [Route("tractormodel/getall")]
        public HttpResponseMessage GetAll()
        {
            if (machines == null || machines.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, machines);
        }

        // GET api/values/5
        [HttpGet]
        [Route("tractormodel/get/{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            var response = machines.Find(r => r.Id == id);

            if (response == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST api/values
        [HttpPost]
        [Route("tractormodel/set")]
        public HttpResponseMessage Post(TractorModel machine)
        {
            if (machine == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
            }
            machines.Add(machine);
            return Request.CreateResponse(HttpStatusCode.Created, machines);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("tractormodel/update/{id}")]
        public HttpResponseMessage PutById(Guid id, TractorModel machine)
        {
            var item = machines.Find(r => r.Id == id);

            item.Id = machine.Id;
            item.Type = machine.Type;
            item.Brand = machine.Brand;

            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, machines);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("tractormodel/delete/{id}")]
        public HttpResponseMessage DeleteById(Guid id)
        {

            if (id == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an non existing id!");
            }

            var item = machines.Find(r => r.Id == id);
            machines.Remove(item);

            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, machines);

        }
    }
}
