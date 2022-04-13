using System;

namespace TractorShop.Model.Common
{
    public interface ICustomerEntity
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
    }
}
