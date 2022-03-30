using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TractorShopWebApi.Models
{
    public class CustomerRest : ICustomerRest
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public List<TractorModel> OwnedTractors { get; set; }
    }

    //public class Address
    //{
    //    public string Country { get; set; }
    //    public string City { get; set; }
    //    public string ZipCode { get; set; }
    //    public string Street { get; set; }
    //    public string StreetNumber { get; set; }
    //}
}