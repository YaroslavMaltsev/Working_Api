using Microsoft.AspNetCore.Http;

namespace Working_Api.Services.Interface
{
    public interface IManagerFile
    {
         public Task<byte[]> SaveFile(IFormFile fromFile);
    }
}
