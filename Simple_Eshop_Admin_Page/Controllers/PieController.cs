﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Simple_Eshop_Admin_Page.Models;
using Simple_Eshop_Admin_Page.Models.Repositories;
using Simple_Eshop_Admin_Page.ViewModels;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pies = await _pieRepository.GetAllPiesAsync();

            return View(pies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pie = await _pieRepository.GetPieByIdAsync(id);

            return View(pie);
        }

        public async Task<IActionResult> Add()
        {
            var allCategories = await _categoryRepository.GetAllCategoriesAsync();

            IEnumerable<SelectListItem> selectListItems = new SelectList(
                allCategories, "CategoryId", "Name", null);

            PieAddViewModel pieAddViewModel = new() { Categories = selectListItems };

            return View(pieAddViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Add(PieAddViewModel pieAddViewModel)
        {
            Pie pie = new()
            {
                CategoryId = pieAddViewModel.Pie.CategoryId,
                ShortDescription = pieAddViewModel.Pie.ShortDescription,
                LongDescription = pieAddViewModel.Pie.LongDescription,
                Price = pieAddViewModel.Pie.Price,
                AllergyInformation = pieAddViewModel.Pie.AllergyInformation,
                ImageThumbnailUrl = pieAddViewModel.Pie.ImageThumbnailUrl,
                ImageUrl = pieAddViewModel.Pie.ImageUrl,
                InStock = pieAddViewModel.Pie.InStock,
                IsPieOfTheWeek = pieAddViewModel.Pie.IsPieOfTheWeek,
                Name = pieAddViewModel.Pie.Name
            };
        }

    }
}
