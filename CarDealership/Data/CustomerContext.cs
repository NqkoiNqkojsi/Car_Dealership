using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
namespace CarDealership.Data
{
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Customer> customers { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerContext()
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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(k => k.id).HasName("id_customer");

                entity.Property(p => p.name).HasColumnName("name").HasMaxLength(45);

                entity.Property(p => p.birthDate).HasColumnName("price").HasColumnType("datetime");

                entity.Property(p => p.Password).HasMaxLength(500).HasColumnName("password").IsRequired();

                entity.Property(p => p.email).HasMaxLength(45).HasColumnName("email").IsRequired();

                entity.Property(p => p.phoneNum).HasMaxLength(45).HasColumnName("phoneNum").IsRequired();

            });
        }
    }
}

