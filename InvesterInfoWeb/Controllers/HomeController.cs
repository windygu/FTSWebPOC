using System;
using System.Data;
using System.Web.Mvc;
using FTS.ShareBusiness.Acc;

namespace FTS.InvesterInfoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }


        public string Destroy(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "dm_item";
            var item = new Dm_Item(StaticMain.FTSMain());
            DataRow row = item.GetRowWithID(table.Rows[0]["ITEM_ID"].ToString());
            item.DeleteRow(row);
            return StaticMain.Save(item);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }

        public string Read()
        {
            return StaticMain.LoadObject(new Dm_Item(StaticMain.FTSMain()));
        }

        public string ReadUnit()
        {
            return StaticMain.LoadObject(new Dm_Unit(StaticMain.FTSMain()));
        }

        public string Create(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "DM_ITEM";
            var dmItem = new Dm_Item(StaticMain.FTSMain());
            return StaticMain.Create(dmItem, table);
        }

        public string Update(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            var dmItem = new Dm_Item(StaticMain.FTSMain());
            dmItem.LoadDataByID(table.Rows[0]["ITEM_ID"]);
            DataRow item = dmItem.DataTable.Rows[0];
            item["ITEM_NAME"] = table.Rows[0]["ITEM_NAME"];
            item["UNIT_ID"] = table.Rows[0]["UNIT_ID"];
            item["ACTIVE"] = table.Rows[0]["ACTIVE"];

            return StaticMain.Save(dmItem);
        }
    }
}