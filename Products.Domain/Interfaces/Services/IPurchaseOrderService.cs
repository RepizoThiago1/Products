using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IPurchaseOrderService
    {
        PurchaseOrder CreatePurchaseOrder(PurchaseOrderRequestDTO purchaseOrderDTO);
        //PurchaseOrder GetPurchaseOrder(int id);
        //IEnumerable<PurchaseOrder> GetAllOrders();
    }
}
