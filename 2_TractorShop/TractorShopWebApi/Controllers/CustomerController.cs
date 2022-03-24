using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        //// GET api/values
        //[HttpGet]
        //[Route("customer/getall")]
        //public HttpResponseMessage GetAll()
        //{
        //    if (customers == null || customers.Count == 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, customers);
        //}

        //// GET api/values/2
        //[HttpGet]
        //[Route("customer/get/{id}")]
        //public HttpResponseMessage GetById(Guid id)
        //{
        //    var response = customers.Find(r => r.Id == id);

        //    if (response == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, response);
        //}

        //// POST api/values
        //[HttpPost]
        //[Route("customer/set")]
        //public HttpResponseMessage Post(Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
        //    }
        //    customers.Add(customer);
        //    return Request.CreateResponse(HttpStatusCode.Created, customers);
        //}


        //// PUT api/values/2
        //[HttpPut]
        //[Route("customer/update/{id}")]
        //public HttpResponseMessage PutById(Guid id, Customer customer)
        //{
        //    var item = customers.Find(r => r.Id == id);

        //    item.Id = customer.Id;
        //    item.FirstName = customer.FirstName;
        //    item.LastName = customer.LastName;
        //    item.Address = customer.Address;
        //    item.OwnedTractors = customer.OwnedTractors;


        //    if (item == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, customers);
        //}

        //// DELETE api/values/2
        //[HttpDelete]
        //[Route("customer/delete/{id}")]
        //public HttpResponseMessage DeleteById(Guid id)
        //{

        //    if (id == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an non existing id!");
        //    }

        //    var item = customers.Find(r => r.Id == id);
        //    customers.Remove(item);

        //    if (item == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, customers);

        //}
    }
}
