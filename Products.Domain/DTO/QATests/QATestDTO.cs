using Products.Domain.Enums;

namespace Products.Domain.DTO.ProductQATests
{
    public class QATestDTO
    {
        public string SKU { get; set; }
        public string Batch { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public string? Observations { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}
