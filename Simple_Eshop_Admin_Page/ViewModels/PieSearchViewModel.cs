using Microsoft.AspNetCore.Mvc.Rendering;
using Simple_Eshop_Admin_Page.Models;
using System.Net.Sockets;

namespace Simple_Eshop_Admin_Page.ViewModels
{
    public class PieSearchViewModel
    {
        public IEnumerable<Pie>? Pies { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; } = default!;

        public string? SearchQuery { get; set; }
        public int? SearchCategory { get; set; }
    }
}
