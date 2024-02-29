using Microsoft.AspNetCore.Mvc;
using Simple_Eshop_Admin_Page.Models.Repositories;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

    }
}
