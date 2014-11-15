using System.Data;
using System.Web.Mvc;
using FTS.BaseBusiness.Business;
using FTS.ShareBusiness.Acc;

namespace FTS.InvesterInfoWeb.Controllers
{
    public class CustomerController : Controller
    {
       
        public ActionResult CustomerList()
        {
            return View();
        }

        public string Read()
        {
            return StaticMain.LoadObject(new Dm_Pr_Detail(StaticMain.FTSMain()));
        }


        public string Destroy(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "DM_PR_DETAIL";
            var prDetail = new Dm_Pr_Detail(StaticMain.FTSMain());
            DataRow row = prDetail.GetRowWithID(table.Rows[0]["PR_DETAIL_ID"].ToString());
            prDetail.DeleteRow(row);
            return StaticMain.Save(prDetail);
        }

        public string Create(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "DM_PR_DETAIL";
            var dmItem = new Dm_Pr_Detail(StaticMain.FTSMain());
            return StaticMain.Create(dmItem, table);
        }

        public string Update(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            var prDetail = new Dm_Pr_Detail(StaticMain.FTSMain());
            prDetail.LoadDataByID(table.Rows[0]["PR_DETAIL_ID"]);
            StaticMain.CopyRow(table.Rows[0], prDetail.DataTable.Rows[0], false);
            return StaticMain.Save(prDetail);
        }
    }
}