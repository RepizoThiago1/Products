using Products.Domain.Enums;

namespace Products.Domain.DTO.PurchaseOrder
{
    public class PurchaseOrderRequestDTO
    {
        public CustomerOrderRequestDTO Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<PurchaseOrderProductsDTO> Products { get; set; }
    }
}
