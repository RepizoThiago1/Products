using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IPurchaseOrderService
    {
        public List<Product> ProductList { get; set; }
        public decimal TotalPrice { get; set; }
        PurchaseOrder CreatePurchaseOrder(PurchaseOrderRequestDTO purchaseOrderDTO);
        PurchaseOrder GetPurchaseOrder(int id);
        IEnumerable<PurchaseOrder> GetAllOrders();
    }
}
