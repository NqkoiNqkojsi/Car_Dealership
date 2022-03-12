using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
namespace CarDealership.Data
{
    public class CarContext : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString =
                    "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";            //pull the connection string after making a connecting the database with sql server

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
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
