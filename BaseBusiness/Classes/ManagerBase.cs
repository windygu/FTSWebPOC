// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:47
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         ManagerBase.cs
// Project Item Filename:     ManagerBase.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.Tools;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseBusiness.Classes {
    [Serializable]
    public class ManagerBase : ManageBaseBase {
        public bool AllowCreateOtherOrg = false;
        public bool IsDataLog = true;
        public bool IsLogging = true;
        protected bool IsOrganizationFilter = false;
        private Hashtable mConfigHashTable = null;
        private DataTable mDataLog = null;
        private DataSet mDataSet;
        private FTSFunction mFTSFunction = null;
        [NonSerialized] private FTSMain mFTSMain;
        protected bool mHasCheckedRules = false;
        private FTSCollection<ObjectBase> mObjectList;
        private string mTranDateField = string.Empty;
        private string mTranId = string.Empty;
        private string mTranIdField = string.Empty;
        private string mTranNoField = string.Empty;

        public ManagerBase(FTSMain ftsmain, string tranid) {
            this.TranId = tranid;
            this.mFTSMain = ftsmain;
            this.mDataSet = new DataSet();
            this.mObjectList = new FTSCollection<ObjectBase>();
            this.LoadData();
            this.LoadConfigValue();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        public DataSet DataSet {
            get { return this.mDataSet; }
            set { this.mDataSet = value; }
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public FTSCollection<ObjectBase> ObjectList {
            get { return this.mObjectList; }
            set { this.mObjectList = value; }
        }

        public string TranDateField {
            get { return this.mTranDateField; }
            set { this.mTranDateField = value; }
        }

        public string TranIdField {
            get { return this.mTranIdField; }
            set { this.mTranIdField = value; }
        }

        public string TranNoField {
            get { return this.mTranNoField; }
            set { this.mTranNoField = value; }
        }

        public FTSFunction FTSFunction {
            get { return this.mFTSFunction; }
            set { this.mFTSFunction = value; }
        }

        public string TranId {
            get { return this.mTranId; }
            set {
                this.mTranId = value;
                this.ChangeTranId();
            }
        }

        public DataTable DataLog {
            get { return this.mDataLog; }
            set { this.mDataLog = value; }
        }

        protected virtual string GetOrganizationFilter() {
            DataTable dmorganization = this.GetDm("DM_ORGANIZATION");
            return Dm_Organization.GetOrganizationFilter(this.FTSMain, dmorganization);
        }

        public virtual void ChangeTranId() {
        }

        public virtual void AddNewData() {
            this.ClearData();
            DataRow row = this.mObjectList[0].AddNew();
            if ((bool) this.GetConfigValue("AUTO_TRAN_NO") && this.mTranNoField.Length != 0) {
                row[this.mTranNoField] = this.FTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO");
            }
            this.AddNewDetail(1);
        }

        public virtual DataRow AddNewDetail(int detailID, DataRow r) {
            if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                DataRow row = this.mObjectList[detailID].AddNew(r);
                row["fr_key"] = this.mObjectList[0].DataTable.Rows[0]["pr_key"];
                row.EndEdit();
                return row;
            }
            throw new FTSException("MSG_NO_HEADER_ROW");
        }

        public virtual DataRow AddNewDetail(int detailID) {
            if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                DataRow row = this.mObjectList[detailID].AddNew();
                row["fr_key"] = this.mObjectList[0].DataTable.Rows[0]["pr_key"];
                row.EndEdit();
                return row;
            }
            throw new FTSException("MSG_NO_HEADER_ROW");
        }

        public virtual void CopyRecord() {
            if (this.mObjectList[0].DataTable.Rows.Count == 0) {
                return;
            }
            List<DataTable> tablelist = new List<DataTable>();
            foreach (ObjectBase ob in this.mObjectList) {
                DataTable obDt = ob.DataTable.Copy();
                DataTable tmp = obDt.Clone();
                if (obDt.Columns.IndexOf("LIST_ORDER") > 0) {
                    DataView dvtmp = new DataView(ob.DataTable, "", "LIST_ORDER", DataViewRowState.CurrentRows);
                    foreach (DataRowView drv in dvtmp) {
                        DataRow nr = tmp.NewRow();
                        nr.ItemArray = (object[])drv.Row.ItemArray.Clone();
                        tmp.Rows.Add(nr);
                    }
                } else {
                    tmp = obDt;
                }
                tablelist.Add(tmp);
            }
            this.ClearData();
            for (int i = 0; i < this.mObjectList.Count; i++) {
                DataTable tmp = tablelist[i];
                foreach (DataRow row in tmp.Rows) {
                    if (i == 0) {
                        DataRow row1 = this.mObjectList[i].AddNew(row);
                        if ((bool) this.GetConfigValue("AUTO_TRAN_NO") && this.mTranNoField.Length != 0) {
                            row1[this.mTranNoField] = this.FTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO");
                        }
                    } else {
                        this.AddNewDetail(i, row);
                    }
                }
            }
        }

        public virtual DataRow CopyDetail(int detailID, int pos) {
            return this.mObjectList[detailID].CopyRecord(pos);
        }

        public virtual DataRow InsertDetail(int detailID, int pos) {
            if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                DataRow row = this.mObjectList[detailID].InsertRecord(pos);
                row["fr_key"] = this.mObjectList[0].DataTable.Rows[0]["pr_key"];
                row.EndEdit();
                return row;
            }
            throw new FTSException("MSG_NO_HEADER_ROW");
        }

        public virtual void LoadData() {
        }

        public virtual void LoadRecordWithPrkey(object key) {
            this.ClearData();
            this.mObjectList[0].LoadDataByID(key);
            for (int i = 1; i < this.mObjectList.Count; i++) {
                this.mObjectList[i].LoadDataByFrkey(key);
            }
        }

        public virtual void LoadRecordWithQuery(string query) {
        }

        public virtual void ClearData() {
            foreach (ObjectBase ob in this.mObjectList) {
                ob.Clear();
            }
        }

        public virtual void CheckLock() {
            if (this.ObjectList[0].DataTable.Rows.Count > 0 && this.TranDateField != string.Empty) {
                DataRow row = this.ObjectList[0].DataTable.Rows[0];
                switch (row.RowState) {
                    case DataRowState.Added:
                        this.FTSMain.Sys_Lock.CheckLock(this.TranId, (DateTime) row[this.TranDateField]);
                        break;
                    default:
                        this.FTSMain.Sys_Lock.CheckLock(this.TranId, (DateTime) row[this.TranDateField, DataRowVersion.Original]);
                        if (row.RowState != DataRowState.Deleted) {
                            this.FTSMain.Sys_Lock.CheckLock(this.TranId, (DateTime) row[this.TranDateField]);
                        }
                        break;
                }
            }
        }

        public virtual void UpdateDataServer() {
            for (int i = 0; i < this.ObjectList.Count; i++) {
                foreach (DataColumn col in this.ObjectList[i].DataTable.Columns) {
                    if (col.DataType == typeof (DateTime) && col.DateTimeMode == DataSetDateTime.UnspecifiedLocal) {
                        col.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
            XmlQuery tmpquery = this.mFTSMain.XmlQuery;
            this.mFTSMain.XmlQuery = null;
            MemoryStream objMS = new MemoryStream();
            BinaryFormatter objBF = new BinaryFormatter();
            objBF.Serialize(objMS, this.mFTSMain);
            objMS.Flush();
            objMS.Position = 0;
            long len = objMS.Length;
            byte[] arrFtsMain = new byte[len];
            objMS.Read(arrFtsMain, 0, (int) len);
            this.mFTSMain.XmlQuery = tmpquery;
            List<DataTable> listtable = new List<DataTable>();
            foreach (DataTable dt in this.mDataSet.Tables) {
                if (this.NotMainTable(dt.TableName)) {
                    listtable.Add(dt);
                }
            }
            foreach (DataTable dt in listtable) {
                this.mDataSet.Tables.Remove(dt);
            }
            objMS = new MemoryStream();
            objBF = new BinaryFormatter();
            objBF.Serialize(objMS, this);
            objMS.Flush();
            objMS.Position = 0;
            len = objMS.Length;
            byte[] arrFtsReport = new byte[len];
            objMS.Read(arrFtsReport, 0, (int) len);
            byte[] result = this.mFTSMain.Pfs.UpdateManagerBase(Functions.CompressByte(arrFtsMain), Functions.CompressByte(arrFtsReport));
            if (result != null) {
                using (MemoryStream stream = new MemoryStream(Functions.DecompressByte(result))) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Object obj = formatter.Deserialize(stream);
                    FTSException ftsexception = obj as FTSException;
                    if (ftsexception != null) {
                        foreach (DataTable dt in listtable) {
                            if (this.mDataSet.Tables.IndexOf(dt.TableName) < 0) {
                                this.mDataSet.Tables.Add(dt);
                            }
                        }
                        throw ftsexception;
                    } else {
                        Exception exception = obj as Exception;
                        if (exception != null) {
                            foreach (DataTable dt in listtable) {
                                if (this.mDataSet.Tables.IndexOf(dt.TableName) < 0) {
                                    this.mDataSet.Tables.Add(dt);
                                }
                            }
                            throw exception;
                        } else {
                            List<string> returnlist = obj as List<string>;
                            if (returnlist != null && returnlist.Count >= 2 && this.ObjectList[0].IsValidRow(0)) {
                                if (returnlist[0] != string.Empty) {
                                    this.ObjectList[0].DataTable.Rows[0][this.TranNoField] = returnlist[0];
                                }
                                if (returnlist[1] != string.Empty && this.ObjectList[0].DataTable.Columns.IndexOf("REFERENCE_NO") >= 0) {
                                    this.ObjectList[0].DataTable.Rows[0]["REFERENCE_NO"] = returnlist[1];
                                }
                                for (int i = 2; i < returnlist.Count; i++) {
                                    this.FTSMain.MessageList.Add(returnlist[i]);
                                }
                            }
                            foreach (DataTable dt in listtable) {
                                if (this.mDataSet.Tables.IndexOf(dt.TableName) < 0) {
                                    this.mDataSet.Tables.Add(dt);
                                }
                            }
                            this.AcceptChanges();
                        }
                    }
                }
            } else {
                foreach (DataTable dt in listtable) {
                    if (this.mDataSet.Tables.IndexOf(dt.TableName) < 0) {
                        this.mDataSet.Tables.Add(dt);
                    }
                }
                this.AcceptChanges();
            }
        }

        private bool NotMainTable(string tablename) {
            for (int i = 0; i < this.ObjectList.Count; i++) {
                if (this.ObjectList[i].TableName.ToUpper() == tablename.ToUpper()) {
                    return false;
                }
            }
            if (tablename == "DM_ORGANIZATION" || tablename == "DM_ACCOUNT" || tablename == "DM_ITEM_OP" || tablename == "DM_WAREHOUSE") {
                return false;
            }
            return true;
        }

        public virtual void UpdateDataOnline() {
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                if (this.ObjectList[0].DataTable.Rows.Count > 0) {
                    if (this.ObjectList[0].DataTable.Rows[0].RowState == DataRowState.Added) {
                        this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, this.GetOrganizationID());
                    } else {
                        if (this.ObjectList[0].DataTable.Rows[0].RowState == DataRowState.Deleted) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction, this.GetOrganizationID());
                        } else {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction, this.GetOrganizationID());
                        }
                    }
                }
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, this.GetOrganizationID());
            }
        }

        public virtual void PrepareUpdateData() {
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                if (this.ObjectList[0].DataTable.Rows.Count > 0) {
                    if (this.ObjectList[0].DataTable.Rows[0].RowState == DataRowState.Added) {
                        this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, this.GetOrganizationID());
                    } else {
                        if (this.ObjectList[0].DataTable.Rows[0].RowState == DataRowState.Deleted) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction, this.GetOrganizationID());
                        } else {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction, this.GetOrganizationID());
                        }
                    }
                }
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, this.GetOrganizationID());
            }
            this.CheckLock();
            this.EndEdit();
            this.CheckBusinessRules();
        }

        public void UpdateDataOnServer() {
            this.UpdateData();
        }

        public virtual void UpdateData() {
            string oldTran_no = string.Empty;
            string oldOtherTran_no = string.Empty;
            DbTransaction tran = null;
            try {
                //System.Diagnostics.Stopwatch  timer = new Stopwatch();
                //timer.Start();
                if (!this.mHasCheckedRules) {
                    this.PrepareUpdateData();
                }
                DataSet ds1 = this.mDataSet.GetChanges();
                if (ds1 != null) {
                    if ((bool) this.GetConfigValue("AUTO_TRAN_NO") && this.mTranNoField.Length != 0 && this.mObjectList[0].DataTable.Rows.Count > 0 && this.mObjectList[0].DataTable.Rows[0].RowState != DataRowState.Deleted) {
                        oldTran_no = this.mObjectList[0].DataTable.Rows[0][this.mTranNoField].ToString();
                        if (oldTran_no == this.FTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO").ToString()) {
                            this.mObjectList[0].DataTable.Rows[0][this.mTranNoField] = this.GetTranNoTemp(null);
                            this.CheckDuplicateTranNo();
                        }
                    }
                    oldOtherTran_no = this.GetOldOtherTranNo();
                    this.UpdateOtherTranNoTemp(null);
                    //timer.Stop();
                    //this.FTSMain.LogServerError("Before Create Other Data: " + timer.ElapsedMilliseconds);
                    //timer.Restart();
                    this.CreateOtherData();
                    //timer.Stop();
                    //this.FTSMain.LogServerError("Create Other Data time: " + timer.ElapsedMilliseconds);
                    //timer.Restart();
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
                        DataSet ds = this.mDataSet.GetChanges();
                        if (ds != null) {
                            foreach (ObjectBase ob in this.mObjectList) {
                                ob.UpdateData(ds, tran);
                            }
                            this.UpdateOtherData(tran);
                            if (oldTran_no == this.FTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO").ToString()) {
                                this.GetTranNo(tran);
                            }
                            this.UpdateOtherTranNo(oldOtherTran_no, tran);
                            if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                                tran.Commit();
                            } else {
                                this.FTSMain.DbMain.CommitTransactionOnline();
                            }
                            ds.AcceptChanges();
                            this.AcceptChanges();
                        } else {
                            if (oldTran_no == this.mFTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO").ToString()) {
                                this.mObjectList[0].DataTable.Rows[0][this.mTranNoField] = oldTran_no;
                            }
                            this.RestoreOtherTranNo(oldOtherTran_no);
                            try {
                                tran.Rollback();
                            } catch (Exception) {
                            }
                        }
                    }
                    //timer.Stop();
                    //this.FTSMain.LogServerError("Update Data time: " + timer.ElapsedMilliseconds);
                }
            } catch (FTSException ex) {
                if (oldTran_no == this.mFTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO").ToString()) {
                    this.mObjectList[0].DataTable.Rows[0][this.mTranNoField] = oldTran_no;
                }
                this.RestoreOtherTranNo(oldOtherTran_no);
                try {
                    tran.Rollback();
                } catch (Exception ex1) {
                }
                throw ex;
            } catch (Exception ex) {
                if (oldTran_no == this.mFTSMain.SystemVars.GetSystemVars("DF_EMPTY_TRANS_NO").ToString()) {
                    this.mObjectList[0].DataTable.Rows[0][this.mTranNoField] = oldTran_no;
                }
                this.RestoreOtherTranNo(oldOtherTran_no);
                try {
                    tran.Rollback();
                } catch (Exception ex1) {
                }
                throw (new FTSException(ex));
            }
        }

        protected virtual string GetOldOtherTranNo() {
            return string.Empty;
        }

        public virtual void RemoveEmptyRows() {
        }

        protected virtual void UpdateOtherData(DbTransaction tran) {
        }

        protected virtual void CreateOtherData() {
        }

        protected virtual string UpdateOtherTranNo(string oldtranno, DbTransaction tran) {
            return string.Empty;
        }

        protected virtual string UpdateOtherTranNoTemp(DbTransaction tran) {
            return string.Empty;
        }

        protected virtual void RestoreOtherTranNo(string oldtranno) {
        }

        public virtual void AcceptChanges() {
            foreach (ObjectBase ob in this.mObjectList) {
                ob.AcceptChanges();
            }
        }

        public virtual void DeleteData() {
            try {
                this.EndEdit();
                foreach (ObjectBase ob in this.mObjectList) {
                    ob.DeleteAll();
                }
                this.UpdateData();
            } catch (FTSException) {
                this.RestoreData();
                throw;
            } catch (Exception ex) {
                this.RestoreData();
                throw (new FTSException(ex));
            }
        }

        public virtual void DeleteDetail(int detailID, int pos) {
            this.EndEdit();
            this.mObjectList[detailID].DeleteAtPosition(pos);
        }

        public virtual void RestoreData() {
            this.EndEdit();
            foreach (ObjectBase ob in this.mObjectList) {
                ob.Restore();
            }
        }

        public virtual void FirstRecord() {
            string sql = "select top 1 pr_key from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField);
            if (this.IsOrganizationFilter) {
                sql += " AND " + this.GetOrganizationFilter();
            }
            sql += "  order by " + this.mTranDateField + " asc," + this.mTranNoField + " asc";
            object key = null;
            DbCommand cmd = null;
            cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
            key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
            if (key != null && key != DBNull.Value) {
                if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                    this.ClearData();
                }
                this.LoadRecordWithPrkey(key);
            }
        }

        public virtual void PreviousRecord() {
            string sql = string.Empty;
            if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                DateTime current_date = (DateTime) this.mObjectList[0].DataTable.Rows[0][this.mTranDateField];
                object current_key = this.mObjectList[0].DataTable.Rows[0]["PR_KEY"];
                sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField) + " and " + this.mTranNoField + " < " + this.mFTSMain.BuildParameterName(this.mTranNoField) + " and " + this.mTranDateField + " = " + this.mFTSMain.BuildParameterName(this.mTranDateField);
                if (this.IsOrganizationFilter) {
                    sql += " AND " + this.GetOrganizationFilter();
                }
                sql += "  order by " + this.mTranDateField + " desc," + this.mTranNoField + " desc";
                object key = null;
                DbCommand cmd = null;
                cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranDateField, DbType.Date, current_date);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranNoField, DbType.String, this.mObjectList[0].DataTable.Rows[0][this.mTranNoField]);
                key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                if (key != null && key != DBNull.Value) {
                    this.ClearData();
                    this.LoadRecordWithPrkey(key);
                } else {
                    sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField) + " and " + this.mTranDateField + " < " + this.mFTSMain.BuildParameterName(this.mTranDateField);
                    if (this.IsOrganizationFilter) {
                        sql += " AND " + this.GetOrganizationFilter();
                    }
                    sql += "  order by " + this.mTranDateField + " desc," + this.mTranNoField + " desc";
                    cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                    this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                    this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranDateField, DbType.Date, current_date);
                    key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                    if (key != null && key != DBNull.Value) {
                        this.ClearData();
                        this.LoadRecordWithPrkey(key);
                    }
                }
            } else {
                sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField);
                if (this.IsOrganizationFilter) {
                    sql += " AND " + this.GetOrganizationFilter();
                }
                sql += "  order by " + this.mTranDateField + " asc," + this.mTranNoField + " asc";
                DbCommand cmd = null;
                object key = null;
                cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                if (key != null && key != DBNull.Value) {
                    this.LoadRecordWithPrkey(key);
                }
            }
        }

        public virtual void NextRecord() {
            string sql = string.Empty;
            if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                DateTime current_date = (DateTime) this.mObjectList[0].DataTable.Rows[0][this.mTranDateField];
                string current_no = this.mObjectList[0].DataTable.Rows[0][this.mTranNoField].ToString();
                object current_key = this.mObjectList[0].DataTable.Rows[0]["PR_KEY"];
                sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranDateField + " = " + this.mFTSMain.BuildParameterName(this.mTranDateField) + " AND " + this.mTranNoField + " > " + this.mFTSMain.BuildParameterName(this.mTranNoField) + " and " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField);
                if (this.IsOrganizationFilter) {
                    sql += " AND " + this.GetOrganizationFilter();
                }
                sql += "  order by " + this.TranDateField + " asc," + this.mTranNoField + " asc";
                DbCommand cmd = null;
                object key = null;
                cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranDateField, DbType.Date, current_date);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranNoField, DbType.String, current_no);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                if (key != null && key != DBNull.Value) {
                    this.ClearData();
                    this.LoadRecordWithPrkey(key);
                } else {
                    sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField) + " and " + this.mTranDateField + " > " + this.mFTSMain.BuildParameterName(this.mTranDateField);
                    if (this.IsOrganizationFilter) {
                        sql += " AND " + this.GetOrganizationFilter();
                    }
                    sql += "  order by " + this.mTranDateField + " asc," + this.mTranNoField + " asc";
                    cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                    this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                    this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranDateField, DbType.Date, current_date);
                    key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                    if (key != null && key != DBNull.Value) {
                        this.ClearData();
                        this.LoadRecordWithPrkey(key);
                    }
                }
            } else {
                sql = "select top 1 PR_KEY from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField);
                if (this.IsOrganizationFilter) {
                    sql += " AND " + this.GetOrganizationFilter();
                }
                sql += "  order by " + this.mTranDateField + " desc," + this.mTranNoField + " desc";
                DbCommand cmd = null;
                object key = null;
                cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
                key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
                if (key != null && key != DBNull.Value) {
                    this.LoadRecordWithPrkey(key);
                }
            }
        }

        public virtual void LastRecord() {
            string sql = "select top 1 pr_key from " + this.mObjectList[0].TableNameOrig + " where " + this.mTranIdField + " = " + this.mFTSMain.BuildParameterName(this.mTranIdField);
            if (this.IsOrganizationFilter) {
                sql += " AND " + this.GetOrganizationFilter();
            }
            sql += "  order by " + this.mTranDateField + " desc," + this.mTranNoField + " desc";
            object key = null;
            DbCommand cmd = null;
            cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, this.mTranIdField, DbType.String, this.TranId);
            key = this.mFTSMain.DbMain.ExecuteScalar(cmd);
            if (key != null && key != DBNull.Value) {
                if (this.mObjectList[0].DataTable.Rows.Count > 0) {
                    this.ClearData();
                }
                this.LoadRecordWithPrkey(key);
            }
        }

        public virtual bool HasChanged() {
            foreach (ObjectBase oj in this.mObjectList) {
                if (oj.HasChanged()) {
                    return true;
                }
            }
            return false;
        }

        /*
        public virtual void LogData() {
            if ((this.mFTSMain.IsMultiSite) && (this.HasChanged())) {
                this.mDataLog.RejectChanges();
                if (this.mFTSMain.CommunicateManager.IsExit(this.ObjectList[0].TableName)) {
                    DataRow newRow = this.mDataLog.NewRow();
                    newRow["PR_KEY"] = FunctionsBase.GetPr_key("DATA_LOG", this.mFTSMain);
                    newRow["TABLE_NAME"] = this.ObjectList[0].TableName.ToUpper();
                    newRow["LOG_TIME"] = DateTime.Now;
                    newRow["OBJECT_VALUE"] =
                        Global.Utilities.Functions.Zip(Global.Utilities.Functions.DatasetToXml(this.DataSet.GetChanges()));
                    newRow["IS_UPLOAD"] = 0;
                    newRow["USER_ID"] = this.mFTSMain.UserInfo.UserID.ToUpper();
                    if (this.mFTSMain.IsChildSite) {
                        newRow["IS_DOWNLOAD"] = string.Empty;
                    } else {
                        string mark = string.Empty;
                        int number = Convert.ToInt32(this.mFTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                        for (int i = 0; i < number; i++) {
                            mark = mark + "0";
                        }
                        newRow["IS_DOWNLOAD"] = mark;
                    }
                    newRow.EndEdit();
                    this.mDataLog.Rows.Add(newRow);
                }
            }
        }
        */

        public virtual void EndEdit() {
            foreach (ObjectBase ob in this.mObjectList) {
                ob.EndEdit();
            }
        }

        public virtual void CheckBusinessRules() {
            if (this.mObjectList[0].GetActiveRow() > 0 && this.mObjectList[1].GetActiveRow() == 0) {
                throw (new FTSException("MSG_EMPTY_DETAIL"));
            }
            foreach (ObjectBase ob in this.mObjectList) {
                ob.CheckBusinessRules();
            }
            if (this.IsOrganizationFilter && !this.AllowCreateOtherOrg) {
                ObjectBase oj = this.mObjectList[0];
                if (oj.IsValidRow(0)) {
                    string organizationid = oj.GetValue("ORGANIZATION_ID").ToString();
                    bool isdependentchild = Dm_Organization.IsDependentChild(this.FTSMain, this.GetDm("DM_ORGANIZATION"), organizationid, this.FTSMain.UserInfo.OrganizationID);
                    if (oj.DataTable.Rows[0].RowState == DataRowState.Added) {
                        if (organizationid == this.FTSMain.UserInfo.OrganizationID || (isdependentchild && (bool)this.FTSMain.SystemVars.GetSystemVars("ALLOW_UPDATE_DEPENDENT_CHILD_ORG"))) {
                        } else {
                            throw (new FTSException("MSG_NOT_ALLOW_UPDATE_OTHER_ORGANIZATION"));
                        }
                    } else {
                        if (organizationid == this.FTSMain.UserInfo.OrganizationID || (isdependentchild && (bool)this.FTSMain.SystemVars.GetSystemVars("ALLOW_UPDATE_DEPENDENT_CHILD_ORG"))) {
                        } else {
                            throw (new FTSException("MSG_NOT_ALLOW_UPDATE_OTHER_ORGANIZATION"));
                        }
                        string organizationidold = oj.DataTable.Rows[0]["ORGANIZATION_ID", DataRowVersion.Original].ToString();
                        bool isdependentchildold = Dm_Organization.IsDependentChild(this.FTSMain, this.GetDm("DM_ORGANIZATION"), organizationidold, this.FTSMain.UserInfo.OrganizationID);
                        if (organizationidold == this.FTSMain.UserInfo.OrganizationID || (isdependentchildold && (bool)this.FTSMain.SystemVars.GetSystemVars("ALLOW_UPDATE_DEPENDENT_CHILD_ORG"))) {
                        } else {
                            throw (new FTSException("MSG_NOT_ALLOW_UPDATE_OTHER_ORGANIZATION"));
                        }
                    }
                } else {
                    if (oj.DataTable.Rows.Count > 0 && oj.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                        string organizationid = oj.DataTable.Rows[0]["ORGANIZATION_ID", DataRowVersion.Original].ToString();
                        bool isdependentchild = Dm_Organization.IsDependentChild(this.FTSMain, this.GetDm("DM_ORGANIZATION"), organizationid, this.FTSMain.UserInfo.OrganizationID);
                        if (organizationid == this.FTSMain.UserInfo.OrganizationID || (isdependentchild && (bool)this.FTSMain.SystemVars.GetSystemVars("ALLOW_UPDATE_DEPENDENT_CHILD_ORG"))) {
                        } else {
                            throw (new FTSException("MSG_NOT_ALLOW_UPDATE_OTHER_ORGANIZATION"));
                        }
                    }
                }
            }
        }

        public virtual void CheckDuplicateTranNo() {
        }

        public virtual void CheckDuplicateTranNo(string tranno) {
        }

        public virtual string GetTranNoTemp(DbTransaction tran) {
            if ((bool) this.GetConfigValue("TRAN_NO_BY_ORGANIZATION")) {
                return Functions.GetTranNo(this.TranId, this.GetOrganizationID(), this.FTSMain.DayStartOfCurrentYear.Year, this.mFTSMain, tran, (bool) this.mFTSMain.SystemVars.GetSystemVars("FIX_LENGTH_TRAN_NO"), (int) this.mFTSMain.SystemVars.GetSystemVars("TRAN_NO_LENGTH"), false);
            } else {
                return Functions.GetTranNo(this.TranId, string.Empty, this.FTSMain.DayStartOfCurrentYear.Year, this.mFTSMain, tran, (bool) this.mFTSMain.SystemVars.GetSystemVars("FIX_LENGTH_TRAN_NO"), (int) this.mFTSMain.SystemVars.GetSystemVars("TRAN_NO_LENGTH"), false);
            }
        }

        public virtual string GetTranNo(DbTransaction tran) {
            if ((bool) this.GetConfigValue("TRAN_NO_BY_ORGANIZATION")) {
                return Functions.GetTranNo(this.TranId, this.GetOrganizationID(), this.FTSMain.DayStartOfCurrentYear.Year, this.mFTSMain, tran, (bool) this.mFTSMain.SystemVars.GetSystemVars("FIX_LENGTH_TRAN_NO"), (int) this.mFTSMain.SystemVars.GetSystemVars("TRAN_NO_LENGTH"), true);
            } else {
                return Functions.GetTranNo(this.TranId, string.Empty, this.FTSMain.DayStartOfCurrentYear.Year, this.mFTSMain, tran, (bool) this.mFTSMain.SystemVars.GetSystemVars("FIX_LENGTH_TRAN_NO"), (int) this.mFTSMain.SystemVars.GetSystemVars("TRAN_NO_LENGTH"), true);
            }
        }

        public virtual void RefreshDm() {
        }

        public virtual void LoadDm() {
        }

        public virtual void LoadDm(string tablename) {
        }

        public virtual void SetRole() {
            this.mFTSFunction = new FTSFunction("TRAN_" + this.mTranId, "ACC", true, true, true, true, false);
        }

        public object GetDefaultValue(string fieldname) {
            return this.ObjectList[0].GetDefaultValue(fieldname);
        }

        public void SetDefaultValue(string fieldname, object value) {
            this.ObjectList[0].SetDefaultValue(fieldname, value);
        }

        public void SetConfigValue(string config_id, bool value) {
            object[] foundRow = (object[]) this.mConfigHashTable[config_id];
            if (foundRow != null) {
                foundRow[0] = value ? 1 : 0;
            }
        }

        public void SetConfigValue(string config_id, string value) {
            object[] foundRow = (object[]) this.mConfigHashTable[config_id];
            if (foundRow != null) {
                foundRow[0] = value;
            }
        }

        public virtual string GetOrganizationID() {
            if (this.ObjectList[0].DataTable.Rows.Count > 0) {
                if (this.ObjectList[0].DataTable.Columns.IndexOf("ORGANIZATION_ID") >= 0) {
                    if (this.ObjectList[0].DataTable.Rows[0].RowState != DataRowState.Deleted) {
                        return this.ObjectList[0].GetValue("ORGANIZATION_ID").ToString();
                    } else {
                        return this.ObjectList[0].DataTable.Rows[0]["ORGANIZATION_ID", DataRowVersion.Original].ToString();
                    }
                } else {
                    return string.Empty;
                }
            } else {
                return string.Empty;
            }
        }

        public virtual string GetTranClass() {
            DataRow foundrow = this.GetDm("SYS_TRAN").Rows.Find(this.TranId);
            if (foundrow != null) {
                return foundrow["TRAN_CLASS"].ToString();
            } else {
                return string.Empty;
            }
        }

        public virtual string GetTranSubClass() {
            DataRow foundrow = this.GetDm("SYS_TRAN").Rows.Find(this.TranId);
            if (foundrow != null) {
                return foundrow["TRAN_SUB_CLASS"].ToString();
            } else {
                return string.Empty;
            }
        }

        public virtual DataTable GetDm(string tablename) {
            DataTable dt = this.mDataSet.Tables[tablename];
            if (dt == null) {
                this.LoadDm(tablename);
                dt = this.mDataSet.Tables[tablename];
            }
            return dt;
        }

        public virtual DataTable GetDmNoLoad(string tablename) {
            return this.mDataSet.Tables[tablename];
        }

        private bool IsSameKey(DataRow row, List<string> keycolumnlist, object[] keys) {
            for (int i = 0; i < keycolumnlist.Count; i++) {
                if (row[keycolumnlist[i]].ToString() != keys[i].ToString()) {
                    return false;
                }
            }
            return true;
        }

        public virtual void ImportData(DataTable excelData, DataTable dm_template_detail) {
            bool dateasstring = (bool) this.FTSMain.SystemVars.GetSystemVars("EXCEL_TEMPLATE_DATE_AS_STRING");
            List<DataRow> listAdded = new List<DataRow>();
            List<DataRow> listAddedTemp = new List<DataRow>();
            List<string> keycolumnlist = new List<string>();
            foreach (DataRow item in dm_template_detail.Rows) {
                if (item["IS_PR_KEY"].ToString() == "1") {
                    keycolumnlist.Add(item["DATA_COLUMN_NAME"].ToString());
                }
            }
            object[] keys = new object[keycolumnlist.Count];
            bool start = true;
            for (int rowno = 0; rowno < excelData.Rows.Count; rowno ++) {
                DataRow row = excelData.Rows[rowno];
                if (this.IsValidExcelData(row, dm_template_detail)) {
                    if (start || !this.IsSameKey(row, keycolumnlist, keys)) {
                        this.AddNewData();
                    }
                    if (this.ObjectList[0].IsValidRow(0)) {
                        DataRow detailrow;
                        if (start || !this.IsSameKey(row, keycolumnlist, keys)) {
                            detailrow = this.ObjectList[1].DataTable.Rows[0];
                        } else {
                            detailrow = this.AddNewDetail(1);
                        }
                        foreach (DataColumn c in excelData.Columns) {
                            DataRow templaterow = dm_template_detail.Rows.Find(c.ColumnName);
                            if (this.ObjectList[0].DataTable.Columns.IndexOf(c.ColumnName) >= 0) {
                                if (templaterow != null && templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE" && dateasstring) {
                                    try {
                                        this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = Convert.ToDateTime(row[c.ColumnName], this.FTSMain.FTSCultureInfo);
                                    } catch (Exception) {
                                        this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                    }
                                } else {
                                    if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE") {
                                        try {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = Convert.ToDateTime(row[c.ColumnName], this.FTSMain.FTSCultureInfo);
                                        } catch (Exception) {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "STRING") {
                                        try {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = row[c.ColumnName].ToString();
                                        } catch (Exception) {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = string.Empty;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DECIMAL") {
                                        try {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = Convert.ToDecimal(row[c.ColumnName]);
                                        } catch (Exception) {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "INT") {
                                        try {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = Convert.ToInt32(row[c.ColumnName]);
                                        } catch (Exception) {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "BOOLEAN") {
                                        try {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = Convert.ToBoolean(row[c.ColumnName]);
                                        } catch (Exception) {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }
                                    }
                                    /*
                                    try {
                                        this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = row[c.ColumnName];
                                    } 
                                    catch (Exception) {
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE") {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "STRING") {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = string.Empty;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DECIMAL") {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "INT") {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "BOOLEAN") {
                                            this.ObjectList[0].DataTable.Rows[0][c.ColumnName] = 0;
                                        }                                        
                                    }
                                    */
                                }
                            }
                            if (this.ObjectList[1].DataTable.Columns.IndexOf(c.ColumnName) >= 0) {
                                if (templaterow != null && templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE" && dateasstring) {
                                    try {
                                        detailrow[c.ColumnName] = Convert.ToDateTime(row[c.ColumnName], this.FTSMain.FTSCultureInfo);
                                    } catch (Exception) {
                                        detailrow[c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                    }
                                } else {
                                    if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE") {
                                        try {
                                            detailrow[c.ColumnName] = Convert.ToDateTime(row[c.ColumnName], this.FTSMain.FTSCultureInfo);
                                        } catch (Exception) {
                                            detailrow[c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "STRING") {
                                        try {
                                            detailrow[c.ColumnName] = row[c.ColumnName].ToString();
                                        } catch (Exception) {
                                            detailrow[c.ColumnName] = string.Empty;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DECIMAL") {
                                        try {
                                            detailrow[c.ColumnName] = Convert.ToDecimal(row[c.ColumnName]);
                                        } catch (Exception) {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "INT") {
                                        try {
                                            detailrow[c.ColumnName] = Convert.ToInt32(row[c.ColumnName]);
                                        } catch (Exception) {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                    } else if (templaterow["DATA_TYPE"].ToString().ToUpper() == "BOOLEAN") {
                                        try {
                                            detailrow[c.ColumnName] = Convert.ToBoolean(row[c.ColumnName]);
                                        } catch (Exception) {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                    }
                                    /*
                                    try {
                                        detailrow[c.ColumnName] = row[c.ColumnName];
                                    } catch (Exception) {
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DATE") {
                                            detailrow[c.ColumnName] = this.mFTSMain.DayStartOfFirstYear;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "STRING") {
                                            detailrow[c.ColumnName] = string.Empty;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "DECIMAL") {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "INT") {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                        if (templaterow["DATA_TYPE"].ToString().ToUpper() == "BOOLEAN") {
                                            detailrow[c.ColumnName] = 0;
                                        }
                                    }
                                    */
                                }
                            }
                        }
                        for (int i = 0; i < keycolumnlist.Count; i++) {
                            keys[i] = row[keycolumnlist[i]];
                        }
                        start = false;
                        listAddedTemp.Add(row);
                        DataRow nextrow = null;
                        if (rowno < excelData.Rows.Count - 1) {
                            nextrow = excelData.Rows[rowno + 1];
                        }
                        if (nextrow != null && this.IsSameKey(nextrow, keycolumnlist, keys)) {
                        } else {
                            try {
                                this.UpdateImportRecord();
                            } catch (FTSException ex) {
                                listAddedTemp.Clear();
                                if (ex.InnerException != null) {
                                    this.LogError(this.mFTSMain, ex, /*"POLICY_NO: " + row["POLICY_NO"] + " - PR_DETAIL_ID: " + row["PR_DETAIL_ID"] + " - PRINTS_ID: " + row["PRINTS_ID"] + " - " +*/ ex.InnerException.Message);
                                } else {
                                    this.LogError(this.mFTSMain, ex, /*"POLICY_NO: " + row["POLICY_NO"] + " - PR_DETAIL_ID: " + row["PR_DETAIL_ID"] + " - PRINTS_ID: " + row["PRINTS_ID"] + " - " +*/ ex.Message);
                                }
                            }
                            foreach (DataRow row1 in listAddedTemp) {
                                listAdded.Add(row1);
                            }
                        }
                    }
                }
            }
            foreach (DataRow row in listAdded) {
                row.Delete();
            }
            excelData.AcceptChanges();
        }

        public void LogError(FTSMain mFTSMain, FTSException ex, string strErr) {
            try {
                // tao hoac tinh bien fileName
                string fileName = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
                // tao file de ghi loi
                fileName = mFTSMain.PathName + "Exceptions\\" + fileName;
                if (Functions.FileExists(fileName)) {
                    FileInfo fileinfo = new FileInfo(fileName);
                    if (fileinfo.Length > 2000000) {
                        Functions.FileDelete(fileName);
                    }
                }
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // ghi ngay thang
                m_streamWriter.WriteLine(string.Empty);
                m_streamWriter.WriteLine("{0} {1}", DateTime.Today.ToLongTimeString(), DateTime.Today.ToLongDateString());
                // ghi Message
                string msg = strErr;
                if (ex.SystemException != null) {
                    m_streamWriter.WriteLine(msg);
                    // ghi Source
                    m_streamWriter.WriteLine(ex.SystemException.Source);
                    // ghi StackTrace
                    m_streamWriter.WriteLine(ex.SystemException.StackTrace);
                    if (ex.TableName != string.Empty) {
                        m_streamWriter.WriteLine(ex.TableName);
                    }
                    if (ex.FieldName != string.Empty) {
                        m_streamWriter.WriteLine(ex.FieldName);
                    }
                } else {
                    m_streamWriter.WriteLine(msg);
                    if (ex.TableName != string.Empty) {
                        m_streamWriter.WriteLine(ex.TableName);
                    }
                    if (ex.FieldName != string.Empty) {
                        m_streamWriter.WriteLine(ex.FieldName);
                    }
                }
                m_streamWriter.Flush();
                fs.Close();
                //
            } catch (Exception) {
            }
        }

        protected virtual void UpdateImportRecord() {
            this.UpdateData();
        }

        protected bool IsValidExcelData(DataRow row, DataTable dm_template_detail) {
            foreach (DataColumn c in row.Table.Columns) {
                string columnname = c.ColumnName;
                DataRow templaterow = dm_template_detail.Rows.Find(columnname);
                if (templaterow != null) {
                    switch (templaterow["DATA_TYPE"].ToString().ToUpper()) {
                        case "STRING":
                            if (row[c.ColumnName] == System.DBNull.Value || row[c.ColumnName].ToString().Trim() == string.Empty) {
                                row[c.ColumnName] = string.Empty;
                            }
                            break;
                        case "DECIMAL":
                            if (row[c.ColumnName] == System.DBNull.Value || row[c.ColumnName].ToString().Trim() == string.Empty) {
                                row[c.ColumnName] = 0;
                            } else {
                                try {
                                    decimal cellvalue = Convert.ToDecimal(row[c.ColumnName]);
                                } catch (Exception) {
                                    return false;
                                }
                            }
                            break;
                        case "INT":
                            if (row[c.ColumnName] == System.DBNull.Value || row[c.ColumnName].ToString().Trim() == string.Empty) {
                                row[c.ColumnName] = 0;
                            } else {
                                try {
                                    Int32 cellvalue = Convert.ToInt32(row[c.ColumnName]);
                                } catch (Exception) {
                                    return false;
                                }
                            }
                            break;
                        case "BOOLEAN":
                            if (row[c.ColumnName] == System.DBNull.Value || row[c.ColumnName].ToString().Trim() == string.Empty) {
                                row[c.ColumnName] = 0;
                            } else {
                                try {
                                    Int16 cellvalue = Convert.ToInt16(row[c.ColumnName]);
                                } catch (Exception) {
                                    return false;
                                }
                            }
                            break;
                        case "DATE":
                            if (row[c.ColumnName] == System.DBNull.Value || row[c.ColumnName].ToString().Trim() == string.Empty) {
                                row[c.ColumnName] = 0;
                            } else {
                                if ((bool) this.FTSMain.SystemVars.GetSystemVars("EXCEL_TEMPLATE_DATE_AS_STRING")) {
                                    try {
                                        DateTime cellvalue = Convert.ToDateTime(row[c.ColumnName], this.FTSMain.FTSCultureInfo);
                                    } catch (Exception) {
                                        return false;
                                    }
                                } else {
                                    try {
                                        DateTime cellvalue = Convert.ToDateTime(row[c.ColumnName]);
                                    } catch (Exception) {
                                        return false;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            return true;
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (this.DataSet != null) {
                    Functions.ClearDataSet(this.DataSet);
                }
            }
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        #region ConfigValues

        public void LoadConfigValue() {
            if (this.mConfigHashTable != null) {
                this.mConfigHashTable.Clear();
            } else {
                this.mConfigHashTable = new Hashtable();
            }
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_config where tran_id= " + this.mFTSMain.BuildParameterName("tran_id"));
            this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.TranId);
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                using (IDataReader rs = this.mFTSMain.DbMain.ExecuteReader(cmd)) {
                    while (rs.Read()) {
                        this.mConfigHashTable.Add(rs["config_id"].ToString().Trim(), new object[] {rs["config_value"].ToString().Trim(), rs["config_type"].ToString().Trim()});
                    }
                }
            } else {
                DataTable dt = this.mFTSMain.DbMain.LoadDataTable(cmd, "sys_tran_config");
                foreach (DataRow row in dt.Rows) {
                    this.mConfigHashTable.Add(row["config_id"].ToString().Trim(), new object[] {row["config_value"].ToString().Trim(), row["config_type"].ToString().Trim()});
                }
            }
            this.InsertDefaultConfigs();
        }

        public object GetConfigValue(string config_id) {
            object[] foundRow = (object[]) this.mConfigHashTable[config_id];
            if (foundRow != null) {
                object giatri;
                giatri = foundRow[0];
                switch (foundRow[1].ToString().Trim()) {
                    case "STRING":
                        return giatri.ToString().Trim();
                    case "INT":
                        return Convert.ToInt32(giatri.ToString());
                    case "DECIMAL":
                        return Convert.ToDecimal(giatri.ToString(), this.mFTSMain.FTSCultureInfo);
                    case "DATE":
                        return Convert.ToDateTime(giatri.ToString(), this.mFTSMain.FTSCultureInfo);
                    case "BOOLEAN":
                        if (giatri.ToString().Trim() == "1") {
                            return true;
                        } else {
                            return false;
                        }
                    default:
                        return null;
                }
            }
            throw new FTSException("MSG_INVALID_CONFIG_ID", config_id);
        }

        protected virtual void InsertDefaultConfigs() {
        }

        public void InsertConfigValue(string config_id, string type, object default_value) {
            object[] foundRow = (object[]) this.mConfigHashTable[config_id];
            if (foundRow == null && this.TranId != string.Empty) {
                string sql = "insert into sys_tran_config(pr_key,tran_id,config_id,config_name,config_type,config_value,active,user_id) " + " values( " + this.mFTSMain.BuildParameterName("pr_key") + " , " + this.mFTSMain.BuildParameterName("tran_id") + " , " + this.mFTSMain.BuildParameterName("config_id") + " , " + this.mFTSMain.BuildParameterName("config_name") + " , " + this.mFTSMain.BuildParameterName("config_type") + " , " + this.mFTSMain.BuildParameterName("config_value") + " , " + this.mFTSMain.BuildParameterName("active") + " , " + this.mFTSMain.BuildParameterName("user_id") + ")";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency, FunctionsBase.GetPr_key("SYS_TRAN_CONFIG", this.mFTSMain));
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.TranId);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_id", DbType.String, config_id);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_name", DbType.String, config_id);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_type", DbType.String, type);
                switch (type) {
                    case "STRING":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, default_value);
                        break;
                    case "INT":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, Convert.ToString(default_value));
                        break;
                    case "DECIMAL":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, Convert.ToString(default_value, this.mFTSMain.FTSCultureInfo));
                        break;
                    case "DATE":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, Convert.ToString(default_value, this.mFTSMain.FTSCultureInfo));
                        break;
                    case "BOOLEAN":
                        if ((bool) default_value) {
                            this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, "1");
                        } else {
                            this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, "0");
                        }
                        break;
                }
                this.mFTSMain.DbMain.AddInParameter(cmd, "active", DbType.String, "1");
                this.mFTSMain.DbMain.AddInParameter(cmd, "user_id", DbType.String, this.mFTSMain.UserInfo.UserID);
                this.mFTSMain.DbMain.ExecuteNonQuery(cmd);
                this.mConfigHashTable.Add(config_id, new object[] {default_value, type});
            }
        }

        #endregion
    }
}