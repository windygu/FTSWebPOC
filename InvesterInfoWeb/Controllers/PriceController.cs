using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using FTS.AccBusiness.Sale;


namespace FTS.InvesterInfoWeb.Controllers
{
    public class PriceController : Controller
    {
        public ActionResult PriceList()
        {
            return View();
        }

        public string Read()
        {
            return StaticMain.LoadObject(new Sale_Price(StaticMain.FTSMain()));
        }

        public string Destroy(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale_price";
            var salePrice = new Sale_Price(StaticMain.FTSMain());
            foreach (DataRow dataRow in table.Rows)
            {
                DataRow row = salePrice.GetRowWithID(Guid.Parse(dataRow["PR_KEY"].ToString()));
                salePrice.DeleteRow(row);
            }
            return StaticMain.Save(salePrice);
        }

        public string Create(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale_price";
            var salePrice = new Sale_Price(StaticMain.FTSMain());
            return StaticMain.Create(salePrice, table);
        }

        public string Update(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale_price";
            var salePrice = new Sale_Price(StaticMain.FTSMain());
            salePrice.LoadData();

            Dictionary<String, DataRow> updatingData = table.Rows.Cast<DataRow>().ToDictionary(dataRow => dataRow["PR_KEY"].ToString());

            foreach (DataRow dataRow in salePrice.DataTable.Rows)
            {
                string key = dataRow["PR_KEY"].ToString();
                if (updatingData.ContainsKey(key))
                {
                    StaticMain.CopyRow(updatingData[key], dataRow, false);
                }
            }

            return StaticMain.Save(salePrice);
        }

    }
}
