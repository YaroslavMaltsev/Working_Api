using Working_Api.Domain.Interface;
using Working_Api.Domain.Response;

namespace Working_Api.Services.Contains
{
    public static class Factory<T>
    {
        public static IBaseResponse<IEnumerable<T>> GetBaseResponseAll()
        {
            return new BaseResponse<IEnumerable<T>>();
        }
        public static IBaseResponse<T> GetBaseResponse()
        {
            return new BaseResponse<T>();
        }

    }
}
