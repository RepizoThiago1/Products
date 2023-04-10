using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        public decimal TotalPrice { get; set; } = 0;

        public Queue<Product> ProductFifo { get; set; } = new Queue<Product>();

        public PurchaseOrderService(IPurchaseOrderRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrderRequestDTO poDTO)
        {
            var dateTime = DateTime.Now;

            CreateProductList(poDTO.Products);
            CalculatePrice(ProductFifo);

            PurchaseOrder po = new()
            {
                OrderNumber = $"BRSOB{dateTime.Year}{dateTime.Day}{dateTime.Month}",
                TotalPrice = TotalPrice,
                PaymentMethod = poDTO.PaymentMethod,
            };

            return po;
        }
        private Queue<Product> CreateProductList(List<PurchaseOrderProductsDTO> products)
        {
            foreach (var product in products)
            {
                // cria a lista fazendo a query via linq 
                Product? item = _productRepository.Find(p => p.SKU == product.SKU).FirstOrDefault(p => p.Quantity > 0 && p.IsActive == true);

                //Inclui o item dentro da lista caso for encontrado e cria um Product para response
                if (item != null)
                {
                    Product response = new()
                    {
                        SKU = item.SKU,
                        Quantity = product.Quantity,
                        Batch = item.Batch,
                        Name = item.Name,
                        Description = item.Description,
                        IsActive = item.IsActive,
                        CategoryId = item.CategoryId,
                        Id = item.Id,
                        Note = item.Note,
                    };

                    ProductFifo.Enqueue(response);
                    item.Quantity -= product.Quantity;
                    _productRepository.SaveChanges();
                }
            }
            return ProductFifo;
        }
        private decimal CalculatePrice(Queue<Product> products)
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
