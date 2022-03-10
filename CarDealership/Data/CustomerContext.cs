using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
namespace CarDealership.Data
{
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString = null;//pull the connection string after making a connecting the database with sql server

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
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

