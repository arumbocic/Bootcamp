using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationEmployees
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string GetAddress();
    }
}
