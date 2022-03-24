using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationEmployees
{
    public class Workers : Employees
    {
        public int YearsOfExperience { get; set; }
        public List<string> Technologies { get; set; }

        public override string GetAddress()
        {
            return ($" \nState: {Address.State} \nCity: {Address.City} \nZipCode: {Address.ZipCode} \nStreet Name: {Address.StreetName} \nStreet Number: {Address.StreetNumber}");
        }
    }
}
