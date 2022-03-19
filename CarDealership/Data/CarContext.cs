using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
namespace CarDealership.Data
{
    public class CarContext : DbContext
    {

        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Car> cars { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CarContext()
        {
            // Create the database automaticly
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary> 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cardealership;Integrated Security=True";
                optionsBuilder.UseSqlServer(connString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(k => k.id).HasName("pk_cars_id");

                entity.Property(k => k.id).HasColumnName("id_car");

                entity.HasOne(b => b.carBrand).WithMany().HasForeignKey(b => b.carBrandId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_car_car_brand");

                entity.Property(p => p.price).HasColumnName("price");

                entity.Property(p => p.manufDate).HasColumnType("datetime").HasColumnName("manufactureDate");

                entity.Property(p => p.horsePower).HasColumnType("float").HasColumnName("horsepower");

                entity.Property(p => p.kmDriven).HasColumnType("float").HasColumnName("kmDriven");

                entity.Property(p => p.engineVolume).HasColumnType("float").HasColumnName("engineVolume");

                entity.Property(p => p.info).HasColumnName("additional_info").HasMaxLength(1000);
            });


        }
    }
}
