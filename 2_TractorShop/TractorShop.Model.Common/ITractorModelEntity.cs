using System;

namespace TractorShop.Model.Common
{
    public interface ITractorModelEntity
    {
        int Id { get; set; }
        string Model { get; set; }
        Guid CatalogueCode { get; set; }
        int BrandId { get; set; }
    }
}
