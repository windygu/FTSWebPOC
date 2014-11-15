using System;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FTS.AccBusiness.Sale;
using Kendo.Mvc;


namespace FTS.InvesterInfoWeb.Controllers
{
    public class SaleController : Controller
    {
        public static object SyncRoot = new object();
        public string Read()
        {
            return StaticMain.LoadObject(new Sale(StaticMain.FTSMain()));
        }

        public string Destroy(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale";

            var saleDetail = new Sale_Detail(StaticMain.FTSMain());
            saleDetail.DeleteAll(Guid.Parse(table.Rows[0]["PR_KEY"].ToString()));
            StaticMain.Save(saleDetail);

            var sale = new Sale(StaticMain.FTSMain());
            DataRow row = sale.GetRowWithID(Guid.Parse(table.Rows[0]["PR_KEY"].ToString()));
            sale.DeleteRow(row);
            
            return StaticMain.Save(sale);
        }



        public string Create(string models)
        {
            lock (SyncRoot)
            {
                DataTable table = StaticMain.TABLE(models);
                table.TableName = "sale";

                var sale = new Sale(StaticMain.FTSMain());

                foreach (DataRow row in table.Rows)
                {
                    row["PR_KEY"] = Guid.NewGuid();
                    row["TRAN_DATE"] = DateTime.Now;
                }

                string saleJson = StaticMain.Create(sale, table);

                if (saleJson.IndexOf("error", StringComparison.Ordinal) > 0)
                {
                    Session.Remove(StaticConst.LAST_CREATED_SALE_ID);//last save is falure, there is no last saved sale in session. 
                }
                else //last save is successed, save the last sale to session for use in subsequence creating sale detail
                {
                    DataTable saleTable = StaticMain.LoadSqlToTable("SELECT TOP 1 * FROM SALE ORDER BY TRAN_DATE DESC");
                    Session.Add(StaticConst.LAST_CREATED_SALE_ID, saleTable.Rows[0]["PR_KEY"]);
                }
                return saleJson;
            }
        }

        public string Update(string models)
        {
            
            DataTable table = StaticMain.TABLE(models);
            var sale = new Sale(StaticMain.FTSMain());
            sale.LoadDataByID(Guid.Parse(table.Rows[0]["PR_KEY"].ToString()));
            DataRow item = sale.DataTable.Rows[0];
            item["PR_KEY"] = table.Rows[0]["PR_KEY"];
            item["ORGANIZATION_ID"] = table.Rows[0]["ORGANIZATION_ID"];
            item["TRAN_ID"] = table.Rows[0]["TRAN_ID"];
            item["TRAN_DATE"] = table.Rows[0]["TRAN_DATE"];
            item["TRAN_NO"] = table.Rows[0]["TRAN_NO"];
            item["PR_DETAIL_ID"] = table.Rows[0]["PR_DETAIL_ID"];
            item["ADDRESS"] = table.Rows[0]["ADDRESS"];
            item["TAX_FILE_NUMBER"] = table.Rows[0]["TAX_FILE_NUMBER"];
            item["COMMENTS"] = table.Rows[0]["COMMENTS"];
            item["STATUS"] = table.Rows[0]["STATUS"];

            return StaticMain.Save(sale);
        }

    }
}
