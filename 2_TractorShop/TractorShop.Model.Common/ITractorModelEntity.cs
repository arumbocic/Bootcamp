using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
