using Products.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.ProductQATests
{
    public class QATestDTO
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        public string Batch { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float Size { get; set; }

        [Required]
        public string? Observations { get; set; }

        [Required]
        public MaterialType MaterialType { get; set; }
    }
}
