using Microsoft.AspNetCore.Mvc.Rendering;
using Simple_Eshop_Admin_Page.Models;

namespace Simple_Eshop_Admin_Page.ViewModels
{
    public class PieAddViewModel
    {
        // Using SelectListItem because we will use in combination with the UI
        public IEnumerable<SelectListItem> Categories { get; set; } = default!;

        public Pie? Pie { get; set; }
        
    }
}
