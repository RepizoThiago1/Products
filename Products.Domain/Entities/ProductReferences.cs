﻿using Products.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities
{
    public class ProductReferences
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public float MaximumWeightAllowed { get; set; }
        public float MinimumWeightAllowed { get; set; }
        public float MaximumSizeAllowed { get; set; }
        public float MinimumSizeAllowed { get; set; }
        public MaterialType MaterialType { get; set; }
        #region FK's
        public virtual Product? Product { get; set; }
        [ForeignKey("Product")]
        public virtual int? ProductId { get; set; }
        #endregion
    }
}
