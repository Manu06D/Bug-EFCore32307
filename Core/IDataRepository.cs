using Models;

namespace Core
{
    public interface IDataRepository<T> where T : IEntity
    {
        Task Init();
        Task<T?> GetById(Guid id);
        Task<List<T>> LoadAll();
    }
}
