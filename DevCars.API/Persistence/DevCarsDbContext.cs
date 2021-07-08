using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevCars.API.Persistence
{
    /// <summary>
    ///  Representa o contexto de dados (banco de dados)
    /// </summary>
    public class DevCarsDbContext : DbContext
    {
        public DevCarsDbContext(DbContextOptions<DevCarsDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aplica as configurações de todos configurations do assembly. Vai buscar no projeto todas as classes que implementam IEntityTypeConfiguration e adiciona,
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //    modelBuilder.ApplyConfiguration(new CarDbConfiguration());
            //    modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
            //    modelBuilder.ApplyConfiguration(new OrderDbConfiguration());
            //    modelBuilder.ApplyConfiguration(new ExtraOrderItemDbConfiguration());

        }
    }
}

