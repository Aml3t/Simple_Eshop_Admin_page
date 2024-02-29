using Microsoft.AspNetCore.Mvc;
using Simple_Eshop_Admin_Page.Models;
using Simple_Eshop_Admin_Page.Models.Repositories;
using Simple_Eshop_Admin_Page.ViewModels;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index(int? orderId, int? orderDetailId)
        {

            OrderIndexViewModel orderIndexViewModel = new OrderIndexViewModel()
            {
                Orders = await _orderRepository.GetAllOrdersWithDetailsAsync()
            };

            if (orderId != null)
            {
                Order selectedOrder = orderIndexViewModel.Orders.
                    Where(o => o.OrderId == orderId)
                    .Single();
            }
        }

    }
}
