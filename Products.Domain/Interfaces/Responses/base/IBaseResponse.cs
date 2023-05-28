namespace Products.Domain.Interfaces.Responses.@base
{
    public interface IBaseResponse<T> where T : class
    {
        public string Message { get; set;}
        public T? Content { get; set; }
        public IEnumerable<T>? ContentList { get; set; }
    }
}

