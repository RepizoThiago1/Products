﻿using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IPurchaseOrderService
    {
        PurchaseOrder AddPurchaseOrder(PurchaseOrderDTO purchaseOrderDTO);
        PurchaseOrder GetPurchaseOrder(int id);
        IEnumerable<PurchaseOrder> GetAllOrders();
    }
}
