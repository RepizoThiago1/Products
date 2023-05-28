namespace Products.Domain.Exceptions
{
    public class ReferenceNotFoundException : Exception
    {
        public ReferenceNotFoundException() { }

        public ReferenceNotFoundException(string message) : base(message) { }
    }

    public class ReferenceExistisException : Exception
    {
        public ReferenceExistisException() { }
        public ReferenceExistisException(string message) : base(message) { } 
    }
}
