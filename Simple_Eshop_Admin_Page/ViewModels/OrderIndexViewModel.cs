

using Simple_Eshop_Admin_Page.Models;

namespace Simple_Eshop_Admin_Page.ViewModels
{
    public class OrderIndexViewModel
    {
        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
        public IEnumerable<Pie>? Pies { get; set; }
        public int? SelectedOrderId { get; set; }
        public int? SelectedOrderDetailId { get; set; }

    }
}
