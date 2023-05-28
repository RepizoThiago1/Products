namespace Products.Domain.Exceptions
{
    #region

    #endregion
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() { }
        public UserAlreadyExistsException(string message) : base(message) { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }
    }

    public class InvalidConfirmKeyException : Exception
    {
        public InvalidConfirmKeyException() { }
        public InvalidConfirmKeyException(string message) : base(message) { }
    }
}
