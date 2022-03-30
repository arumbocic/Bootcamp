using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorModel.Common;
using TractorShop.Model;

namespace TractorShop.Service.Common
{
    public interface ICustomerService
    {
        Task<List<CustomerEntity>> GetAllAsync(Sorting sorting, Paging paging, FilterCustomer filtering);
        Task<CustomerEntity> GetByIdAsync(Guid Id);
        Task PostAsync(CustomerEntity postCustomer);
        Task UpdateByIdAsync(Guid Id, CustomerEntity updateCustomer);
        Task DeleteByIdAsync(Guid Id);
    }
}

