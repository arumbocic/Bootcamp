using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorModel.Common
{
    public class Pagination
    {
        public int PageNumber { get; set; } = 1;
        public int RecordsPerPage { get; set; }
    }
}
