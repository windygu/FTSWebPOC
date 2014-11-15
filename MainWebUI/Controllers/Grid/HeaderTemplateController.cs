using System.Web.Mvc;
using System.Linq;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {   
        public ActionResult HeaderTemplate(int[] selectedProducts)
        {
            var products = productService.Read();

            selectedProducts = selectedProducts ?? new int[0];

            return View(new HeaderTemplateViewModel
            {
                Products = products,
                SelectedProducts = products.Where(p => selectedProducts.Contains(p.ProductID))
            });
        }     
    }
}