
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            bool categoryWithSameNameExists = await
                _bethanysPieShopDbContext.Categories.AnyAsync(c => c.Name == category.Name);

            if (categoryWithSameNameExists)
            {
                throw new Exception("The entered category already exists");
            }

            _bethanysPieShopDbContext.Categories.Add(category);

            return await _bethanysPieShopDbContext.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _bethanysPieShopDbContext.Categories
                .OrderBy(p => p.CategoryId)
                .AsNoTracking();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            //throw new Exception("Database down"); Testing the try catch block

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

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            bool categoryWithSameNameExists = await
                _bethanysPieShopDbContext.Categories
                .AnyAsync(c => c.Name == category.Name
                && c.CategoryId != category.CategoryId);

            if (categoryWithSameNameExists)
            {
                throw new Exception("A category with the same name already exists");
            }

            var categoryToUpdate = await
                _bethanysPieShopDbContext.Categories.FirstOrDefaultAsync
                (c=> c.CategoryId == category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;

                _bethanysPieShopDbContext.Categories.Update(categoryToUpdate);
                return await _bethanysPieShopDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The category to update can't be found");
            }

        }
    }
}
