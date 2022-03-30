using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TractorModel.Common;
using TractorShop.Model;
using TractorShop.Model.Common;
using TractorShop.Service;
using TractorShop.Service.Common;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService CustomerService;
        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        #region GetAll 

        // GET api/values
        [HttpGet]
        [Route("customer/getall")]
        public async Task<HttpResponseMessage> GetAllAsync(string firstName, string lastName, string address, int? pageNumber, int? recordsPerPage, string sortBy, string sortOrder)
        {
            ISorting sorting = new Sorting(sortBy ?? "FirstName", sortOrder);
            IPaging paging = new Paging(pageNumber, recordsPerPage);
            IFilterCustomer filtering = new FilterCustomer(firstName, lastName, address);

            List<ICustomerEntity> customers = await CustomerService.GetAllAsync(sorting, paging, filtering);
            List<ICustomerRest> customersRest = new List<ICustomerRest>();

            foreach (var customer in customers)
            {
                ICustomerRest customerRest = new CustomerRest();

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
        public async Task<HttpResponseMessage> GetByIdAsync(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                ICustomerEntity customerEntity = await CustomerService.GetByIdAsync(Id);

                if (customerEntity != null)
                {
                    ICustomerRest customerRest = new CustomerRest();

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
        public async Task<HttpResponseMessage> PostAsync(ICustomerRest postCustomer)
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
                    ICustomerEntity customerEntity = new CustomerEntity();

                    customerEntity.FirstName = postCustomer.FirstName;
                    customerEntity.LastName = postCustomer.LastName;
                    customerEntity.Address = postCustomer.Address;

                    await CustomerService.PostAsync(customerEntity);
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
        public async Task<HttpResponseMessage> UpdateByIdAsync(Guid Id, ICustomerRest updateCustomer)
        {
            if (Id != Guid.Empty && updateCustomer != null)
            {
                ICustomerEntity customerEntity = await CustomerService.GetByIdAsync(Id);

                if (customerEntity != null)
                {
                    if (!string.IsNullOrEmpty(updateCustomer.FirstName))
                    {
                        customerEntity.FirstName = updateCustomer.FirstName;
                    }
                    if (!string.IsNullOrEmpty(updateCustomer.LastName))
                    {
                        customerEntity.LastName = updateCustomer.LastName;
                    }
                    if (!string.IsNullOrEmpty(updateCustomer.Address))
                    {
                        customerEntity.Address = updateCustomer.Address;
                    }

                    await CustomerService.UpdateByIdAsync(Id, customerEntity);
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
        public async Task<HttpResponseMessage> DeleteByIdAsync(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                ICustomerEntity customerEntity = await CustomerService.GetByIdAsync(Id);

                if (customerEntity != null)
                {
                    await CustomerService.DeleteByIdAsync(Id);
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
