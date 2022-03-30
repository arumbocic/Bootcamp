using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorModel.Common
{
    public class FilterTractorModel : IFilterTractorModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }

        public FilterTractorModel(int id, string model, int brandId)
        {
            Id = id;
            Model = model;
            BrandId = brandId;
        }
    }
}
