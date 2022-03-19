using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class RelationSellerContext: DbContext
    {
        /// <summary>
        /// Cars Table
        /// </summary>
        public DbSet<Customer> relationSeller { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RelationSellerContext()
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

            modelBuilder.Entity<RelationSeller>(entity =>
            {
                entity.HasKey(k => k.id).HasName("id");

                entity.Property(k => k.id).HasColumnName("id");

                entity.HasOne(c => c.customer).WithMany().HasForeignKey(k => k.customerId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_customer_relation");

                entity.HasOne(c => c.car).WithMany().HasForeignKey(k => k.carId).OnDelete(DeleteBehavior.ClientCascade).HasConstraintName("fk_car_relation");
            });
        }
    }
}
