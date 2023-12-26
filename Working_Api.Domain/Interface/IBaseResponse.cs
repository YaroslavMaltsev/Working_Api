

namespace Working_Api.Domain.Interface
{
    public interface IBaseResponse<T>
    {
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
