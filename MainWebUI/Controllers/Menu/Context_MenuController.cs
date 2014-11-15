using System.Web.Mvc;
using FTS.MainWebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace FTS.MainWebUI.Controllers
{
    public partial class MenuController : Controller
    {
        public ActionResult Context_Menu()
        {
            return View();
        }

        public ActionResult _WebMailData([DataSourceRequest] DataSourceRequest request)
        {
            return Json(WebMailDataRepository.WebMailData().ToDataSourceResult(request));
        }
    }
}
