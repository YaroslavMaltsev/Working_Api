using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;
namespace Working_Api.Services.Interface
{
    public interface IServiceService
    {
        public Task<IBaseResponse<bool>> Create(ServiceDTO serviceDTO); 
        public Task<IBaseResponse<bool>> Delete(int id);
        public Task<IBaseResponse<Service>> GetService(int Id);
        public Task<IBaseResponse<IEnumerable<Service>>> GetServices();
    }
}
