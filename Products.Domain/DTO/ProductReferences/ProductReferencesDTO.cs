using Products.Domain.Enums;

namespace Products.Domain.DTO.Reference
{
    public class ProductReferencesDTO
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public float MaximumWeightAllowed { get; set; }
        public float MinimumWeightAllowed { get; set; }
        public float MaximumSizeAllowed { get; set; }
        public float MinimumSizeAllowed { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}
