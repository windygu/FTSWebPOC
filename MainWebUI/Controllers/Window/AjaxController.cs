using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class WindowController : Controller
    {
        public ActionResult Ajax()
        {
            return View();
        }

        public ActionResult AjaxContent()
        {
            return View();
        }

        public ActionResult AjaxContent1()
        {
            return PartialView();
        }
    }
}