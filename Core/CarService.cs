using Models;


namespace Core
{
    public class CarService : ICarService
    {
        private readonly IDataRepository<Car> _repository;

        public CarService(IDataRepository<Car> repository) => _repository = repository;

        public async Task<Car?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task Init()
        {
            await _repository.Init();
        }

        public async Task<List<Car>> LoadAll()
        {
            return await _repository.LoadAll();
        }
    }
}
