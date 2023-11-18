using Microsoft.EntityFrameworkCore;

using Models;

namespace Infrastructure
{
    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var model = modelBuilder.Entity<Car>(car =>
            {
                car.ToContainer("Cars")
                .HasPartitionKey(d => d.Id)
                .HasNoDiscriminator();
            });

            ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
