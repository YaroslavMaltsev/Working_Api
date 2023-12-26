using Microsoft.EntityFrameworkCore;
using Working_Api.DAL.Data;
using Working_Api.DAL.Interfaces;
using Working_Api.Domain.Entities;

namespace Working_Api.DAL.Repositories
{
    public class ProjectRepository(ApplicationDbContext context) : IBaseRepository<Project>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(Project entity)
        {
            var saved = await _context.SaveChangesAsync();

            return saved != 0 ? true : false;
        }

        public async Task<bool> Delete(Project entity)
        {
            _context.Remove(entity);

            return await Save();
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int Id)
        {
            return await _context.Projects.Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();

            return saved != 0 ? true : false;
        }
    }
}
