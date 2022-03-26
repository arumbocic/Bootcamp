using System;
using System.Collections.Generic;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;

namespace TractorShop.Service
{
    public class CustomerService : ICustomerService
    {
        public List<CustomerEntity> GetAll()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<CustomerEntity> customers = customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity GetById(Guid Id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerEntity customerEntity = customerRepository.GetById(Id);
            return customerEntity;
        }

        public void Post(CustomerEntity postCustomer)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.Post(postCustomer);
        }

        public void UpdateById(Guid Id, CustomerEntity updateCustomer)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.UpdateById(Id, updateCustomer);
        }

        public void DeleteById(Guid Id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteById(Id);
        }
    }
}
