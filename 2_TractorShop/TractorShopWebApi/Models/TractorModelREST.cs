using System;

namespace TractorShopWebApi.Models
{
    public class TractorModelREST
    {
        public string Model { get; set; }
        public Guid Code { get; set; }
        public int BrandId { get; set; }
    }
}