using System;

namespace TractorShopWebApi.Models
{
    public class TractorModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Guid Code { get; set; }
        public int BrandId { get; set; }
    }
}