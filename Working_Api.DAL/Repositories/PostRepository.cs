using Microsoft.EntityFrameworkCore;
using Working_Api.DAL.Data;
using Working_Api.DAL.Interfaces;
using Working_Api.Domain.Entities;

namespace Working_Api.DAL.Repositories
{
    public class PostRepository(ApplicationDbContext context) : IBaseRepository<Post>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(Post entity)
        {
            await _context.AddAsync(entity);

            return await Save();
        }

        public async Task<bool> Delete(Post entity)
        {
            _context.Remove(entity);

            return await Save();
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int Id)
        {
            return await _context.Posts.Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();

            return saved != 0 ? true : false;
        }
    }
}
