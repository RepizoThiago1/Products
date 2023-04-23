using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ISalesOrderService
    {
        SalesOrder CreatePurchaseOrder(SalesOrderDTO purchaseOrderDTO);
        SalesOrder GetPurchaseOrder(int id);
        IEnumerable<SalesOrder> GetAllOrders();
    }
}
