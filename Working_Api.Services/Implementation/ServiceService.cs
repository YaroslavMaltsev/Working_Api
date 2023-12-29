using Working_Api.DAL.Interfaces;
using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;
using Working_Api.Services.Contains;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class ServiceService(IBaseRepository<Service> repositoryService, IManagerFile managerFile) : IServiceService
    {
        private readonly IBaseRepository<Service> _repositoryService = repositoryService;
        private readonly IManagerFile _managerFile = managerFile;

        public async Task<IBaseResponse<bool>> Create(ServiceDTO serviceDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (serviceDTO == null)
                {
                    baseResponse.Description = "Пустая модель";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                var service = new Service
                {
                    NameService = serviceDTO.NameService,
                    Description = serviceDTO.Description,
                    image = await _managerFile.SaveFile(serviceDTO.image)
                };

                baseResponse.Data = await _repositoryService.Create(service);
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

                var services = await _repositoryService.GetAll();

                if (services == null)
                {
                    baseResponse.Description = $"Таблица пуста";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var serviveDelete = await _repositoryService.DeleteAll(services);

                baseResponse.Data = serviveDelete;
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
                var service = await _repositoryService.GetById(id);

                if (service == null)
                {
                    baseResponse.Description = $"Услуга с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = await _repositoryService.Delete(service);
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

        public async Task<IBaseResponse<Service>> GetService(int Id)
        {
            var baseResponse = Factory<Service>.GetBaseResponse();
            try
            {
                if (Id == 0)
                {
                    baseResponse.Description = "Ведите id";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }

                var service = await _repositoryService.GetById(Id);

                if (service == null)
                {
                    baseResponse.Description = "Услуга не найден";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = service;
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

        public async Task<IBaseResponse<IEnumerable<Service>>> GetServices()
        {
            var baseResponse = Factory<Service>.GetBaseResponseAll();
            try
            {
                var services = await _repositoryService.GetAll();

                if (services.Count == 0)
                {
                    baseResponse.Description = "Нет значений";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = services;
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
