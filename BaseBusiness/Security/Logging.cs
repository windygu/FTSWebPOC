#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security{
    public sealed class Logging : ObjectBase{
        public Logging(FTSMain ftsmain)
            : base(ftsmain, "Logging"){
            this.LoadData();
            this.LoadFields();
        }

        public Logging(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "Logging"){
            if (!isempty){
                this.LoadData();
            }
            this.LoadFields();
        }

        public Logging(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Logging"){
            this.LoadFields();
        }

        public override void LoadFields(){
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency, true));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTION_DATETIME", DbType.Date, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_NAME", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTION_TYPE", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DESCRIPTION", DbType.String, false));
        }
        public override void LoadData()
        {
            base.LoadData();
            if (this.DataTable.Columns.IndexOf("USER_NAME") <= 0)
            {
                DataColumn c = new DataColumn("USER_NAME", Type.GetType("System.String"));
                c.DefaultValue = string.Empty;
                this.DataTable.Columns.Add(c);
            }
            DataTable sec_user = this.FTSMain.TableManager.LoadTable("SEC_USER");
            foreach (DataRow row in this.DataTable.Rows)
            {
                if (sec_user.Rows.Find(row["USER_ID"]) != null)
                    row["USER_NAME"] = sec_user.Rows.Find(row["USER_ID"])["USER_NAME"];
            }
        }
        public static void Log(FTSMain ftsMain, string actionType, string description){
            try{
                string sql = "INSERT INTO LOGGING(USER_ID,ACTION_TYPE,ACTION_DATETIME,DESCRIPTION) VALUES(" +
                             ftsMain.BuildParameterName("USER_ID") + "," +
                             ftsMain.BuildParameterName("ACTION_TYPE") + "," +
                             ftsMain.BuildParameterName("ACTION_DATETIME") + "," +
                             ftsMain.BuildParameterName("DESCRIPTION") + ")";
                DbCommand cmd = ftsMain.DbMain.GetSqlStringCommand(sql);
                ftsMain.DbMain.AddInParameter(cmd, "USER_ID", DbType.String, ftsMain.UserInfo.UserID);
                ftsMain.DbMain.AddInParameter(cmd, "ACTION_TYPE", DbType.String, actionType);
                ftsMain.DbMain.AddInParameter(cmd, "ACTION_DATETIME", DbType.DateTime, DateTime.Now);
                ftsMain.DbMain.AddInParameter(cmd, "DESCRIPTION", DbType.String, description + " - Computer: " + ftsMain.UserInfo.ClientMachineName);
                ftsMain.DbMain.ExecuteNonQuery(cmd);
            } catch (Exception){}
        }
        public override void SetRole() {
            this.FTSFunction = FTSFunctionCollection.LOGGING;
        }
    }
}