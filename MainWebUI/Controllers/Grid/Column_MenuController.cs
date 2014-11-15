using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {        
        public ActionResult Column_Menu()
        {
            return View();
        }

        public ActionResult ColumnMenu_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}