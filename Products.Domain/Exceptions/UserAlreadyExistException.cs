using Products.Domain.Entities;

namespace Products.Domain.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() { }

        public UserAlreadyExistException(User user): base(String.Format($"User already exists{user.Email}"))
        {
            
        }
    }
}
