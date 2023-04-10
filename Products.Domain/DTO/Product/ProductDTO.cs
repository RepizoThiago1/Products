namespace Products.Domain.DTO.Product
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = false;
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string Note { get; set; }
    }
}
