using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class PictureContext : DbContext
    {
        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<Picture> carBrands { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PictureContext()
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
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(k => k.id).HasName("idcar_brand");

                entity.HasOne(c => c.car).WithMany().HasForeignKey(k => k.carId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_car_picture");

                entity.Property(p => p.picture);

            });

        }
    }
}
