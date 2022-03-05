using CarDealership.Models;
using System.Data.Entity;
namespace CarDealership.Data
{
    public class CarBrandContext : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString = null;//pull the connection string after making a connecting the database with sql server

        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<CarBrand> CarBrands { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductContext()
        {
            // Create the database automaticly
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary> 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
