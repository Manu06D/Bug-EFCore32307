using Models;

namespace Core
{
    public interface ICarService
    {
        Task Init();
        Task<Car?> GetById(Guid id);
        Task<List<Car>> LoadAll();
    }
}
