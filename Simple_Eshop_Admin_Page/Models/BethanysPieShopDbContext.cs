using Microsoft.EntityFrameworkCore;

namespace Simple_Eshop_Admin_Page.Models
{
    public class BethanysPieShopDbContext : DbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext>
            options) : base(options)
        {
            
        }
    }
}
