using Working_Api.DAL.Interfaces;
using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;
using Working_Api.Services.Contains;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class ProjectService(IBaseRepository<Project> repository,
        IManagerFile managerFile) : IProjectService
    {
        private readonly IBaseRepository<Project> _repository = repository;
        private readonly IManagerFile _managerFile = managerFile;

        public async Task<IBaseResponse<bool>> Create(ProjectDTO projectDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (projectDTO == null)
                {
                    baseResponse.Description = "Пустая модель";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                var project = new Project()
                {
                    NameProject = projectDTO.NameProject,
                    Description = projectDTO.Description,
                    Link = projectDTO.Link,
                    Image = await _managerFile.SaveFile(projectDTO.Image)

                };

                baseResponse.Data = await _repository.Create(project);
                baseResponse.StatusCode = 204;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }
        public async Task<IBaseResponse<bool>> DeleteAll()
        {

            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {

                var project = await _repository.GetAll();

                if (project == null)
                {
                    baseResponse.Description = $"Таблица пуста";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var projectDelete = await _repository.DeleteAll(project);

                baseResponse.Data = projectDelete;
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }
        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (id == 0)
                {
                    baseResponse.Description = $"Не допустимый id:{id}";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }
                var project = await _repository.GetById(id);

                if (project == null)
                {
                    baseResponse.Description = $"Проект с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = await _repository.Delete(project);
                baseResponse.StatusCode = 201;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<Project>> GetProject(int id)
        {
            var baseResponse = Factory<Project>.GetBaseResponse();
            try
            {
                if (id == 0)
                {
                    baseResponse.Description = $"Не допустимый id:{id}";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }

                var project = await _repository.GetById(id);

                if (project == null)
                {
                    baseResponse.Description = $"Проект с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = project;
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }

        public async Task<IBaseResponse<IEnumerable<Project>>> GetProjects()
        {
            var baseResponse = Factory<Project>.GetBaseResponseAll();
            try
            {
                var projects = await _repository.GetAll();

                if (projects.Count == 0)
                {
                    baseResponse.Description = "Нет значений";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = projects;
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }

        public Task<IBaseResponse<bool>> Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<bool>> UpdateImage(int id, UpdateFileDTO updateFileDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (id <= 0)
                {
                    baseResponse.Description = $"Не допустимый id:{id}";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }
                var projectUpdate = await _repository.GetById(id);

                if (projectUpdate == null)
                {
                    baseResponse.Description = $"Проект с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                projectUpdate.Image = await _managerFile.SaveFile(updateFileDTO.image);

                await _repository.Update(projectUpdate);
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch(Exception ex)
            {

                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }
    }
}
