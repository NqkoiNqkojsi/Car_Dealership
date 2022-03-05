using CarDealership.Models;
using System.Data.Entity;
namespace CarDealership.Data
{
    public class CarContext : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString = null;//pull the connection string after making a connecting the database with sql server

        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Car> cars { get; set; }

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
