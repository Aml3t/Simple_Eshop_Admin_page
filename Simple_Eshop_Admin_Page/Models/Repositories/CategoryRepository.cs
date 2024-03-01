﻿
using Microsoft.EntityFrameworkCore;

namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _bethanysPieShopDbContext.Categories
                .OrderBy(p => p.CategoryId)
                .AsNoTracking();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _bethanysPieShopDbContext.Categories
                 .OrderBy(c => c.CategoryId)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _bethanysPieShopDbContext.Categories
                .Include(p => p.Pies)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }
    }
}
