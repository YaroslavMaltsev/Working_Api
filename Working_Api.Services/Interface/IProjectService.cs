using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;

namespace Working_Api.Services.Interface
{
    public interface IProjectService
    {
        Task<IBaseResponse<bool>> Create(ProjectDTO projectDTO);
        Task<IBaseResponse<bool>> Delete(int id);
        Task<IBaseResponse<Project>> GetProject(int id);
        Task<IBaseResponse<IEnumerable<Project>>> GetProjects();
        public Task<IBaseResponse<bool>> DeleteAll();
        public Task<IBaseResponse<bool>> Update(int id);
        public Task<IBaseResponse<bool>> UpdateImage(int id, UpdateFileDTO updateFileDTO);
    }
}