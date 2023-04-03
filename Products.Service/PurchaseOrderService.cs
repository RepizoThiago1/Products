using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;
        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }
        public PurchaseOrder AddPurchaseOrder(CreatePurchaseOrderDTO poDTO)
        {
            /* FALTA CRIAR
             * Criar logica de implementação de 
             *    Criar o produto dentro do pedido
             *    Criar a logica da query de produtos
             *    Associar o cliente
             *    Criar a fila com a query
             */

            var dateTime = DateTime.Now;
            var productList = _repository.GetProductsToOrder("");

            Queue<Product> products = new(productList);

            PurchaseOrder po = new()
            {
                OrderNumber = $"BRSP{dateTime.Year}{dateTime.Day}{dateTime.Month}",
                
            };

            return po;
        }

        public IEnumerable<PurchaseOrder> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder GetPurchaseOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
