using Products.Domain.DTO.Customer;
using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public SalesOrderService(ISalesOrderRepository repository, IProductRepository productRepository, ICustomerRepository customerRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public SalesOrder CreatePurchaseOrder(SalesOrderDTO salesOrderDTO)
        {
            var dateTime = DateTime.Now;
            var customer = GetCustomerToOrder(salesOrderDTO.Customer);
            var orderDetails = GetOrderDetailsToOrder(salesOrderDTO.Products);
            var totalPrice = CalculatePrice(orderDetails);

            SalesOrder salesOrder = new()
            {
                Customer = customer,
                OrderNumber = $"BRGI{dateTime.Year}{dateTime.Day}{dateTime.Month}{salesOrderDTO.Customer.CustomerCode.Replace("BR", "").ToUpper()}", //GI = Good issue
                TotalPrice = totalPrice,
                PaymentMethod = salesOrderDTO.PaymentMethod,
            };
            _repository.Add(salesOrder);

            ChangeRepeatedOrderNumber(salesOrderDTO);

            InsertProductOrderId(orderDetails, salesOrder);

            return salesOrder;
        }
        public SalesOrder GetPurchaseOrder(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<SalesOrder> GetAllOrders()
        {
            return _repository.GetAll();
        }
        #region Private Methods
        private Customer GetCustomerToOrder(CustomerOrderRequestDTO customerOrderDTO)
        {
            Customer? customer = _customerRepository.Find(c => c.CustomerCode == customerOrderDTO.CustomerCode).FirstOrDefault();

            return customer ?? throw new Exception("Customer does not exist");
        }
        private List<OrderDetails> GetOrderDetailsToOrder(List<SalesOrderProductsDTO> products)
        {
            var orderDetails = new List<OrderDetails>();
            foreach (var product in products)
            {
                // cria a lista fazendo a query via linq 
                Product? item = _productRepository.Find(p => p.SKU == product.SKU).FirstOrDefault(p => p.Quantity > 0 && p.IsActive == true);

                //Inclui o item dentro da lista caso for encontrado
                if (item != null)
                {
                    OrderDetails orderDetail = new()
                    {
                        Quantity = product.Quantity,
                        Price = item.Price * product.Quantity,
                        SalesOrderId = null
                    };

                    orderDetails.Add(orderDetail);
                    item.Quantity -= product.Quantity;
                    _orderDetailsRepository.Add(orderDetail);
                    _productRepository.SaveChanges();
                }
            }
            return orderDetails;
        }
        private static decimal CalculatePrice(List<OrderDetails> ordersDetails)
        {
            decimal totalPrice = 0;
            foreach (var orderDetails in ordersDetails)
            {
                totalPrice += orderDetails.Price;
            }
            return totalPrice;
        }
        private void ChangeRepeatedOrderNumber(SalesOrderDTO salesOrderDTO)
        {
            var dateTime = DateTime.Now;
            int saleIdentifierDigit = 0;
            string orderNumberDefault = $"BRGI{dateTime.Year}{dateTime.Day}{dateTime.Month}{salesOrderDTO.Customer.CustomerCode.Replace("BR", "").ToUpper()}";

            var orders = _repository.Find(p => p.OrderNumber.StartsWith(orderNumberDefault)).ToList();

            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    order.OrderNumber = $"BRGI{dateTime.Year}{dateTime.Day}{dateTime.Month}{salesOrderDTO.Customer.CustomerCode.Replace("BR", "").ToUpper()}S{saleIdentifierDigit}";
                    saleIdentifierDigit++;
                    _repository.SaveChanges();
                }
            }
        }
        private void InsertProductOrderId(List<OrderDetails> orderDetails, SalesOrder salesOrder)
        {
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.SalesOrderId = salesOrder.Id;
                orderDetail.OrderNumber = salesOrder.OrderNumber;
                _orderDetailsRepository.SaveChanges();
            }
        }
        #endregion
    }
}
