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
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public PurchaseOrderService(IPurchaseOrderRepository repository, IProductRepository productRepository, ICustomerRepository customerRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrderRequestDTO poDTO)
        {
            var dateTime = DateTime.Now;
            var orderDetails = GetOrderDetailsToOrder(poDTO.Products);
            var totalPrice = CalculatePrice(orderDetails);
            Customer customer = GetCustomerToOrder(poDTO.Customer);

            PurchaseOrder po = new()
            {
                Customer = customer,
                OrderNumber = $"BRGI{dateTime.Year}{dateTime.Day}{dateTime.Month}{poDTO.Customer.CustomerCode.Replace("BR", "").ToUpper()}", //GI = Good issue
                TotalPrice = totalPrice,
                PaymentMethod = poDTO.PaymentMethod,
            };

            _repository.Add(po);

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.PurchaseOrderId = po.Id;
                _orderDetailsRepository.SaveChanges();
            }

            return po;
        }
        #region Private Methods
        private Customer GetCustomerToOrder(CustomerOrderRequestDTO request)
        {
            Customer? customer = _customerRepository.Find(c => c.CustomerCode == request.CustomerCode).FirstOrDefault();

            return customer ?? throw new Exception("Customer does not exist");
        }
        private List<OrderDetails> GetOrderDetailsToOrder(List<PurchaseOrderProductsDTO> products)
        {
            var orderDetails = new List<OrderDetails>();
            foreach (var product in products)
            {
                // cria a lista fazendo a query via linq 
                Product? item = _productRepository.Find(p => p.SKU == product.SKU).FirstOrDefault(p => p.Quantity > 0 && p.IsActive == true);

                //Inclui o item dentro da lista caso for encontrado e cria um Product para response
                if (item != null)
                {
                    OrderDetails od = new()
                    {
                        Quantity = product.Quantity,
                        Price = item.Price * product.Quantity,
                        PurchaseOrderId = null
                    };

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
                        OrderDetailId = od.Id,
                    };
                    orderDetails.Add(od);
                    item.Quantity -= product.Quantity;
                    _orderDetailsRepository.Add(od);
                    _productRepository.SaveChanges();
                }
            }
            return orderDetails;
        }
        private decimal CalculatePrice(List<OrderDetails> ordersDetails)
        {
            decimal totalPrice = 0;
            foreach (var orderDetails in ordersDetails)
            {
                totalPrice += orderDetails.Price;
            }
            return totalPrice;
        }
        #endregion

    }
}
