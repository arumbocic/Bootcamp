using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TractorModel.Common;
using TractorShop.Model;
using TractorShop.Model.Common;

namespace TractorShop.Repository.Common
{
    public interface ICustomerRepository
    {
        Task<List<ICustomerEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterCustomer filtering);
        Task<ICustomerEntity> GetByIdAsync(Guid Id);
        Task PostAsync(ICustomerEntity postCustomer);
        Task UpdateByIdAsync(Guid Id, ICustomerEntity updateCustomer);
        Task DeleteByIdAsync(Guid Id);
    }
}
