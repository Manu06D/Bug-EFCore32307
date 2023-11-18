using Core;

using Microsoft.EntityFrameworkCore;

using Models;

namespace Infrastructure
{
    public class DataCarRepository : IDataRepository<Car>
    {
        private readonly IDbContextFactory<MyDbContext> _factory;

        public DataCarRepository(IDbContextFactory<MyDbContext> factory) => _factory = factory;

        public async Task<Car?> GetById(Guid id)
        {
            using var context = _factory.CreateDbContext();

            return await context.Cars.FindAsync(id);
        }

        public async Task Init()
        {
            using var context = _factory.CreateDbContext();
            await context.Database.EnsureCreatedAsync();

            context.Add(new Car() { Name = "Ferrari", Id = Guid.NewGuid(), Properties = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() } });

            await context.SaveChangesAsync();
        }

        public async Task<List<Car>> LoadAll()
        {
            using var context = _factory.CreateDbContext();
            return await context.Cars.ToListAsync();
        }
    }
}
