using Products.Domain.DTO;
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
        private readonly ICustomerRepository _customerRepository;
        public decimal TotalPrice { get; set; } = 0;
        public List<Product> ProductList { get; set; } = new List<Product>();

        public PurchaseOrderService(IPurchaseOrderRepository repository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrderRequestDTO poDTO)
        {
            var dateTime = DateTime.Now;

            GetProductListToOrder(poDTO.Products);
            TotalPrice = CalculatePrice(ProductList);
            Customer customer = GetCustomerToOrder(poDTO.Customer);

            PurchaseOrder po = new()
            {
                Customer = customer,
                Products = ProductList,
                OrderNumber = $"BRGI{dateTime.Year}{dateTime.Day}{dateTime.Month}{poDTO.Customer.CustomerCode}", //GI = Good issue
                TotalPrice = TotalPrice,
                PaymentMethod = poDTO.PaymentMethod,
            };

            _repository.Add(po);

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
        #region Private Methods
        private Customer GetCustomerToOrder(CustomerOrderRequestDTO request)
        {
            Customer? customer = _customerRepository.Find(c => c.CustomerCode == request.CustomerCode).FirstOrDefault();

            return customer ?? throw new Exception("Customer does not exist");
        }
        private List<Product> GetProductListToOrder(List<PurchaseOrderProductsDTO> products)
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
                        Price = item.Price,
                    };

                    ProductList.Add(response);
                    item.Quantity -= product.Quantity;
                    _productRepository.SaveChanges();
                }
            }
            return ProductList;
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
        #endregion

    }
}
