using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Working_Api.Domain.DTOs;
using Working_Api.Domain.Entities;
using Working_Api.Domain.Interface;

namespace Working_Api.Services.Interface
{
    public interface IPostService
    {
        public Task<IBaseResponse<bool>> Create(PostDTO serviceDTO);
        public Task<IBaseResponse<bool>> Delete(int id);
        public Task<IBaseResponse<Post>> GetPost(int Id);
        public Task<IBaseResponse<IEnumerable<Post>>> GetPosts();
        public Task<IBaseResponse<bool>> DeleteAll();
        public Task<IBaseResponse<bool>> Update(int id, PostDTO postDTO);
    }
}
