namespace Products.Domain.Exceptions
{
    #region
    internal sealed class EmailExceptions
    {
    }
    #endregion

    public class EmptyEmailException: Exception 
    {
        public EmptyEmailException() {}
        public EmptyEmailException(string message) : base(message) { }
    }

    public class EmptyPasswordException : Exception
    {
        public EmptyPasswordException() { }
        public EmptyPasswordException(string message) : base(message) { }
    }
}
