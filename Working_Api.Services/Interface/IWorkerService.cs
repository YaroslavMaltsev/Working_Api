using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;

namespace Working_Api.Services.Interface
{
    public interface IWorkerService
    {
        public Task<IBaseResponse<bool>> Create(WorkerDTO workerDTO);
        public Task<IBaseResponse<bool>> Delete(int id);
        public Task<IBaseResponse<Worker>> GetWorker(int id);
        public Task<IBaseResponse<IEnumerable<Worker>>> GetWorkers();
    }
}
