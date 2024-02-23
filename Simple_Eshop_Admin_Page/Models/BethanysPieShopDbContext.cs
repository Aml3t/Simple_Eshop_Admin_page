﻿using Microsoft.EntityFrameworkCore;

namespace Simple_Eshop_Admin_Page.Models
{
    public class BethanysPieShopDbContext : DbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext>
            options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        //This is how we use different names for our Objects that are created to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof
                (BethanysPieShopDbContext).Assembly);
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Pie>().ToTable("Pies");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            //configuration using Fluent API (data annotation like)
            modelBuilder.Entity<Category>()
                .Property(b => b.Name)
                .IsRequired();
        }
    }
}
