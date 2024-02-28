﻿using Microsoft.AspNetCore.Mvc;
using Simple_Eshop_Admin_Page.Models.Repositories;

namespace Simple_Eshop_Admin_Page.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pies = await _pieRepository.GetAllPiesAsync();

            return View(pies);
        }

    }
}
