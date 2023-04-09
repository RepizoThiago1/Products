using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;

        public decimal TotalPrice { get; set; } = 0;

        public Queue<Product> ProductFifo { get; set; } = new Queue<Product>();

        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }
        //public PurchaseOrder CreatePurchaseOrder(PurchaseOrderDTO poDTO)
        //{
        //    var dateTime = DateTime.Now;

        //    TotalPrice = CalculatePrice(poDTO.Products);
        //    ProductFifo = CreateProductList(poDTO.Products);

        //    PurchaseOrder po = new()
        //    {
        //        PaymentMethod = poDTO.PaymentMethod,
        //        OrderNumber = $"BRSOB{dateTime.Year}{dateTime.Day}{dateTime.Month}",
        //        TotalPrice = TotalPrice,
        //    };

        //    return po;
        //}
        private Queue<Product> CreateProductList(List<Product> products)
        {
            foreach (var product in products)
            {
                var item = _repository.QueryOrder($"SELECT * " +
                                                    $"FROM [dbo].Products " +
                                                    $"WHERE name = '{product.Name}' " +
                                                    $"AND Quantity > 0 " +
                                                    $"AND IsActive = 1" +
                                                    $"UPDATE [dbo].Products " +
                                                    $"SET Quantity = (SELECT Quantity FROM [dbo].Products " +
                                                    $"WHERE id = {product.Id}) - {product.Quantity}").FirstOrDefault();
                if (item != null)
                {
                    ProductFifo.Enqueue(item);
                }
            }
            return ProductFifo;
        }
        private decimal CalculatePrice(List<Product> products)
        {
            foreach (var product in products)
            {
                decimal productPrice = product.Price * product.Quantity;
                TotalPrice += productPrice;
            }
            return TotalPrice;
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
