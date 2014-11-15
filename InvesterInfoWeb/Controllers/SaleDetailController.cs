using System;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Runtime.Serialization.Formatters;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FTS.AccBusiness.Sale;
using FTS.BaseBusiness.Business;
using FTS.ShareBusiness.Acc;
using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;

namespace FTS.InvesterInfoWeb.Controllers
{
    public class SaleDetailController : Controller
    {

        public string GetQuarterList()
        {
            return StaticMain.LoadSqlToJSON(    @"SELECT 'Q1-2014' as QNAME, '1/1/2014' as FROM_DATE, '3/31/2014' as THRU_DATE
                                                UNION 
                                                SELECT 'Q2-2014' as QNAME, '4/1/2014' as FROM_DATE, '6/30/2014' as THRU_DATE
                                                UNION 
                                                SELECT 'Q3-2014' as QNAME, '7/1/2014' as FROM_DATE, '9/30/2014' as THRU_DATE
                                                UNION 
                                                SELECT 'Q4-2014' as QNAME, '10/1/2014' as FROM_DATE, '12/31/2014' as THRU_DATE"
                );
        }


        public string SearchInvoice()
        {
            return StaticMain.LoadSqlToJSON(@"SELECT s.PR_KEY, s.TRAN_NO, s.TRAN_DATE, c.PR_DETAIL_ID, c.PR_DETAIL_NAME, sd.ITEM_ID, sd.ITEM_NAME, sd.QUANTITY, sd.UNIT_PRICE, sd.TOTAL_AMOUNT
                                        FROM SALE s, SALE_DETAIL sd, DM_PR_DETAIL c
                                        WHERE s.PR_KEY = sd.FR_KEY
                                        AND s.PR_DETAIL_ID = c.PR_DETAIL_ID"
                                      );
        }

        public ActionResult SaleDetailList()
        {
            return View();
        }

        public string Read()
        {
            return StaticMain.LoadObject(new Sale_Detail(StaticMain.FTSMain()));
        }

        public string Create(string models)
        {

            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale_detail";
           
           
            var saleDetail = new Sale_Detail(StaticMain.FTSMain());

            foreach (DataRow row in table.Rows)
            {
                row["PR_KEY"] = Guid.NewGuid();
                //Assign Sale for this Sale Detail if there is not assigned yet. 
                if (String.IsNullOrEmpty(row["FR_KEY"].ToString()))
                {
                    if (Session[StaticConst.LAST_CREATED_SALE_ID] != null)
                    {
                        row["FR_KEY"] = Session[StaticConst.LAST_CREATED_SALE_ID];
                    }
                    else
                    {
                        return StaticMain.BuildJSONString("FR_KEY",
                            "Không tìm thấy đơn hàng tương ứng cho dòng đơn hàng");
                    }
                }
            }


            return StaticMain.Create(saleDetail, table);
        }

        public string Destroy(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            table.TableName = "sale_detail";
            var saleDetail = new Sale_Detail(StaticMain.FTSMain());
            DataRow row = saleDetail.GetRowWithID(Guid.Parse(table.Rows[0]["PR_KEY"].ToString()));
            saleDetail.DeleteRow(row);
            return StaticMain.Save(saleDetail);
        }

        public string Update(string models)
        {
            DataTable table = StaticMain.TABLE(models);
            var saleDetail = new Sale_Detail(StaticMain.FTSMain());
            saleDetail.LoadDataByID(Guid.Parse(table.Rows[0]["PR_KEY"].ToString()));
            DataRow item = saleDetail.DataTable.Rows[0];
            item["PR_KEY"] = table.Rows[0]["PR_KEY"];
            item["LIST_ORDER"] = table.Rows[0]["LIST_ORDER"];
            item["ITEM_ID"] = table.Rows[0]["ITEM_ID"];
            item["ITEM_NAME"] = table.Rows[0]["ITEM_NAME"];
            item["QUANTITY"] = table.Rows[0]["QUANTITY"];
            item["UNIT_PRICE"] = table.Rows[0]["UNIT_PRICE"];
            item["AMOUNT"] = table.Rows[0]["AMOUNT"];
            item["VAT_TAX_RATE"] = table.Rows[0]["VAT_TAX_RATE"];
            item["VAT_TAX_AMOUNT"] = table.Rows[0]["VAT_TAX_AMOUNT"];
            item["TOTAL_AMOUNT"] = table.Rows[0]["TOTAL_AMOUNT"];

            return StaticMain.Save(saleDetail);
        }


        public string Populate(string data)
        {
            if (data == null)
            {
                data = "[" + Request.QueryString[0] + "]";
            }

            DataTable table = StaticMain.TABLE(data);
            DataRow row = table.Rows[0];

            var saleDetail = new Sale_Detail(StaticMain.FTSMain());
            DataTable resultTable = saleDetail.DataTable.Clone();

            DataRow formatedRow = resultTable.NewRow();
            StaticMain.CopyRow(row, formatedRow, false);

            //dummy logic to calculate amount and tax, should be replaced by PROFESSIONAL one. 
            if (formatedRow["ITEM_ID"] != null)
            {
                if (formatedRow["QUANTITY"] != null)
                {

                    formatedRow["AMOUNT"] = Decimal.Parse(formatedRow["QUANTITY"].ToString()) *
                                    Decimal.Parse(formatedRow["UNIT_PRICE"].ToString());
                    formatedRow["VAT_TAX_RATE"] = 0.1d;
                    formatedRow["VAT_TAX_AMOUNT"] = Decimal.Parse(formatedRow["VAT_TAX_RATE"].ToString()) *
                                            Decimal.Parse(formatedRow["AMOUNT"].ToString());
                    formatedRow["TOTAL_AMOUNT"] = Decimal.Parse(formatedRow["AMOUNT"].ToString()) +
                                          Decimal.Parse(formatedRow["VAT_TAX_AMOUNT"].ToString());
                }
            }

            resultTable.Rows.Add(formatedRow);
            //asdlfkjalsdf
            return StaticMain.JSON(resultTable, null);
        }
    }
}