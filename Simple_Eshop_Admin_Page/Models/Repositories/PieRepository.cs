
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
            bool pieIsAvailable = await
                _bethanysPieShopDbContext.Pies
                .AnyAsync(p => p.Name == pie.Name && p.PieId == pie.PieId);

            if (!pieIsAvailable)
            {
                throw new Exception("The pie does not exists");
            }
        }
    }
}
