using FirstWebAplication_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebAplication_WebApi.Controllers
{
    public class MachineController : ApiController
    {
        static List<Machine> machines = new List<Machine>()
        {
            new Machine ("tractor", "CaseIH"),
            new Machine ("combine", "Deutz Fahr")
        };

        #region Get
        // GET api/values
        [HttpGet]
        [Route("machine/getall")]
        public HttpResponseMessage GetAll()
        {
            if (machines == null || !machines.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty or not existing!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, machines);
        }
        #endregion

        #region GetId
        // GET api/values/5
        [HttpGet]
        [Route("machine/get/{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            //nisam siguran kako provjeriti situaciju kada u requestu ne pošaljem id
            if (id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid id.");
            }
            
            var machine = machines.Find(r => r.Id == id);

            if (machine == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, machine);
        }
        #endregion

        #region Post
        // POST api/values
        [HttpPost]
        [Route("machine/set")]
        public HttpResponseMessage Post(Machine machine)
        {
            if (machine != null)
            {
                if (machines != null)
                {
                    machines.Add(machine);
                    return Request.CreateResponse(HttpStatusCode.Created, machines);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list does not exist!");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
        }
        #endregion

        #region Put
        // PUT api/values/5
        [HttpPut]
        [Route("machine/update/{id}")]
        public HttpResponseMessage PutById(Guid id, Machine machine)
        {
            //nisam siguran kako provjeriti situaciju kada u requestu ne pošaljem id
            if (id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid id.");
            }

            if (machines != null)
            {
                var item = machines.Find(r => r.Id == id);

                if (machine != null && item != null)
                {
                    item.Id = id;
                    item.Type = machine.Type;
                    item.Brand = machine.Brand;

                    return Request.CreateResponse(HttpStatusCode.OK, item);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list does not exist!");
            }
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete]
        [Route("machine/delete/{id}")]
        public HttpResponseMessage DeleteById(Guid id)
        {
            //nisam siguran kako provjeriti situaciju kada u requestu ne pošaljem id
            if (id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an non existing id!");
            }

            var item = machines.Find(r => r.Id == id);

            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
            }

            if (machines != null)
            {
                machines.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, machines);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list does not exist!");
            }
            
        }
        #endregion
    }
}
