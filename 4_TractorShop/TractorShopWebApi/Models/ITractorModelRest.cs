using System;

namespace TractorShopWebApi.Models
{
    public interface ITractorModelRest
    {
        string Model { get; set; }
        Guid CatalogueCode { get; set; }
        int BrandId { get; set; }
    }
}