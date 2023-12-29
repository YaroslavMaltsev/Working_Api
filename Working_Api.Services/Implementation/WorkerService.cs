using Working_Api.DAL.Interfaces;
using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;
using Working_Api.Services.Contains;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class WorkerService(IBaseRepository<Worker> repository,
        IManagerFile managerFile, IPostService postService) : IWorkerService
    {
        private readonly IBaseRepository<Worker> _repository = repository;
        private readonly IManagerFile _managerFile = managerFile;
        private readonly IPostService _postService = postService;

        public async Task<IBaseResponse<bool>> Create(WorkerDTO workerDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (workerDTO == null)
                {
                    baseResponse.Description = "Пустая модель";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var post = await _postService.GetPost(workerDTO.PostId);

                if (post.StatusCode == 404)
                {
                    baseResponse.Description = $"Должность с таким id не найдена : id {workerDTO.PostId}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var worker = new Worker()
                {
                    NameWorker = workerDTO.NameWorker,
                    PostId = post.Data.Id,
                    Surname = workerDTO.Surname,
                    Image = await _managerFile.SaveFile(workerDTO.Image)
                };

                baseResponse.Data = await _repository.Create(worker);
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

                var employees = await _repository.GetAll();

                if (employees == null)
                {
                    baseResponse.Description = $"Таблица пуста";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var workerDelete = await _repository.DeleteAll(employees);

                baseResponse.Data = workerDelete;
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
                var worker = await _repository.GetById(id);

                if (worker == null)
                {
                    baseResponse.Description = $"Сотрудник с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = await _repository.Delete(worker);
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

        public async Task<IBaseResponse<Worker>> GetWorker(int id)
        {
            var baseResponse = Factory<Worker>.GetBaseResponse();
            try
            {
                if (id == 0)
                {
                    baseResponse.Description = $"Не допустимый id:{id}"; ;
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }

                var worker = await _repository.GetById(id);

                if (worker == null)
                {
                    baseResponse.Description = $"Сотрудник с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = worker;
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

        public async Task<IBaseResponse<IEnumerable<Worker>>> GetWorkers()
        {
            var baseResponse = Factory<Worker>.GetBaseResponseAll();
            try
            {
                var workers = await _repository.GetAll();

                if (workers.Count == 0)
                {
                    baseResponse.Description = "Нет значений";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = workers;
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
    }
}
