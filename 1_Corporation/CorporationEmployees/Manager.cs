using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationEmployees
{
    public class Manager : Employee
    {
        public int NumberOfEmployeesManaged { get; set; }
        public Guid ManagerId { get; set; }
    }
}
