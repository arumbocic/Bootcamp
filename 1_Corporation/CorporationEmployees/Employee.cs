using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationEmployees
{
    public abstract class Employee : IEmployee
    {
        protected string OIB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }

        public virtual string GetAddress()
        {
            return ($" \nState: {Address.State} \nCity: {Address.City} \nZipCode: {Address.ZipCode}");
        }
    }
}
