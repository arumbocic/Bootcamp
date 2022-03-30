﻿using System;

namespace TractorShopWebApi.Models
{
    public class TractorModelRest : ITractorModelRest
    {
        public string Model { get; set; }
        public Guid CatalogueCode { get; set; }
        public int BrandId { get; set; }
    }
}