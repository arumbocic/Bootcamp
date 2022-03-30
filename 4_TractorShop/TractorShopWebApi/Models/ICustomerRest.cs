namespace TractorShopWebApi.Models
{
    public interface ICustomerRest
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
    }
}