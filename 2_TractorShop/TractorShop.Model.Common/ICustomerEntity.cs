using System;

namespace TractorShop.Model.Common
{
    public interface ICustomerEntity
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }

        //List<TractorModel> OwnedTractors { get; set; }
    }

    //public class Address
    //{
    //    string Country { get; set; }
    //    string City { get; set; }
    //    string ZipCode { get; set; }
    //    string Street { get; set; }
    //    string StreetNumber { get; set; }
    //}
}
