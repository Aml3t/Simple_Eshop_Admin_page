namespace Simple_Eshop_Admin_Page.Models.Repositories
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task<Pie?> GetPieByIdAsync(int pieId);
        Task<int> AddPieAsync(Pie pie);
        Task<int> UpdatePieAsync(Pie pie);
        Task<int> DeletePieAsync(int pieId);
        Task<IEnumerable<Pie>> GetPiesPagedAsync(int? pageNumber, int pageSize);
    }
}
