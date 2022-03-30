using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorModel.Common
{
    public class Sorting : ISorting
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }

        public Sorting(string sortBy, string sortOrder = "ASC")
        {
            SortBy = sortBy;
            SortOrder = sortOrder;
        }
    }
}
