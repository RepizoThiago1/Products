namespace Products.Domain.Exceptions
{
    public class ReferenceNotFoundException : Exception
    {
        public ReferenceNotFoundException() { }

        public ReferenceNotFoundException(string message) : base(message) { }
    }
}
