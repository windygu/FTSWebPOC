using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Systems;
using FTS.Global.Classes;
using FTS.Global.Interface;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.AccBusiness.Sale {
    public class WarehouseManager {
        private FTSMain FTSMain;
        public bool HasCheckBusinessRules = false;
        private DataTable mDataLog = null;
        private DataTable mDmOrganization = null;
        private List<WarehouseObject> warehouseObjectList = null;

        public WarehouseManager(FTSMain ftsmain) {
            this.FTSMain = ftsmain;
            this.WarehouseObjectList = new List<WarehouseObject>();
            if (this.FTSMain.IsMultiSite) {
                this.mDataLog = this.FTSMain.TableManager.LoadTable("DATA_LOG", "1=0");
            }
        }

        public WarehouseManager(FTSMain ftsmain, DataTable dmorganization) {
            this.FTSMain = ftsmain;
            this.WarehouseObjectList = new List<WarehouseObject>();
            if (this.FTSMain.IsMultiSite) {
                this.mDataLog = this.FTSMain.TableManager.LoadTable("DATA_LOG", "1=0");
            }
            this.mDmOrganization = dmorganization;
        }

        public List<WarehouseObject> WarehouseObjectList {
            get { return this.warehouseObjectList; }
            set { this.warehouseObjectList = value; }
        }

        public void Clear() {
            this.WarehouseObjectList.Clear();
        }

        public void Add(WarehouseObject warehouseobject) {
            this.warehouseObjectList.Add(warehouseobject);
        }

        public void Update(DbTransaction tran) {
            try {
                DataSet ds = new DataSet();
                string sql = "select * from warehouse where 1=0";
                if (this.HasCheckBusinessRules == false) {
                    this.CheckBusinessRules(tran);
                }
                if (tran != null) {
                    this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), ds, "warehouse", tran);
                } else {
                    this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), ds, "warehouse");
                }
                DataTable warehousetable = ds.Tables["warehouse"];
                foreach (WarehouseObject warehouseobject in this.WarehouseObjectList) {
                    DataRow row = warehousetable.NewRow();
                    row["Pr_Key"] = warehouseobject.Pr_Key;
                    row["PR_KEY_Warehouse"] = Guid.NewGuid();
                    row["Pr_Key_Detail"] = warehouseobject.Pr_Key_Detail;
                    row["Tran_ID"] = warehouseobject.Tran_Id;
                    row["Tran_Date"] = warehouseobject.Tran_Date;
                    row["Tran_No"] = warehouseobject.Tran_No;
                    row["Item_ID"] = warehouseobject.Item_Id;
                    row["Organization_ID"] = warehouseobject.Organization_Id;
                    row["Comments"] = warehouseobject.Comments;
                    row["Quantity"] = warehouseobject.Quantity;
                    row["Issue_Receive"] = warehouseobject.Issue_Receive;
                    warehousetable.Rows.Add(row);
                    if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("WAREHOUSE"))) {
                        this.mDataLog.Clear();
                        foreach (DataRow row1 in warehousetable.Rows) {
                            ClassInfo clsInfo = (ClassInfo) Registrator.Hash["WAREHOUSE"];
                            object instance = Activator.CreateInstance(clsInfo.Type);
                            if (this.FTSMain.CommunicateManager.IsNew("WAREHOUSE")) {
                                ((IHead) instance).DataState = DataState.NEW;
                                ((IHead) instance).IdValue = row1[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row1, instance);
                                DataRow newRow = this.mDataLog.NewRow();
                                newRow["TABLE_NAME"] = "WAREHOUSE";
                                newRow["LOG_TIME"] = DateTime.Now;
                                newRow["OBJECT_VALUE"] =
                                    Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                                newRow["IS_UPLOAD"] = 0;
                                newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                                if (this.FTSMain.IsChildSite) {
                                    newRow["IS_DOWNLOAD"] = string.Empty;
                                } else {
                                    string mark = string.Empty;
                                    int number = Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                                    if (this.FTSMain.CommunicateManager.IsPulic("WAREHOUSE")) {
                                        for (int i = 0; i < number; i++) {
                                            mark = mark + "0";
                                        }
                                    } else {
                                        for (int i = 0; i < number; i++) {
                                            mark = mark + "1";
                                        }
                                    }
                                    newRow["IS_DOWNLOAD"] = mark;
                                }
                                newRow.EndEdit();
                                this.mDataLog.Rows.Add(newRow);
                            }
                        }
                        this.FTSMain.DbMain.UpdateTable(this.mDataLog,
                                                        this.FTSMain.DbMain.CreateInsertCommand("DATA_LOG", this.mDataLog,
                                                                                                "PR_KEY"), null, null,
                                                        tran);
                    }
                    this.FTSMain.DbMain.UpdateDataSet(ds, "warehouse",
                                                      this.FTSMain.DbMain.CreateInsertCommand("warehouse", warehousetable, ""),
                                                      null, null, tran);
                    ds.AcceptChanges();
                }
            } catch (FTSException ex) {
                throw ex;
            } catch (Exception ex1) {
                throw new FTSException(ex1);
            }
        }

        public void CheckBusinessRules(DbTransaction tran) {
            int count = 0;
            string tran_id = string.Empty;
            foreach (WarehouseObject warehouseobject in this.WarehouseObjectList) {
                if (tran_id != warehouseobject.Tran_Id) {
                    this.FTSMain.Sys_Lock.CheckLock(warehouseobject.Tran_Id, warehouseobject.Tran_Date);
                }
                if (string.IsNullOrEmpty(warehouseobject.Item_Id)) {
                    throw (new FTSException(null, "MSG_INVALID_ITEM_ID", "WAREHOUSE", "ITEM_ID", count));
                }
            }
        }

        public void RemoveAll(string tran_id, object pr_key) {
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("WAREHOUSE"))) {
                string sql1 = "select PR_KEY_WAREHOUSE from WAREHOUSE where tran_id=" +
                              this.FTSMain.BuildParameterName("tran_id") + " and pr_key=" +
                              this.FTSMain.BuildParameterName("pr_key"); // +" and " + organizationfilter;
                DbCommand cmd1 = this.FTSMain.DbMain.GetSqlStringCommand(sql1);
                this.FTSMain.DbMain.AddInParameter(cmd1, "tran_id", DbType.String, tran_id);
                this.FTSMain.DbMain.AddInParameter(cmd1, "pr_key", DbType.Guid, pr_key);
                DataTable warehouse;
                warehouse = this.FTSMain.DbMain.LoadDataTable(cmd1, "WAREHOUSE");
                this.mDataLog.Clear();
                foreach (DataRow row in warehouse.Rows) {
                    ClassInfo clsInfo = (ClassInfo) Registrator.Hash["WAREHOUSE"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    if (this.FTSMain.CommunicateManager.IsDelete("WAREHOUSE")) {
                        flag = true;
                        ((IHead) instance).DataState = DataState.DELETE;
                        ((IHead) instance).IdValue = row["PR_KEY_WAREHOUSE"];
                    }
                    if (flag) {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "WAREHOUSE";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite) {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        } else {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("WAREHOUSE")) {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "0";
                                }
                            } else {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            string sql = "delete from WAREHOUSE where tran_id=" + this.FTSMain.BuildParameterName("tran_id") +
                         " and pr_key=" + this.FTSMain.BuildParameterName("pr_key");
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tran_id);
            this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Guid, pr_key);
            this.FTSMain.DbMain.ExecuteNonQuery(cmd);
            if (this.FTSMain.IsMultiSite && this.mDataLog.Rows.Count > 0) {
                this.FTSMain.DbMain.UpdateTable(this.mDataLog,
                                                this.FTSMain.DbMain.CreateInsertCommand("DATA_LOG", this.mDataLog,
                                                                                        "PR_KEY"), null, null, UpdateBehavior.Standard);
                this.mDataLog.Clear();
            }
        }

        public void RemoveAll(string tran_id, object pr_key, DbTransaction tran) {
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("WAREHOUSE"))) {
                string sql1 = "select PR_KEY_WAREHOUSE from WAREHOUSE where tran_id=" +
                              this.FTSMain.BuildParameterName("tran_id") + " and pr_key=" +
                              this.FTSMain.BuildParameterName("pr_key");
                DbCommand cmd1 = this.FTSMain.DbMain.GetSqlStringCommand(sql1);
                this.FTSMain.DbMain.AddInParameter(cmd1, "tran_id", DbType.String, tran_id);
                this.FTSMain.DbMain.AddInParameter(cmd1, "pr_key", DbType.Guid, pr_key);
                DataTable warehouse;
                if (tran != null) {
                    warehouse = this.FTSMain.DbMain.LoadDataTable(cmd1, "WAREHOUSE", tran);
                } else {
                    warehouse = this.FTSMain.DbMain.LoadDataTable(cmd1, "WAREHOUSE");
                }
                this.mDataLog.Clear();
                foreach (DataRow row in warehouse.Rows) {
                    ClassInfo clsInfo = (ClassInfo) Registrator.Hash["WAREHOUSE"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    if (this.FTSMain.CommunicateManager.IsDelete("WAREHOUSE")) {
                        flag = true;
                        ((IHead) instance).DataState = DataState.DELETE;
                        ((IHead) instance).IdValue = row["PR_KEY_WAREHOUSE"];
                    }
                    if (flag) {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "WAREHOUSE";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite) {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        } else {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("WAREHOUSE")) {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "0";
                                }
                            } else {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            string sql = "delete from WAREHOUSE where tran_id=" + this.FTSMain.BuildParameterName("tran_id") +
                         " and pr_key=" + this.FTSMain.BuildParameterName("pr_key");
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tran_id);
            this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Guid, pr_key);
            this.FTSMain.DbMain.ExecuteNonQuery(cmd, tran);
            if (this.FTSMain.IsMultiSite && this.mDataLog.Rows.Count > 0) {
                this.FTSMain.DbMain.UpdateTable(this.mDataLog,
                                                this.FTSMain.DbMain.CreateInsertCommand("DATA_LOG", this.mDataLog,
                                                                                        "PR_KEY"), null, null,
                                                tran);
                this.mDataLog.Clear();
            }
        }

        public void DeleteInData(DataRow row) {
            this.DeleteInData(row["TRAN_ID"].ToString(), row["PR_KEY_WAREHOUSE"]);
        }

        public void DeleteInData(string tran_id, object pr_key_warehouse) {
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("WAREHOUSE"))) {
                string sql1 = "SELECT PR_KEY_WAREHOUSE from WAREHOUSE where tran_id=" +
                              this.FTSMain.BuildParameterName("tran_id") + " and pr_key_warehouse=" +
                              this.FTSMain.BuildParameterName("pr_key_warehouse");
                DbCommand cmd1 = this.FTSMain.DbMain.GetSqlStringCommand(sql1);
                this.FTSMain.DbMain.AddInParameter(cmd1, "tran_id", DbType.String, tran_id);
                this.FTSMain.DbMain.AddInParameter(cmd1, "pr_key_warehouse", DbType.Guid, pr_key_warehouse);
                DataTable warehouse = this.FTSMain.DbMain.LoadDataTable(cmd1, "WAREHOUSE");
                this.mDataLog.Clear();
                foreach (DataRow row in warehouse.Rows) {
                    ClassInfo clsInfo = (ClassInfo) Registrator.Hash["WAREHOUSE"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    if (this.FTSMain.CommunicateManager.IsDelete("WAREHOUSE")) {
                        flag = true;
                        ((IHead) instance).DataState = DataState.DELETE;
                        ((IHead) instance).IdValue = row["PR_KEY_WAREHOUSE"];
                    }
                    if (flag) {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "WAREHOUSE";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite) {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        } else {
                            string mark = string.Empty;
                            int number = Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("WAREHOUSE")) {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "0";
                                }
                            } else {
                                for (int i = 0; i < number; i++) {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            DbTransaction tran = null;
            try {
                using (DbConnection connection = this.FTSMain.DbMain.CreateConnection()) {
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        connection.Open();
                        if ((bool) this.FTSMain.SystemVars.GetSystemVars("USE_SNAPSHOT_TRANSACTION")) {
                            tran = connection.BeginTransaction(IsolationLevel.Snapshot);
                        } else {
                            tran = connection.BeginTransaction();
                        }
                    } else {
                        this.FTSMain.DbMain.BeginTransactionOnline();
                    }
                    string sql = "delete from WAREHOUSE where tran_id=" + this.FTSMain.BuildParameterName("tran_id") +
                                 " and pr_key_warehouse=" + this.FTSMain.BuildParameterName("pr_key_warehouse");
                    DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
                    this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tran_id);
                    this.FTSMain.DbMain.AddInParameter(cmd, "pr_key_warehouse", DbType.Guid, pr_key_warehouse);
                    this.FTSMain.DbMain.ExecuteNonQuery(cmd);
                    if (this.FTSMain.IsMultiSite && this.mDataLog.Rows.Count > 0) {
                        this.FTSMain.DbMain.UpdateTable(this.mDataLog,
                                                        this.FTSMain.DbMain.CreateInsertCommand("DATA_LOG",
                                                                                                this.mDataLog,
                                                                                                "PR_KEY"), null,
                                                        null, tran);
                        this.mDataLog.Clear();
                    }
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        tran.Commit();
                    } else {
                        this.FTSMain.DbMain.CommitTransactionOnline();
                    }
                }
            } catch (Exception ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                throw ex;
            }
        }
    }
}