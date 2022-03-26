using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShop.Model;
using TractorShop.Service;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        #region GetAll 

        // GET api/values
        [HttpGet]
        [Route("customer/getall")]
        public HttpResponseMessage GetAll()
        {
            CustomerService customerService = new CustomerService();
            List<CustomerEntity> customers = customerService.GetAll();
            List<CustomerREST> customersRest = new List<CustomerREST>();

            foreach (var customer in customers)
            {
                CustomerREST customerRest = new CustomerREST();

                customerRest.FirstName = customer.FirstName;
                customerRest.LastName = customer.LastName;
                customerRest.Address = customer.Address;

                customersRest.Add(customerRest);
            }

            if (customersRest.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, customersRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list of customers is empty!");
            }
        }
        #endregion

        #region GetById
        // GET api/values/5
        //TODO: Postavi stupac Model na Unique values

        [HttpGet]
        [Route("customer/get/{id}")]
        public HttpResponseMessage GetById(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                CustomerService customerService = new CustomerService();
                CustomerEntity customerEntity = customerService.GetById(Id);

                if (customerEntity != null)
                {
                    CustomerREST customerRest = new CustomerREST();

                    customerRest.FirstName = customerEntity.FirstName;
                    customerRest.LastName = customerEntity.LastName;
                    customerRest.Address = customerEntity.Address;

                    return Request.CreateResponse(HttpStatusCode.OK, customerRest);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no customer with id: {Id}");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id is not valid.");
            }
        }
        #endregion

        #region Create
        // POST api/values
        [HttpPost]
        [Route("customer/set")]
        public HttpResponseMessage Post(CustomerREST postCustomer)
        {
            if (postCustomer == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
            }
            else
            {
                if (string.IsNullOrEmpty(postCustomer.FirstName) || string.IsNullOrEmpty(postCustomer.LastName) || string.IsNullOrEmpty(postCustomer.Address))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check if you provided all required properties for an object.");
                }
                else
                {
                    CustomerEntity customerEntity = new CustomerEntity();
                    CustomerService customerService = new CustomerService();

                    customerEntity.FirstName = postCustomer.FirstName;
                    customerEntity.LastName = postCustomer.LastName;
                    customerEntity.Address = postCustomer.Address;

                    customerService.Post(customerEntity);
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer is created.");

                    //TODO: provjeriti kako dohvatiti ubačeni podatak iz baze.
                    //U slučaju kada samo "customerEntity ubacim kao parametar za vraćanje,
                    //vrati mi objekt s neispravnim Id i Catalogue kodom.
                }
            }
        }
        #endregion

        #region Update
        // PUT api/values/5
        //TODO: napraviti handleanje situacija kad ne pošaljem određenu vrijednost propertyja
        //(npr. nisam poslao vrijednost za "LastName")

        [HttpPut]
        [Route("customer/update/{id}")]
        public HttpResponseMessage UpdateById(Guid Id, CustomerREST updateCustomer)
        {
            if (Id != Guid.Empty && updateCustomer != null)
            {
                CustomerService customerService = new CustomerService();
                CustomerEntity customerHelp = customerService.GetById(Id);

                if (customerHelp != null)
                {
                    CustomerEntity customerEntity = new CustomerEntity();

                    customerEntity.FirstName = updateCustomer.FirstName;
                    customerEntity.LastName = updateCustomer.LastName;
                    customerEntity.Address = updateCustomer.Address;

                    customerService.UpdateById(Id, customerEntity);
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer is updated!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no customer with id: {Id}");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id is not valid and/or object is not provided.");
            }
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete]
        [Route("customer/delete/{id}")]
        public HttpResponseMessage DeleteById(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                CustomerService customerService = new CustomerService();
                CustomerEntity customerHelp = customerService.GetById(Id);

                if (customerHelp != null)
                {
                    customerService.DeleteById(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer is deleted!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Customer with id: {Id} doesn't exist!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Didn't provide an Id!");
            }
        }
        #endregion
    }
}
