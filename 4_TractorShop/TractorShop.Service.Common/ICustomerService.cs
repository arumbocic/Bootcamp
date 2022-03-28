using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorShop.Model;

namespace TractorShop.Service.Common
{
    public interface ICustomerService
    {
        Task<List<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity> GetByIdAsync(Guid Id);
        Task PostAsync(CustomerEntity postCustomer);
        Task UpdateByIdAsync(Guid Id, CustomerEntity updateCustomer);
        Task DeleteByIdAsync(Guid Id);
    }
}

