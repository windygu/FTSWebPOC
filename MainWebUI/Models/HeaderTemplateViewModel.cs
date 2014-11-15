using System.Collections.Generic;

namespace FTS.MainWebUI.Models
{
    public class HeaderTemplateViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<ProductViewModel> SelectedProducts { get; set; }
    }
}