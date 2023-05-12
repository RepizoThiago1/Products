using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ISalesOrderService
    {
        SalesOrder CreateSaleOrder(SalesOrderDTO purchaseOrderDTO);
        SalesOrder GetSaleOrder(int id);
        IEnumerable<SalesOrder> GetAllOrders();
    }
}
