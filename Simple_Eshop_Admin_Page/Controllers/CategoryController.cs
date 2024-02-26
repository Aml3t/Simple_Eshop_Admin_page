using Microsoft.AspNetCore.Mvc;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
