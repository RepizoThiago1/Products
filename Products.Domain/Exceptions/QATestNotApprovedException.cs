namespace Products.Domain.Exceptions
{
    public class QATestNotApprovedException : Exception
    {
        public QATestNotApprovedException() { }

        public QATestNotApprovedException(string message) : base(message) { }
    }
}
