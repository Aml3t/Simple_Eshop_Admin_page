
using Microsoft.EntityFrameworkCore;

namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {
            return await _bethanysPieShopDbContext.Pies
                .OrderBy(p => p.PieId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pie?> GetPieByIdAsync(int pieId)
        {
            return await _bethanysPieShopDbContext.Pies
                .Include(p => p.Ingredients)
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.PieId == pieId);
        }

        public async Task<int> AddPieAsync(Pie pie)
        {
            _bethanysPieShopDbContext.Pies.Add(pie);
            return await _bethanysPieShopDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePieAsync(Pie pie)
        {
            var pieToUpdate = await
                _bethanysPieShopDbContext.Pies
                .FirstOrDefaultAsync(p => p.PieId == pie.PieId);

            if (pieToUpdate != null)
            {
                pieToUpdate.CategoryId = pie.CategoryId;
                pieToUpdate.ShortDescription = pie.ShortDescription;
                pieToUpdate.LongDescription = pie.LongDescription;
                pieToUpdate.Price = pie.Price;
                pieToUpdate.AllergyInformation = pie.AllergyInformation;
                pieToUpdate.ImageThumbnailUrl = pie.ImageThumbnailUrl;
                pieToUpdate.ImageUrl = pie.ImageUrl;
                pieToUpdate.InStock = pie.InStock;
                pieToUpdate.IsPieOfTheWeek = pie.IsPieOfTheWeek;
                pieToUpdate.Name = pie.Name;

                _bethanysPieShopDbContext.Pies.Update(pieToUpdate);
                return await _bethanysPieShopDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"The pie to update can't be found.");
            }
        }
        
        public async Task<int> DeletePieAsync(int pieId)
        {
            var pieToDelete = await _bethanysPieShopDbContext.Pies
                .FirstOrDefaultAsync(p => p.PieId == pieId);

            if (pieToDelete != null)
            {
                _bethanysPieShopDbContext.Pies.Remove(pieToDelete);
                return await _bethanysPieShopDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The pie to delete can't be found.");
            }
        }

        public Task<IEnumerable<Pie>> GetPiesPagedAsync(int? pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
