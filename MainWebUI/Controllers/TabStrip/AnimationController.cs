using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class TabStripController : Controller
    {
        public ActionResult Animation(string animation, bool? opacity)
        {
            ViewBag.animation = animation ?? "expand";
            ViewBag.opacity = opacity ?? true;

            return View();
        }
    }
}