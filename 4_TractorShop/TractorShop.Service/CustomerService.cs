using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;

namespace TractorShop.Service
{
    public class CustomerService : ICustomerService
    {
        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<CustomerEntity> customers = await customerRepository.GetAllAsync();
            return customers;
        }

        public async Task<CustomerEntity> GetByIdAsync(Guid Id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerEntity customerEntity = await customerRepository.GetByIdAsync(Id);
            return customerEntity;
        }

        public async Task PostAsync(CustomerEntity postCustomer)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            await customerRepository.PostAsync(postCustomer);
        }

        public async Task UpdateByIdAsync(Guid Id, CustomerEntity updateCustomer)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            await customerRepository.UpdateByIdAsync(Id, updateCustomer);
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            await customerRepository.DeleteByIdAsync(Id);
        }
    }
}
