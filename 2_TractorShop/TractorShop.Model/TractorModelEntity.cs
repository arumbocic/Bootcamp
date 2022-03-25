using System;
using TractorShop.Model.Common;

namespace TractorShop.Model
{
    public class TractorModelEntity : ITractorModelEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Guid Code { get; set; }
        public int BrandId { get; set; }
    }
}
