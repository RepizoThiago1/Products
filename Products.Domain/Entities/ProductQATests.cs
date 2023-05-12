using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities
{
    public class ProductQATests
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public bool IsWeightAproved { get; set; }
        public bool IsSizeAproved { get; set; }
        public string? Observations { get; set; }
        public string? Status { get; set; }
        
        #region FK
        [ForeignKey("ProductReferences")]
        public virtual int? ProductReferencesId { get; set; }  
        public virtual ProductReferences? ProductReferences { get; set; }
        [ForeignKey("Product")]
        public virtual int? ProductId { get; set; } 
        public virtual Product? Product { get; set; }
        #endregion
    }
}
