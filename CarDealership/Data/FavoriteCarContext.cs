using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class FavoriteCarContext : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database = cardealership; Integrated Security=True";//pull the connection string after making a connecting the database with sql server

        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<FavoriteCar> relaionFavourite { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FavoriteCarContext()
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
