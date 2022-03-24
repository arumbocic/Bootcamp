using System;

namespace TractorShopWebApi.Models
{
    public class TractorModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public TractorModel(string type, string brand)
        {
            Id = Guid.NewGuid();
            Type = type;
            Brand = brand;
        }

        public TractorModel(Guid id, string type, string brand)
        {
            Id = id;
            Type = type;
            Brand = brand;
        }
    }
}