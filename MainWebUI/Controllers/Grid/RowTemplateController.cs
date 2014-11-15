using System.Web.Mvc;
using Kendo.Mvc.UI;
using FTS.MainWebUI.Models;
using Kendo.Mvc.Extensions;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult RowTemplate()
        {
            return View();
        }

        public ActionResult RowTemplate_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }
    }
}