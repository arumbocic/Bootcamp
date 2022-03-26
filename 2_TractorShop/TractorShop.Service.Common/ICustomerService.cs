using System;
using System.Collections.Generic;
using TractorShop.Model;

namespace TractorShop.Service.Common
{
    public interface ICustomerService
    {
        List<CustomerEntity> GetAll();
        CustomerEntity GetById(Guid Id);
        void Post(CustomerEntity postCustomer);
        void UpdateById(Guid Id, CustomerEntity updateCustomer);
        void DeleteById(Guid Id);
    }
}

