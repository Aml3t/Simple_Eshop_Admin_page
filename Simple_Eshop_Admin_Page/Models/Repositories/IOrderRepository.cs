namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderDetailsAsync(int? orderId);
        Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync();

    }
}
