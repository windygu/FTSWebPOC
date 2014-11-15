using FTS.MainWebUI.Models;
using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class ListViewController : Controller
    {
        public ActionResult Keyboard_Navigation()
        {
            return View(productService.Read());
        }
    }
}