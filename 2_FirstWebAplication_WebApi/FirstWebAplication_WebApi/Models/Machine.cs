using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebAplication_WebApi.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public Machine(string type, string brand)
        {
            Id = Guid.NewGuid();
            Type = type;
            Brand = brand;
        }

        public Machine(Guid id, string type, string brand)
        {
            Id = id;
            Type = type;
            Brand = brand;
        }
    }
}