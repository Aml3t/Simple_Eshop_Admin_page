using Microsoft.AspNetCore.Mvc;
using Simple_Eshop_Admin_Page.Models;
using Simple_Eshop_Admin_Page.Models.Repositories;
using Simple_Eshop_Admin_Page.ViewModels;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            CategoryListViewModel model = new()
            {
                Categories = (await _categoryRepository.GetAllCategoriesAsync()).ToList()
            };

            return View(model);
        }
    }
}
