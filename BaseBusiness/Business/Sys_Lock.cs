#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseBusiness.Business {
	[Serializable]
    public sealed class Sys_Lock : ObjectBase {
        public Sys_Lock(FTSMain ftsmain)
            : base(ftsmain, "sys_lock") {
            this.LoadData();
            this.LoadFields();
            
        }

        
        public Sys_Lock(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_lock") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Guid,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TO_DATE", DbType.Date,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DES_ORGANIZATION_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MODULE_ID", DbType.String,
                                                                               false));
        }

        public override void SetRole() {
            this.FTSFunction = FTSFunctionCollection.SYS_LOCK;
        }

        public void SetLock(string moduleid, string desorganizationid, DateTime date) {
            this.DataTable.PrimaryKey = new DataColumn[] {
                                                                 this.DataTable.Columns["ORGANIZATION_ID"],
                                                                 this.DataTable.Columns["DES_ORGANIZATION_ID"],
                                                                 this.DataTable.Columns["MODULE_ID"]
                                                             };
            DataRow row = this.DataTable.Rows.Find(new object[] { this.FTSMain.UserInfo.OrganizationID, desorganizationid, moduleid });
            this.DataTable.PrimaryKey = null;    
            if (DateTime.Compare(date, this.FTSMain.DayStartOfFirstYear) < 0) {
                if (row != null) {
                    row.Delete();
                }
            } else {
                if (row != null) {
                    row["TO_DATE"] = date;
                } else {
                    row = this.AddNew();
                    row["ORGANIZATION_ID"] = this.FTSMain.UserInfo.OrganizationID;
                    row["DES_ORGANIZATION_ID"] = desorganizationid;
                    row["MODULE_ID"] = moduleid;
                    row["TO_DATE"] = date;
                }
            }
            this.UpdateData();
        }
        public void CheckLock(string tran_id, DateTime date) {
            //if (this.FTSMain.UserInfo.UserID == "FTS_PHUNV") {
            //    return;
            //}
            this.ReLoadData();
            DataRow tranrow = this.DataSet.Tables["SYS_TRAN"].Rows.Find(tran_id);
            if (tranrow != null) {
                string moduleid = tranrow["MODULE_ID"].ToString();
                foreach (DataRow row in this.DataTable.Rows) {
                    if (row["MODULE_ID"].ToString() == string.Empty || row["MODULE_ID"].ToString() == moduleid) {
                        if (DateTime.Compare(date, (DateTime)row["TO_DATE"]) <= 0 && Functions.InListAbsolute(this.FTSMain.UserInfo.OrganizationID,Dm_Organization.GetChildOrganizationList(this.DataSet.Tables["DM_ORGANIZATION"],row["DES_ORGANIZATION_ID"].ToString()))) {
                            throw (new FTSException("MSG_TRANSACTION_IS_LOCKED", " - " + row["ORGANIZATION_ID"].ToString() + ":" + this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_ORGANIZATION"], "DM_ORGANIZATION", row["ORGANIZATION_ID"].ToString()) + " - " + row["DES_ORGANIZATION_ID"].ToString() + ":" + this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_ORGANIZATION"], "DM_ORGANIZATION", row["DES_ORGANIZATION_ID"].ToString()) + " - " + (row["MODULE_ID"].ToString() == string.Empty ? this.FTSMain.MsgManager.GetMessage("MSG_ALL_MODULE") : row["MODULE_ID"].ToString())));
                        }
                    }
                }
            }
        }
        public void CheckLockByModule(string moduleid, DateTime date) {
            //if (this.FTSMain.UserInfo.UserID == "FTS_PHUNV") {
            //    return;
            //}
            this.ReLoadData();
                foreach (DataRow row in this.DataTable.Rows) {
                    if (row["MODULE_ID"].ToString() == string.Empty || row["MODULE_ID"].ToString() == moduleid) {
                        if (DateTime.Compare(date, (DateTime)row["TO_DATE"]) <= 0 && Functions.InListAbsolute(this.FTSMain.UserInfo.OrganizationID, Dm_Organization.GetChildOrganizationList(this.DataSet.Tables["DM_ORGANIZATION"], row["DES_ORGANIZATION_ID"].ToString()))) {
                            throw (new FTSException("MSG_TRANSACTION_IS_LOCKED", " - " + row["ORGANIZATION_ID"].ToString() + ":" + this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_ORGANIZATION"], "DM_ORGANIZATION", row["ORGANIZATION_ID"].ToString()) + " - " + row["DES_ORGANIZATION_ID"].ToString() + ":" + this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_ORGANIZATION"], "DM_ORGANIZATION", row["DES_ORGANIZATION_ID"].ToString()) + " - " + (row["MODULE_ID"].ToString() == string.Empty ? this.FTSMain.MsgManager.GetMessage("MSG_ALL_MODULE") : row["MODULE_ID"].ToString())));
                        }
                    }
                }
            
        }
        private void ReLoadData() {
            string sql = "SELECT * FROM SYS_LOCK";
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            if (this.DataTable != null) {
                this.DataTable.Clear();
            }
            if (this.DataSet == null) {
                this.DataSet = new DataSet();
            }
            this.FTSMain.DbMain.LoadDataSet(cmd, this.DataSet, this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }
        public override void LoadOtherDm() {
            if (this.DataSet.Tables.IndexOf("SYS_TRAN") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN", "TRAN_ID,TRAN_NAME,MODULE_ID", "1=1");
            }
            if (this.DataSet.Tables.IndexOf("DM_ORGANIZATION") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE", "1=1");
            }
        }
    }
}