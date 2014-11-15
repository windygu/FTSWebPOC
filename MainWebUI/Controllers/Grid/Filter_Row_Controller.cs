using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult Filter_Row()
        {
            ViewData["initial"] = productService.Read();
            return View();
        }
    }
}