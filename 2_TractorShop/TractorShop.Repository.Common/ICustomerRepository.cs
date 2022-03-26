using System;
using System.Collections.Generic;
using TractorShop.Model;

namespace TractorShop.Repository.Common
{
    public interface ICustomerRepository
    {
        List<CustomerEntity> GetAll();
        CustomerEntity GetById(Guid Id);
        void Post(CustomerEntity postCustomer);
        void UpdateById(Guid Id, CustomerEntity updateCustomer);
        void DeleteById(Guid Id);
    }
}
