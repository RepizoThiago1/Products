﻿using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Data.Repositories.@base;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Data.Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DataContext context) : base(context)
        {
        }
        public IQueryable<Product> GetProductsToOrder(string query)
        {
            return _context.Products.FromSqlRaw(query);
        }
    }
}
