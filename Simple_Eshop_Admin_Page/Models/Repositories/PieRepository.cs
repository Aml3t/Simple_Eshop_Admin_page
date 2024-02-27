
namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public Task<IEnumerable<Pie>> GetAllPiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pie?> GetPieByIdAsync(int pieId)
        {
            throw new NotImplementedException();
        }
    }
}
