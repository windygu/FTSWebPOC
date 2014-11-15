using System.Data;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace FTS.MainWebUI.Controllers.Product
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            DataTable table = StaticMain.FTSMain().GetTable("DM_ITEM", "SELECT * FROM DM_ITEM");
            return View(table);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            DataTable products = StaticMain.FTSMain().GetTable("DM_ITEM", "SELECT * FROM DM_ITEM");
            return Json(products.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, int item_id, string item_name,
            string unit_id, int active)
        {
            //your database save logic
           // StaticMain.FTSMain().SaveItem();
            return Json(new object());
        }
    }
}