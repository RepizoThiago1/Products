using Products.Domain.Interfaces.Responses.@base;

namespace Products.Domain.Responses.@base
{
    public class BaseResponse<T> : IBaseResponse<T> where T : class
    {
        public string Message { get; set; }
        public T? Content { get; set; }
        public IEnumerable<T>? ContentList { get; set; }
    }
}
