using Products.Domain.Responses.@base;
using System.Net;

namespace Products.Domain.Interfaces.Responses.@base
{
    public interface IBaseResponse<T> where T : class
    {
        public string Message { get; set; }
        public T Content { get; set; }
        public IEnumerable<T> ContentList { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message) => new(statusCode, message);
        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message, T content) => new(statusCode, message, content);
        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message, IEnumerable<T> contentList) => new(statusCode, message, contentList);
    }
}

