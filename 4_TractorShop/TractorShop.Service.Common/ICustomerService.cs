using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorModel.Common;
using TractorShop.Model;
using TractorShop.Model.Common;

namespace TractorShop.Service.Common
{
    public interface ICustomerService
    {
        Task<List<ICustomerEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterCustomer filtering);
        Task<ICustomerEntity> GetByIdAsync(Guid Id);
        Task PostAsync(ICustomerEntity postCustomer);
        Task UpdateByIdAsync(Guid Id, ICustomerEntity updateCustomer);
        Task DeleteByIdAsync(Guid Id);
    }
}

