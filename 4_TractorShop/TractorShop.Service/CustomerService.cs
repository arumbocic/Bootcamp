using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Repository.Common;
using TractorShop.Service.Common;

namespace TractorShop.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository CustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }
        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            List<CustomerEntity> customers = await CustomerRepository.GetAllAsync();
            return customers;
        }

        public async Task<CustomerEntity> GetByIdAsync(Guid Id)
        {
            CustomerEntity customerEntity = await CustomerRepository.GetByIdAsync(Id);
            return customerEntity;
        }

        public async Task PostAsync(CustomerEntity postCustomer)
        {
            await CustomerRepository.PostAsync(postCustomer);
        }

        public async Task UpdateByIdAsync(Guid Id, CustomerEntity updateCustomer)
        {
            await CustomerRepository.UpdateByIdAsync(Id, updateCustomer);
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            await CustomerRepository.DeleteByIdAsync(Id);
        }
    }
}
