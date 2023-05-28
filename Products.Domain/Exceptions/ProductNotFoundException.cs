namespace Products.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }
        public ProductNotFoundException(string message) : base(message) { }
    }

    public class InvalidPriceException : Exception
    {
        public InvalidPriceException() { }
        public InvalidPriceException(string message) : base(message) { }
    }
}
