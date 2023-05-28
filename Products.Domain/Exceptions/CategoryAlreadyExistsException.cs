namespace Products.Domain.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException() { }
        public CategoryAlreadyExistsException(string message) : base(message) { }
    }

    public class CategoryReferenceExists : Exception
    {
        public CategoryReferenceExists() { }
        public CategoryReferenceExists(string message) : base(message) { }
    }

    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() { }
        public CategoryNotFoundException(string message) : base(message) { }
    }
}
