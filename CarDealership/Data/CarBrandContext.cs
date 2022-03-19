﻿using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
namespace CarDealership.Data
{
    public class CarBrandContext : DbContext
    {
        /// <summary>
        /// CarBrands Table
        /// </summary>
        public DbSet<CarBrand> carBrands { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CarBrandContext()
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
            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(k => k.id).HasName("idcar_brand");

                entity.Property(p => p.brand).HasMaxLength(45).IsRequired().HasColumnName("brand");

                entity.Property(p => p.model).HasMaxLength(45).IsRequired().HasColumnName("model");

            });

        }
    }
}

