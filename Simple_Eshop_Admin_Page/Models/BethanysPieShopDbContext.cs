using Microsoft.EntityFrameworkCore;

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


        //This is how we use different name for our Objects to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Pie>().ToTable("Pies");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            //configuration using Fluent API
            modelBuilder.Entity<Category>()
                .Property(b => b.Name)
                .IsRequired();
        }
    }
}
