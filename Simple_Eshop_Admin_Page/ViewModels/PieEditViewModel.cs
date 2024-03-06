using Microsoft.AspNetCore.Mvc.Rendering;
using Simple_Eshop_Admin_Page.Models;

namespace Simple_Eshop_Admin_Page.ViewModels
{
    public class PieEditViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; } = default!;

        public Pie Pie { get; set; }
    }
}
