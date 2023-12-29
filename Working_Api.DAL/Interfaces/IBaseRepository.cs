namespace Working_Api.DAL.Interfaces
{
    public interface IBaseRepository<T> 
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int Id);

        public Task<bool> Create(T entity);

        public Task<bool> Save();
        public Task<bool> Update(T entity);

        public Task<bool> Delete(T entity);

        public Task<bool> DeleteAll(IEnumerable<T> entities);
    }
}