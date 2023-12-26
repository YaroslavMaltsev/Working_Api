
using Microsoft.EntityFrameworkCore;
using Working_Api.DAL.Data;
using Working_Api.DAL.Interfaces;
using Working_Api.Domain.Entities;

namespace Working_Api.DAL.Repositories
{
    public class WorkerRepository(ApplicationDbContext context) : IBaseRepository<Worker>
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<bool> Create(Worker entity)
        {
            await _context.AddAsync(entity);

            return await Save();
        }

        public async Task<bool> Delete(Worker entity)
        {
            _context.Remove(entity);

            return await Save();
        }

        public async Task<List<Worker>> GetAll()
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Worker> GetById(int Id)
        {
            return await _context.Workers.Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();

            return saved != 0 ? true : false;
        }
    }
}
