using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorModel.Common
{
    public class Paging : IPaging
    {
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }

        public Paging(int pageNumber, int recordsPerPage)
        {
            PageNumber = pageNumber;
            RecordsPerPage = recordsPerPage;
        }
    }
}
