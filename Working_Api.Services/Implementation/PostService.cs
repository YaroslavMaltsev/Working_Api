using Working_Api.DAL.Interfaces;
using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;
using Working_Api.Services.Contains;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class PostService(IBaseRepository<Post> repository) : IPostService
    {
        private readonly IBaseRepository<Post> _repository = repository;

        public async Task<IBaseResponse<bool>> Create(PostDTO postDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if (postDTO == null)
                {
                    baseResponse.Description = "Пустая модель";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                var post = new Post
                {
                    NamePost = postDTO.NamePost,
                    Description = postDTO.Description,
                };

                baseResponse.Data = await _repository.Create(post);
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

                var service = await _repository.GetById(id);

                if (service == null)
                {
                    baseResponse.Description = $"Должность с таким id не найдена : id {id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = await _repository.Delete(service);
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

        public async Task<IBaseResponse<bool>> DeleteAll()
        {

            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {

                var posts = await _repository.GetAll();

                if (posts == null)
                {
                    baseResponse.Description = $"Таблица пуста";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var postDelete = await _repository.DeleteAll(posts);

                baseResponse.Data = postDelete;
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

        public async Task<IBaseResponse<Post>> GetPost(int Id)
        {

            var baseResponse = Factory<Post>.GetBaseResponse();
            try
            {
                if (Id == 0)
                {
                    baseResponse.Description = $"Не допустимый id:{Id}";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }

                var post = await _repository.GetById(Id);

                if (post == null)
                {
                    baseResponse.Description = $"Должность с таким Id не найдена : Id{Id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }

                baseResponse.Data = post;
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

        public async Task<IBaseResponse<IEnumerable<Post>>> GetPosts()
        {
            var baseResponse = Factory<Post>.GetBaseResponseAll();
            try
            {
                var services = await _repository.GetAll();

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

        public async Task<IBaseResponse<bool>> Update(int id, PostDTO postDTO)
        {
            var baseResponse = Factory<bool>.GetBaseResponse();
            try
            {
                if(id == 0)
                {
                    baseResponse.Description = $"Не допустимый id:{id}";
                    baseResponse.StatusCode = 404;
                    return baseResponse;
                }
                var post = await _repository.GetById(id);

                if(post == null)
                {
                    baseResponse.Description = $"Должность с таким Id не найдена : Id{id}";
                    baseResponse.StatusCode = 400;
                    return baseResponse;
                }
                post.NamePost = postDTO.NamePost;
                post.Description = postDTO.Description;
                
                var postUpdate = await _repository.Update(post);

                baseResponse.Data = postUpdate;
                baseResponse.StatusCode = 200;
                return baseResponse;
            }
            catch 
            {
                baseResponse.Description = "Проблема с сервисом";
                baseResponse.StatusCode = 500;
                return baseResponse;
            }
        }

    }
}
