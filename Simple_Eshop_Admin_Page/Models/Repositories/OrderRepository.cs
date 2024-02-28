
using Microsoft.EntityFrameworkCore;

namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;
        public OrderRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync()
        {
            return await _bethanysPieShopDbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Pie)
                .OrderBy(o => o.OrderId).ToListAsync();
        }

        public Task<Order?> GetOrderDetailsAsync(int? orderId)
        {
            throw new NotImplementedException();
        }
    }
}
