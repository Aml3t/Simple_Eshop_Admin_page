using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedCategory = await _categoryRepository
                .GetCategoryByIdAsync(id.Value);

            return View(selectedCategory);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("Name", "Description", "DateAdded")]
                                            Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryRepository.AddCategoryAsync(category);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Adding the category failed, please try again! " +
                    $"Error: {ex.Message}");
            }

            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedCategory = await
                _categoryRepository.GetCategoryByIdAsync(id.Value);

            return View(selectedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryRepository.UpdateCategoryAsync(category);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Updating the category failed, " +
                    $"please try again! Error {ex.Message}");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var selectedCategory = await _categoryRepository.GetCategoryByIdAsync(id);

            return View(selectedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? CategoryId)
        {
            if (CategoryId == null)
            {
                ViewData["ErrorMessage"] = "Deleting the category failed, invalid ID!";
                return View();
            }

            try
            {
                await _categoryRepository.DeleteCategoryAsync(CategoryId.Value);

                TempData["CategoryDeleted"] = "Deleted the category successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["ErrorMessage"] = $"Deleting the category failed, please try again!" +
                    $"Error: {ex.Message}";
            }

            var selectedCategory = await _categoryRepository
                .GetCategoryByIdAsync(CategoryId.Value);

            return View(selectedCategory);
        }
    }
}
