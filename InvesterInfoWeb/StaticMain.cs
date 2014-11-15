using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Text;
using System.Web;
using System.Web.Helpers;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.ShareBusiness.Acc;
using Newtonsoft.Json;

namespace FTS.InvesterInfoWeb
{
    public static class StaticMain
    {
        public static FTSMainWeb FTSMain()
        {
            return (FTSMainWeb) HttpContext.Current.Application[StaticConst.FTS_MAIN];
        }

        public static string JSON(DataTable table, Exception errors)
        {
            if (errors == null)
            {
                return ToJSONP(JsonConvert.SerializeObject(table));
            }

            return BuildJSONErrors(errors);
        }

        public static DataTable TABLE(string models)
        {
            return JsonConvert.DeserializeObject<DataTable>(models);
        }

        public static string Save(ObjectBase objectBase)
        {
            Exception ex = null;

            try
            {
                objectBase.UpdateData();
                //throw new Exception("this is example of server exception");
            }
            catch (FTSException ftsException)
            {
                ex = ftsException;
            }
            catch (Exception e)
            {
                ex = e;
            }
            
            return JSON(objectBase.DataTable, ex);
        }


        public static string Create(ObjectBase objectBase, DataTable table)
        {
            var resultTable = table.Clone();

            Exception exception = null;
            
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    if (table.Columns.Contains("PR_KEY"))
                    {
                        if (row["PR_KEY"].ToString() == string.Empty)
                        {
                            row["PR_KEY"] = Guid.NewGuid();
                        }
                    }
                    DataRow sourceRow = objectBase.AddNew(row);
                    DataRow destinationRow = resultTable.NewRow();
                    CopyRow(sourceRow, destinationRow, true);
                    resultTable.Rows.Add(destinationRow);
                }
                objectBase.UpdateData();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            
            return JSON(resultTable, exception);
        }

        private static string ToJSONP(string data)
        {
            var request = new HttpRequestWrapper(HttpContext.Current.Request);
            if (request["callback"] != null)
            {
                data = request["callback"] + "(" + data + ")";
            }
            return data;
        }

      
        
        private static string BuildJSONErrors(Exception exception)
        {
            var ftsException = exception as FTSException;
            var json = ftsException != null ? BuildJSONString(ftsException.FieldName, ftsException.Message) : BuildJSONString("SERVER", exception.Message);
            return ToJSONP(json);
        }

        public static string BuildJSONString(string errorSource, string message)
        {

            //json to carry the error will look like: 
            //{"Errors":{"Name":{"errors":["My server error"]}}}
        

            var stringBuilder = new StringBuilder("{\"Errors\":");

            string fieldName = errorSource;
            stringBuilder.Append("{").Append("\"").Append(fieldName).Append("\":{");
            stringBuilder.Append("\"").Append("errors").Append("\":[");
            stringBuilder.Append("\"").Append(message).Append("\"]}}}");
            return stringBuilder.ToString();
        }

        public static string LoadObject(ObjectBase objectBase)
        {
            objectBase.LoadData();
            return JSON(objectBase.DataTable, null);
        }

        public static string LoadSqlToJSON(string sql)
        {
           // string sql = "select FIELD_ID, '' FIELD_NAME FROM SYS_REPORTFIELD WHERE REPORT_ID= " +
            //StaticMain.FTSMain().BuildParameterName("report_id") + " order by FIELD_ID";
            DbCommand cmd = FTSMain().DbMain.GetSqlStringCommand(sql);
            //FTSMain().DbMain.AddInParameter(cmd, "report_id", DbType.String);
            return JSON(FTSMain().DbMain.LoadDataTable(cmd, "fieldlist"), null);
            
        }

        public static DataTable LoadSqlToTable(string sql)
        {
            // string sql = "select FIELD_ID, '' FIELD_NAME FROM SYS_REPORTFIELD WHERE REPORT_ID= " +
            //StaticMain.FTSMain().BuildParameterName("report_id") + " order by FIELD_ID";
            DbCommand cmd = FTSMain().DbMain.GetSqlStringCommand(sql);
            //FTSMain().DbMain.AddInParameter(cmd, "report_id", DbType.String);
            return FTSMain().DbMain.LoadDataTable(cmd, "fieldlist");

        }


        public static void CopyRow(DataRow fromRow, DataRow toRow, bool copyKey)
        {
            if (copyKey)
            {
                for (int i = 0; i < fromRow.Table.Columns.Count; i++)
                {
                    toRow[i] = fromRow[i];
                }
            }
            else
            {
                for (int i = 1; i < fromRow.Table.Columns.Count; i++)//excluded the first cell --> this supposed to be the ID field. 
                {
                    toRow[i] = fromRow[i];
                }   
            }
        }
    }
}