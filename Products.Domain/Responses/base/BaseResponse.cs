using Products.Domain.Interfaces.Responses.@base;
using System.Net;

namespace Products.Domain.Responses.@base
{
    public class BaseResponse<T> : IBaseResponse<T> where T : class
    {
        public BaseResponse(HttpStatusCode statusCode, string message)
        {
            HttpStatusCode = statusCode;
            Message = message;
        }

        public BaseResponse(HttpStatusCode statusCode, string message, T content)
        {
            HttpStatusCode = statusCode;
            Message = message;
            Content = content;
        }
        public BaseResponse(HttpStatusCode statusCode, string message, IEnumerable<T> contentList)
        {
            HttpStatusCode = statusCode;
            Message = message;
            ContentList = contentList;
        }

        public string Message { get; set; }
        public T Content { get; set; }
        public IEnumerable<T> ContentList { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message) => new(statusCode, message);
        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message, T content) => new(statusCode, message, content);
        public static BaseResponse<T> ToResponse(HttpStatusCode statusCode, string message, IEnumerable<T> contentList) => new(statusCode, message, contentList);
    }
}
