using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorModel.Common;
using TractorShop.Model;
using TractorShop.Model.Common;
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
        public async Task<List<ICustomerEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterCustomer filtering)
        {
            List<ICustomerEntity> customers = await CustomerRepository.GetAllAsync(sorting, paging, filtering);
            return customers;
        }

        public async Task<ICustomerEntity> GetByIdAsync(Guid Id)
        {
            ICustomerEntity customerEntity = await CustomerRepository.GetByIdAsync(Id);
            return customerEntity;
        }

        public async Task PostAsync(ICustomerEntity postCustomer)
        {
            await CustomerRepository.PostAsync(postCustomer);
        }

        public async Task UpdateByIdAsync(Guid Id, ICustomerEntity updateCustomer)
        {
            await CustomerRepository.UpdateByIdAsync(Id, updateCustomer);
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            await CustomerRepository.DeleteByIdAsync(Id);
        }
    }
}
