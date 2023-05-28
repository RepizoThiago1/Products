namespace Products.Domain.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() { }
        public CustomerNotFoundException(string message): base(message){ }
    }

    public class CustomerCodeExistsException : Exception
    {
        public CustomerCodeExistsException() { }
        public CustomerCodeExistsException(string message) : base(message) { }
    }

    public class CustomerNameExistsException : Exception
    {
        public CustomerNameExistsException() { }
        public CustomerNameExistsException(string message) : base(message) { }
    }
}
