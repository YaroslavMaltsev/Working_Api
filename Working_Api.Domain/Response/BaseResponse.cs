
using Working_Api.Domain.Interface;

namespace Working_Api.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
