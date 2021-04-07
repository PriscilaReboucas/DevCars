using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCars.API.Persistence.Configurations
{
    public class CarDbConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            //Car
            builder
                .HasKey(c => c.Id);
            builder
               .ToTable("Car");
            builder
             .Property(c => c.Brand)
             //.IsRequired() // obrigatorio
             .HasMaxLength(100)
             //.HasColumnName("Marca")
             .HasColumnType("Varchar(100)")
             .HasDefaultValue("Padrão"); 

             builder
            .Property(c => c.ProductionDate)
            .HasDefaultValueSql("getdate()"); // metodo padrão do sql
        }
    }
}
