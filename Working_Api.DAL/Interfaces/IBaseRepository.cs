namespace Working_Api.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int Id);

        public Task<bool> Create(T entity);

        Task<bool> Save();

        Task<bool> Delete(T entity);

    }
}