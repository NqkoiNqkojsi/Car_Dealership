using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Data
{
    /// <summary>
    /// CarDealershipContext class.
    /// </summary>
    public partial class CarDealershipContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>

        public CarDealershipContext()
        {
            //Create the database automaticly
            Database.EnsureCreated();

        }
        /// <summary>
        /// Constructor (overloaded).
        /// </summary>
        /// <param name="options"></param>
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<CarBrand> carBrands { get; set; }

        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Car> cars { get; set; }

        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Customer> customers { get; set; }

        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<Picture> pictures { get; set; }

        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<RelationSeller> relationSeller { get; set; }

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
            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(k => k.id).HasName("idcar_brand");

                entity.Property(p => p.brand).HasMaxLength(45).IsRequired().HasColumnName("brand");

                entity.Property(p => p.model).HasMaxLength(45).IsRequired().HasColumnName("model");

                entity.HasData
                (
                    new CarBrand("BMS", "325i"),
                    new CarBrand("Opel", "Agila"),
                    new CarBrand("Citroen", "C4")
                );
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(k => k.id).HasName("pk_cars_id");

                entity.Property(k => k.id).HasColumnName("id_car");

                entity.HasOne(b => b.carBrand).WithMany().HasForeignKey(b => b.carBrandId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_car_car_brand");

                entity.Property(p => p.price).HasColumnName("price");

                entity.Property(p => p.manufDate).HasColumnName("manufactureDate").HasMaxLength(45);

                entity.Property(p => p.horsePower).HasColumnType("float").HasColumnName("horsepower");

                entity.Property(p => p.kmDriven).HasColumnType("float").HasColumnName("kmDriven");

                entity.Property(p => p.engineVolume).HasColumnType("float").HasColumnName("engineVolume");

                entity.Property(p => p.info).HasColumnName("additional_info").HasMaxLength(1000);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(k => k.id).HasName("id_customer");

                entity.Property(p => p.name).HasColumnName("name").HasMaxLength(45);

                entity.Property(p => p.birthDate).HasColumnName("price").HasColumnType("datetime");

                entity.Property(p => p.Password).HasMaxLength(500).HasColumnName("password").IsRequired();

                entity.Property(p => p.Email).HasMaxLength(45).HasColumnName("email").IsRequired();

                entity.Property(p => p.phoneNum).HasMaxLength(45).HasColumnName("phoneNum").IsRequired();

            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(k => k.id).HasName("idcar_brand");

                entity.HasOne(c => c.car).WithMany().HasForeignKey(k => k.carId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_car_picture");

                entity.Property(p => p.picture);

            });

            modelBuilder.Entity<RelationSeller>(entity =>
            {
                entity.HasKey(k => k.id).HasName("id");

                entity.Property(k => k.id).HasColumnName("id");

                entity.HasOne(c => c.customer).WithMany().HasForeignKey(k => k.customerId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_customer_relation");

                entity.HasOne(c => c.car).WithMany().HasForeignKey(k => k.carId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_car_relation");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

