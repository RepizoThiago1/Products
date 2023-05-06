﻿using Products.Domain.Enums;

namespace Products.Domain.DTO.ProductQATests
{
    public class ProductQATestsDTO
    {
        public string SKU { get; set; }
        public string Batch { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}