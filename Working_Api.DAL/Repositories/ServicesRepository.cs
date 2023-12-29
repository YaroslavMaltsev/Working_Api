using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Working_Api.DAL.Data;
using Working_Api.DAL.Interfaces;
using Working_Api.Domain.Entities;

namespace Working_Api.DAL.Repositories
{
    public class ServicesRepository(ApplicationDbContext context) : IBaseRepository<Service>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(Service entity)
        {
            await _context.AddAsync(entity);

            return await Save();
        }

        public async Task<bool> Delete(Service entity)
        {
            _context.Remove(entity);

            return await Save();
        }

        public async Task<bool> DeleteAll(IEnumerable<Service> entities)
        {
            _context.RemoveRange(entities);

            return await Save();
        }

        public async Task<List<Service>> GetAll()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetById(int Id)
        {
            return await _context.Services.Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();

            return saved != 0 ? true : false;
        }

        public async Task<bool> Update(Service entity)
        {
            _context.Update(entity);

            return await Save();
        }

       
    }
}
