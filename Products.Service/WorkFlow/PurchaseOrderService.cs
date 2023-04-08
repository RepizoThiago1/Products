using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;

        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrderDTO poDTO)
        {
            var dateTime = DateTime.Now;

            Queue<Product> productListFIFO = CreateProductToOrder(poDTO);
            var totalPrice = CalculatePrice(poDTO.Products);

            PurchaseOrder po = new()
            {
                PaymentMethod = poDTO.PaymentMethod,
                OrderNumber = $"BRSOB{dateTime.Year}{dateTime.Day}{dateTime.Month}",
                TotalPrice = totalPrice
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
        private Queue<Product> CreateProductToOrder(PurchaseOrderDTO poDTO)
        {
            var poDTOProducts = poDTO.Products;

            Queue<Product> productsFIFO = new();

            foreach (var product in poDTOProducts)
            {
                var item = _repository.QueryOrder($"SELECT * FROM [dbo].Products WHERE name = '{product.Name}' AND Quantity > 0 AND IsActive = 1").FirstOrDefault();
                if (item != null)
                {
                    productsFIFO.Enqueue(item);
                    UpdateDatabaseProducts(poDTOProducts);
                }

            }

            return productsFIFO;
        }
        private void UpdateDatabaseProducts(List<Product> poList)
        {
            foreach (var product in poList)
            {
                _repository.QueryOrder($"UPDATE [dbo].Products SET Quantity = (SELECT Quantity FROM [dbo].Products WHERE id = {product.Id}) - {product.Quantity}");
            }
        }
        private decimal CalculatePrice(List<Product> poList)
        {
            decimal totalPrice = 0;
            foreach (var product in poList)
            {
                var priceQuery = _repository.QueryOrder($"SELECT SUM({product.Quantity} * {product.Price}) AS TotalPrice FROM [dbo].Products" +
                                                        $"WHERE name = '{product.Name}' " +
                                                        $"AND Quantity > 0 " +
                                                        $"AND IsActive = 1").ToList();

                totalPrice += priceQuery.Sum(x => x.Price);
            }
            return totalPrice;
        }

    }
}
