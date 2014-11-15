// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:47
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         ObjectBase.cs
// Project Item Filename:     ObjectBase.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.Global.Classes;
using FTS.Global.Interface;
using FTS.Tools;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseBusiness.Classes {
    [Serializable]
    public class ObjectBase : ObjectBaseBase {
        public bool IsDataLog = true;
        internal bool IsDmOrganization = false;
        protected bool IsOrganizationFilter = false;
        private string mCondittion = string.Empty;
        private Hashtable mConfigHashTable = null;
        protected DataTable mDataLog;
        [NonSerialized] private DataSet mDataSet;
        [NonSerialized] private DataTable mDataTable;
        [NonSerialized] private Hashtable mDefaultHashTable = new Hashtable();
        private string mExcludedFieldList = string.Empty;
        private FTSFunction mFTSFunction = null;
        [NonSerialized] private FTSMain mFTSMain;
        private List<FieldInfo> mFieldCollection;
        private string mFieldList = string.Empty;
        private string mNameField = string.Empty;
        private bool mNoDanhmuc = false;
        private string mTableName;
        private string mTableNameOrig;

        public ObjectBase(FTSMain ftsmain, string tablename) {
            this.mFTSMain = ftsmain;
            this.mDataSet = new DataSet();
            this.mTableName = tablename;
            this.mTableNameOrig = tablename;
            this.mExcludedFieldList = string.Empty;
            this.LoadEmptyData();
            this.LoadDataLog();
            this.SetIDNameFields();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        public ObjectBase(FTSMain ftsmain, string tablename, bool nodanhmuc) {
            this.mFTSMain = ftsmain;
            this.mNoDanhmuc = nodanhmuc;
            this.mDataSet = new DataSet();
            this.mTableName = tablename;
            this.mTableNameOrig = tablename;
            this.mExcludedFieldList = string.Empty;
            this.LoadEmptyData();
            this.LoadDataLog();
            this.SetIDNameFields();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        public ObjectBase(FTSMain ftsmain, DataSet ds, string tablename) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mTableNameOrig = tablename;
            this.mExcludedFieldList = string.Empty;
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
            this.LoadDataLog();
            this.SetIDNameFields();
            this.LoadOtherDm();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        public ObjectBase(FTSMain ftsmain, DataSet ds, string tablename, string origtablename) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mTableNameOrig = origtablename;
            this.mExcludedFieldList = string.Empty;
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
            this.LoadDataLog();
            this.SetIDNameFields();
            this.LoadOtherDm();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        public ObjectBase(FTSMain ftsmain, DataSet ds, string tablename, bool notable) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mTableNameOrig = tablename;
            this.mExcludedFieldList = string.Empty;
            if (notable) {
                this.LoadEmptyData();
            } else {
                this.mDataTable = this.mDataSet.Tables[this.mTableName];
                this.LoadOtherDm();
            }
            this.LoadDataLog();
            this.SetIDNameFields();
            this.SetRole();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.ViewAction, string.Empty);
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
        }

        #region Properties

        public string IdField {
            get {
                if (this.mFieldCollection == null) {
                    return string.Empty;
                }
                for (int i = 0; i < this.mFieldCollection.Count; i++) {
                    FieldInfo fi = this.mFieldCollection[i];
                    if ((fi).IsPrkey) {
                        return fi.FieldName;
                    }
                }
                return string.Empty;
            }
        }

        public DbType IdFieldType {
            get {
                for (int i = 0; i < this.mFieldCollection.Count; i++) {
                    FieldInfo fi = this.mFieldCollection[i];
                    if ((fi).IsPrkey) {
                        return fi.FieldType;
                    }
                }
                throw (new FTSException("MSG_NO_ID_FIELD"));
            }
        }

        public string TableName {
            get { return this.mTableName; }
            set { this.mTableName = value; }
        }

        public string TableNameOrig {
            get { return this.mTableNameOrig; }
            set { this.mTableNameOrig = value; }
        }

        public string NameField {
            get { return this.mNameField; }
            set { this.mNameField = value; }
        }

        public string FieldList {
            get { return this.mFieldList; }
            set { this.mFieldList = value; }
        }

        protected List<FieldInfo> FieldCollection {
            get { return this.mFieldCollection; }
            set { this.mFieldCollection = value; }
        }

        public string ExcludedFieldList {
            get { return this.mExcludedFieldList; }
            set { this.mExcludedFieldList = value; }
        }

        public string Condittion {
            get { return this.mCondittion; }
            set { this.mCondittion = value; }
        }

        public DataSet DataSet {
            get { return this.mDataSet; }
            set { this.mDataSet = value; }
        }

        public DataTable DataTable {
            get { return this.mDataTable; }
            set { this.mDataTable = value; }
        }

        public DataTable DataLog {
            get { return this.mDataLog; }
            set { this.mDataLog = value; }
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public FTSFunction FTSFunction {
            get { return this.mFTSFunction; }
            set { this.mFTSFunction = value; }
        }

        public bool NoDanhmuc {
            get { return this.mNoDanhmuc; }
        }

        protected Hashtable DefaultHashTable {
            get { return this.mDefaultHashTable; }
        }

        public Hashtable ConfigHashTable {
            get { return this.mConfigHashTable; }
        }

        #endregion

        public virtual void LoadDataLog() {
            if (this.mFTSMain.IsMultiSite && this.mDataLog == null) {
                this.mDataLog = this.mFTSMain.TableManager.LoadTable("DATA_LOG", "1=0");
            }
        }

        public virtual void LoadData() {
            string sql = "select * from " + this.mTableNameOrig;
            if (this.mFieldList.Length != 0) {
                sql = "select " + this.mFieldList + " from " + this.mTableNameOrig;
            }
            if (this.mCondittion.Length != 0) {
                if (this.IsOrganizationFilter) {
                    sql += " where " + this.mCondittion + " AND " + this.GetOrganizationFilter();
                } else {
                    sql += " where " + this.mCondittion + " AND " + this.FTSMain.IdManager.Filter(this.mTableNameOrig, this.FTSMain.UserInfo.OrganizationID);
                }
            } else {
                if (this.IsOrganizationFilter) {
                    sql += " where " + this.GetOrganizationFilter();
                } else {
                    sql += " where " + this.FTSMain.IdManager.Filter(this.mTableNameOrig, this.FTSMain.UserInfo.OrganizationID);
                }
            }
            if (this.IdField.Length != 0) {
                sql += " order by " + this.IdField;
            }
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            this.mFTSMain.DbMain.LoadDataSet(this.mFTSMain.DbMain.GetSqlStringCommand(sql), this.mDataSet,
                                             this.mTableName);
            this.LoadOtherDm();
        }

        public virtual void LoadDataWithTranId(string tranid) {
            string sql = "select * from " + this.mTableNameOrig + " where tran_id='" + tranid + "'";
            if (this.mFieldList.Length != 0) {
                sql = "select " + this.mFieldList + " from " + this.mTableNameOrig + " where tran_id='" + tranid + "'";
            }
            if (this.IsOrganizationFilter) {
                sql += " AND " + this.GetOrganizationFilter();
            } else {
                sql += " AND " + this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID);
            }
            if (this.mCondittion.Length != 0) {
                sql += " and " + this.mCondittion;
            }
            if (this.IdField.Length != 0) {
                sql += " order by " + this.IdField;
            }
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            this.mFTSMain.DbMain.LoadDataSet(this.mFTSMain.DbMain.GetSqlStringCommand(sql), this.mDataSet,
                                             this.mTableName);
            this.LoadOtherDm();
        }

        public virtual void LoadEmptyData() {
            string sql = "select * from " + this.mTableNameOrig + " where 1=0";
            this.mFTSMain.DbMain.LoadDataSet(this.mFTSMain.DbMain.GetSqlStringCommand(sql), this.mDataSet,
                                             this.mTableName);
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
            this.LoadOtherDm();
        }

        public virtual void LoadDataWithRow(DataRow row) {
            DataRow nr = this.mDataTable.NewRow();
            nr.ItemArray = (object[]) row.ItemArray.Clone();
            this.mDataTable.Rows.Add(nr);
            this.mDataTable.AcceptChanges();
            this.LoadOtherDm();
        }

        public virtual void LoadDataWithTable(DataTable tbl) {
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            this.mDataTable = tbl.Copy();
            this.LoadOtherDm();
        }

        public virtual void LoadDataByCommand(DbCommand cmd) {
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
            this.LoadOtherDm();
        }

        public virtual void LoadDataByID(object idvalue) {
            string sql = "select * from " + this.mTableNameOrig + " where " + this.IdField + " = " +
                         this.mFTSMain.BuildParameterName(this.IdField);
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, this.IdField, this.IdFieldType, idvalue);
            this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
            this.LoadOtherDm();
        }

        public virtual void LoadDataByFrkey(object fr_key) {
            if (this.mDataTable != null) {
                this.mDataTable.Clear();
            }
            string sql = "select * from " + this.mTableNameOrig + " where fr_key= " +
                         this.mFTSMain.BuildParameterName("fr_key");
            if (this.mDataTable != null && this.mDataTable.Columns.IndexOf("LIST_ORDER") >= 0) {
                sql += " order by list_order";
            }
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, "fr_key", this.IdFieldType, fr_key);
            this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            this.mDataTable = this.mDataSet.Tables[this.mTableName];
        }

        public virtual void LoadNextRecord(object pr_key) {
            string extCondittion = string.Empty;
            if (this.mCondittion.Length != 0) {
                extCondittion = this.mCondittion + " and ";
            }
            this.Clear();
            string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion + " pr_key > " +
                         this.mFTSMain.BuildParameterName("pr_key") + " order by pr_key asc";
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, "pr_key", this.IdFieldType, pr_key);
            this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            if (this.mDataTable.Rows.Count == 0) {
                sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion +
                      " 1=1 order by pr_key desc";
                this.Clear();
                this.mFTSMain.DbMain.LoadDataSet(this.mFTSMain.DbMain.GetSqlStringCommand(sql), this.mDataSet,
                                                 this.mTableName);
            }
        }

        public virtual void LoadRecord(object key) {
            string extCondittion = string.Empty;
            if (this.mCondittion.Length != 0) {
                extCondittion = this.mCondittion + " and ";
            }
            if (this.mDataTable.Rows.Count > 0) {
                this.Clear();
                string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion + this.IdField +
                             " = " + this.mFTSMain.BuildParameterName(this.IdField);
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.IdField, this.IdFieldType, key);
                this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            }
        }

        public virtual void LoadNextRecord() {
            string extCondittion = string.Empty;
            if (this.mCondittion.Length != 0) {
                if (this.IsOrganizationFilter) {
                    extCondittion = this.mCondittion + " AND " + this.GetOrganizationFilter() + " and ";
                } else {
                    extCondittion = this.mCondittion + " and " + this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID) + " and ";
                }
            } else {
                if (this.IsOrganizationFilter) {
                    extCondittion = this.GetOrganizationFilter() + " and ";
                } else {
                    extCondittion = this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID) + " and ";
                }
            }
            if (this.mDataTable.Rows.Count > 0) {
                object key = this.mDataTable.Rows[0][this.IdField];
                this.Clear();
                string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion + this.IdField +
                             " > " + this.mFTSMain.BuildParameterName(this.IdField) + " order by " + this.IdField +
                             " asc";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.IdField, this.IdFieldType, key);
                this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            }
            if (this.mDataTable.Rows.Count == 0) {
                string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion +
                             " 1=1  order by " + this.IdField + " desc";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            }
        }

        public virtual void LoadPreviousRecord() {
            string extCondittion = string.Empty;
            if (this.mCondittion.Length != 0) {
                if (this.IsOrganizationFilter) {
                    extCondittion = this.mCondittion + " AND " + this.GetOrganizationFilter() + " and ";
                } else {
                    extCondittion = this.mCondittion + " and " + this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID) + " and ";
                }
            } else {
                if (this.IsOrganizationFilter) {
                    extCondittion = this.GetOrganizationFilter() + " and ";
                } else {
                    extCondittion = this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID) + " and ";
                }
            }
            if (this.mDataTable.Rows.Count > 0) {
                object key = this.mDataTable.Rows[0][this.IdField];
                this.Clear();
                string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion + this.IdField +
                             " < " + this.mFTSMain.BuildParameterName(this.IdField) + " order by " + this.IdField +
                             " desc";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.IdField, this.IdFieldType, key);
                this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            }
            if (this.mDataTable.Rows.Count == 0) {
                string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion +
                             " 1=1  order by " + this.IdField + " asc";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            }
        }

        public virtual void LoadPreviousRecord(object pr_key) {
            string extCondittion = string.Empty;
            if (this.mCondittion.Length != 0) {
                extCondittion = this.mCondittion + " and ";
            }
            this.Clear();
            string sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion + " pr_key < " +
                         this.mFTSMain.BuildParameterName("pr_key") + " order by pr_key asc";
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, "pr_key", this.IdFieldType, pr_key);
            this.mFTSMain.DbMain.LoadDataSet(cmd, this.mDataSet, this.mTableName);
            if (this.mDataTable.Rows.Count == 0) {
                sql = "select top 1 * from " + this.mTableNameOrig + " where " + extCondittion +
                      " 1=1 order by pr_key asc";
                this.Clear();
                this.mFTSMain.DbMain.LoadDataSet(this.mFTSMain.DbMain.GetSqlStringCommand(sql), this.mDataSet,
                                                 this.mTableName);
            }
        }

        public virtual DataRow AddNew() {
            DataRow nr = this.mDataTable.NewRow();
            bool pr_key = false;
            foreach (FieldInfo c in this.mFieldCollection) {
                if (c.IsBound) {
                    if (c.FieldName == "PR_KEY") {
                        if (c.FieldType == DbType.Guid) {
                            nr[c.FieldName] = Guid.NewGuid();
                        } else {
                            nr[c.FieldName] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                        }
                        pr_key = true;
                    } else {
                        if (c.FieldName == "ORGANIZATION_ID") {
                            if (!this.IsDmOrganization) {
                                nr[c.FieldName] = this.mFTSMain.UserInfo.OrganizationID;
                            } else {
                                nr[c.FieldName] = string.Empty;
                            }
                        } else {
                            if (c.FieldName == "USER_ID") {
                                nr[c.FieldName] = this.mFTSMain.UserInfo.UserID;
                            } else {
                                if (c.FieldName == "ACTIVE") {
                                    nr[c.FieldName] = 1;
                                } else {
                                    if (c.FieldName == "LIST_ORDER") {
                                        nr[c.FieldName] = this.GetLastOrder() + 1;
                                    } else {
                                        if (!c.AllowDbNull) {
                                            if (c.FieldType == DbType.String) {
                                                nr[c.FieldName] = string.Empty;
                                            } else {
                                                if (c.FieldType == DbType.Date) {
                                                    nr[c.FieldName] = this.FTSMain.WorkingDay.Date;
                                                } else {
                                                    if (c.FieldType == DbType.Guid) {
                                                        nr[c.FieldName] = Guid.Empty;
                                                    } else {
                                                        nr[c.FieldName] = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (this.mDefaultHashTable[c.FieldName] != null) {
                        nr[c.FieldName] = this.GetDefaultValue(c.FieldName);
                    }
                }
            }
            if ((!pr_key) && (this.IdFieldType == DbType.String)) {
                string idauto = this.mFTSMain.TableManager.GetIdAuto(this.mTableName);
                if (idauto != string.Empty) {
                    nr[this.IdField] = idauto;
                }
            }
            this.mDataTable.Rows.Add(nr);
            return nr;
        }

        public virtual object GetDefaultValue(string fieldname) {
            return this.mDefaultHashTable[fieldname];
        }

        public virtual DataRow AddNew(DataRow row) {
            DataRow nr = this.mDataTable.NewRow();
            bool pr_key = false;
            if (row.Table.Columns.Count == this.mDataTable.Columns.Count) {
                nr.ItemArray = (object[]) row.ItemArray.Clone();
                foreach (FieldInfo c in this.mFieldCollection) {
                    if (c.IsBound) {
                        if (c.FieldName == "PR_KEY") {
                            if (c.FieldType == DbType.Guid) {
                                nr[c.FieldName] = Guid.NewGuid();
                            } else {
                                nr[c.FieldName] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                            }
                            pr_key = true;
                        } else {
                            if (c.FieldName == "LIST_ORDER") {
                                nr[c.FieldName] = this.GetLastOrder() + 1;
                            } else {
                                if (c.FieldName == "ORGANIZATION_ID") {
                                    if (!this.IsDmOrganization) {
                                        nr[c.FieldName] = this.FTSMain.UserInfo.OrganizationID;
                                    } else {
                                        nr[c.FieldName] = string.Empty;
                                    }
                                } else {
                                    if (c.FieldName == "USER_ID") {
                                        nr[c.FieldName] = this.FTSMain.UserInfo.UserID;
                                    }
                                }
                            }
                        }
                    }
                }
            } else {
                foreach (DataColumn c in this.mDataTable.Columns) {
                    if (row.Table.Columns.IndexOf(c.ColumnName) >= 0) {
                        if (c.ColumnName == "PR_KEY") {
                            if (c.DataType == Type.GetType("System.Guid")) {
                                nr[c.ColumnName] = Guid.NewGuid();
                            } else {
                                nr[c.ColumnName] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                            }
                        } else {
                            if (c.ColumnName == "LIST_ORDER") {
                                nr[c.ColumnName] = this.GetLastOrder() + 1;
                            } else {
                                if (c.ColumnName == "ORGANIZATION_ID") {
                                    if (this.IsDmOrganization) {
                                        nr[c.ColumnName] = this.FTSMain.UserInfo.OrganizationID;
                                    } else {
                                        nr[c.ColumnName] = string.Empty;
                                    }
                                } else {
                                    if (c.ColumnName == "USER_ID") {
                                        nr[c.ColumnName] = this.FTSMain.UserInfo.UserID;
                                    } else {
                                        nr[c.ColumnName] = row[c.ColumnName];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if ((!pr_key) && (this.IdFieldType == DbType.String)) {
                string idauto = this.mFTSMain.TableManager.GetIdAuto(this.mTableName);
                if (idauto != string.Empty) {
                    nr[this.IdField] = idauto;
                }
            }
            this.mDataTable.Rows.Add(nr);
            return nr;
        }

        public virtual DataRow AddRow(DataRow row) {
            DataRow nr = this.mDataTable.NewRow();
            if (row.Table.Columns.Count == this.mDataTable.Columns.Count) {
                nr.ItemArray = (object[]) row.ItemArray.Clone();
            } else {
                foreach (DataColumn c in this.mDataTable.Columns) {
                    if (row.Table.Columns.IndexOf(c.ColumnName) >= 0) {
                        nr[c.ColumnName] = row[c.ColumnName];
                    }
                }
            }
            this.mDataTable.Rows.Add(nr);
            return nr;
        }

        public virtual void AcceptChanges() {
            this.mDataTable.AcceptChanges();
        }

        public virtual DataRow CopyRecord(int pos) {
            if (pos >= 0) {
                DataRow nr = this.mDataTable.NewRow();
                bool pr_key = false;
                nr.ItemArray = (object[]) this.mDataTable.Rows[pos].ItemArray.Clone();
                if (this.mDataTable.Columns.IndexOf("PR_KEY") >= 0) {
                    if (this.mDataTable.Columns["PR_KEY"].DataType == Type.GetType("System.Guid")) {
                        nr["pr_key"] = Guid.NewGuid();
                    } else {
                        nr["pr_key"] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                    }
                    pr_key = true;
                } else {
                    if (this.mDataTable.Columns.IndexOf("LIST_ORDER") >= 0) {
                        nr["LIST_ORDER"] = this.GetLastOrder() + 1;
                    } else {
                        if (this.mDataTable.Columns.IndexOf("ORGANIZATION_ID") >= 0) {
                            if (!this.IsDmOrganization) {
                                nr["ORGANIZATION_ID"] = this.FTSMain.UserInfo.OrganizationID;
                            } else {
                                nr["ORGANIZATION_ID"] = string.Empty;
                            }
                        } else {
                            if (this.mDataTable.Columns.IndexOf("USER_ID") >= 0) {
                                nr["USER_ID"] = this.FTSMain.UserInfo.UserID;
                            }
                        }
                    }
                }
                if ((!pr_key) && (this.IdFieldType == DbType.String)) {
                    string idauto = this.mFTSMain.TableManager.GetIdAuto(this.mTableName);
                    if (idauto != string.Empty) {
                        nr[this.IdField] = idauto;
                    }
                }
                this.mDataTable.Rows.Add(nr);
                return nr;
            } else {
                return null;
            }
        }

        public virtual DataRow InsertRecord(int pos) {
            DataRow nr = this.mDataTable.NewRow();
            bool pr_key = false;
            foreach (FieldInfo c in this.mFieldCollection) {
                if (c.IsBound) {
                    if (c.FieldName == "PR_KEY") {
                        if (c.FieldType == DbType.Guid) {
                            nr[c.FieldName] = Guid.NewGuid();
                        } else {
                            nr[c.FieldName] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                        }
                        pr_key = true;
                    } else {
                        if (c.FieldName == "ORGANIZATION_ID") {
                            if (!this.IsDmOrganization) {
                                nr[c.FieldName] = this.FTSMain.UserInfo.OrganizationID;
                            } else {
                                nr[c.FieldName] = string.Empty;
                            }
                        } else {
                            if (c.FieldName == "USER_ID") {
                                nr[c.FieldName] = this.mFTSMain.UserInfo.UserID;
                            } else {
                                if (c.FieldName == "ACTIVE") {
                                    nr[c.FieldName] = 1;
                                } else {
                                    if (!c.AllowDbNull) {
                                        if (c.FieldType == DbType.String) {
                                            nr[c.FieldName] = string.Empty;
                                        } else {
                                            if (c.FieldType == DbType.Date) {
                                                nr[c.FieldName] = this.FTSMain.WorkingDay.Date;
                                            } else {
                                                if (c.FieldType == DbType.Guid) {
                                                    nr[c.FieldName] = Guid.Empty;
                                                } else {
                                                    nr[c.FieldName] = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (this.mDefaultHashTable[c.FieldName] != null) {
                        nr[c.FieldName] = this.GetDefaultValue(c.FieldName);
                    }
                }
            }
            if ((!pr_key) && (this.IdFieldType == DbType.String)) {
                string idauto = this.mFTSMain.TableManager.GetIdAuto(this.mTableName);
                if (idauto != string.Empty) {
                    nr[this.IdField] = idauto;
                }
            }
            if (pos >= 0) {
                this.mDataTable.Rows.InsertAt(nr, pos);
                if (this.mDataTable.Columns.IndexOf("LIST_ORDER") >= 0) {
                    for (int i = 0; i < this.mDataTable.Rows.Count; i++) {
                        if (this.mDataTable.Rows[i].RowState != DataRowState.Deleted) {
                            this.mDataTable.Rows[i]["LIST_ORDER"] = i;
                        }
                    }
                }
                return nr;
            } else {
                if (this.mDataTable.Columns.IndexOf("LIST_ORDER") >= 0) {
                    nr["list_order"] = 1;
                }
                this.mDataTable.Rows.Add(nr);
                return nr;
            }
        }

        public virtual DataRow CopyRecord(DataRow row) {
            if (row != null) {
                DataRow nr = this.mDataTable.NewRow();
                bool pr_key = false;
                nr.ItemArray = (object[]) row.ItemArray.Clone();
                if (this.mDataTable.Columns.IndexOf("PR_KEY") >= 0) {
                    if (this.mDataTable.Columns["PR_KEY"].DataType == Type.GetType("System.Guid")) {
                        nr["PR_KEY"] = Guid.NewGuid();
                    } else {
                        nr["PR_KEY"] = FunctionsBase.GetPr_key(this.mTableName, this.mFTSMain);
                    }
                    pr_key = true;
                }
                if (this.IdFieldType == DbType.Decimal || this.IdFieldType == DbType.Int32 ||
                    this.IdFieldType == DbType.Int16) {
                    nr[this.IdField] = 0;
                } else {
                    if (this.IdFieldType == DbType.String) {
                        nr[this.IdField] = string.Empty;
                    }
                }
                if (this.mDataTable.Columns.IndexOf("LIST_ORDER") >= 0) {
                    nr["LIST_ORDER"] = this.GetLastOrder() + 1;
                }
                if (this.mDataTable.Columns.IndexOf("ORGANIZATION_ID") >= 0) {
                    if (!this.IsDmOrganization) {
                        nr["ORGANIZATION_ID"] = this.FTSMain.UserInfo.OrganizationID;
                    } else {
                        nr["ORGANIZATION_ID"] = string.Empty;
                    }
                }
                if ((!pr_key) && (this.IdFieldType == DbType.String)) {
                    string idauto = this.mFTSMain.TableManager.GetIdAuto(this.mTableName);
                    if (idauto != string.Empty) {
                        nr[this.IdField] = idauto;
                    }
                }
                this.mDataTable.Rows.Add(nr);
                return nr;
            } else {
                return null;
            }
        }

        public virtual void UpdateData(DataSet ds, DbTransaction transaction) {
            //if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
            //    if (this.mFTSFunction!= null && this.DataTable.Rows.Count > 0) {
            //        if (this.DataTable.Rows[0].RowState == DataRowState.Added) {
            //            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, string.Empty);
            //        } else {
            //            if (this.DataTable.Rows[0].RowState == DataRowState.Deleted) {
            //                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction,
            //                                                           string.Empty);
            //            } else {
            //                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction, string.Empty);
            //            }
            //        }
            //    }
            //} else {
            //    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            //}
            this.LogData(ds);
            this.mFTSMain.DbMain.UpdateDataSet(ds, this.mTableName,
                                               this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName, this.mDataTable,
                                                                                        this.mExcludedFieldList),
                                               this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName, this.mDataTable,
                                                                                        this.IdField,
                                                                                        this.mExcludedFieldList),
                                               this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName, this.mDataTable,
                                                                                        this.IdField), transaction);
            if (this.mFTSMain.IsMultiSite) {
                this.mFTSMain.DbMain.UpdateTable(this.mDataLog,
                                                 this.mFTSMain.DbMain.CreateInsertCommand("DATA_LOG", this.mDataLog,
                                                                                          "PR_KEY"),
                                                 this.mFTSMain.DbMain.CreateUpdateCommand("DATA_LOG", this.mDataLog,
                                                                                          "PR_KEY", "PR_KEY"),
                                                 this.mFTSMain.DbMain.CreateDeleteCommand("DATA_LOG", this.mDataLog,
                                                                                          "PR_KEY"), transaction);
            }
        }

        public virtual void UpdateData(DataSet ds) {
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                if (this.mFTSFunction != null && this.DataTable.Rows.Count > 0) {
                    if (this.DataTable.Rows[0].RowState == DataRowState.Added) {
                        this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, string.Empty);
                    } else {
                        if (this.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction,
                                                                       string.Empty);
                        } else {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction, string.Empty);
                        }
                    }
                }
            } else {
                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
            }
            this.mFTSMain.DbMain.UpdateDataSet(ds, this.mTableName,
                                               this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName, this.mDataTable,
                                                                                        this.mExcludedFieldList),
                                               this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName, this.mDataTable,
                                                                                        this.IdField,
                                                                                        this.mExcludedFieldList),
                                               this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName, this.mDataTable,
                                                                                        this.IdField),
                                               UpdateBehavior.Standard);
        }

        public virtual bool UpdateData(bool HasCheckRules, Exception exceptionout) {
            DbTransaction tran = null;
            try {
                this.EndEdit();
                if (HasCheckRules) {
                    this.CheckBusinessRules();
                }
                this.LogData(null);
                if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                    if (this.mFTSFunction != null && this.IsValidRow(0)) {
                        if (this.DataTable.Rows[0].RowState == DataRowState.Added) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, string.Empty);
                        } else {
                            if (this.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction,
                                                                           string.Empty);
                            } else {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction,
                                                                           string.Empty);
                            }
                        }
                    }
                } else {
                    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
                }
                if (this.mFTSMain.IsMultiSite) {
                    using (DbConnection connection = this.mFTSMain.DbMain.CreateConnection()) {
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
                        this.mFTSMain.DbMain.UpdateDataSet(this.mDataSet, this.mTableName,
                                                           this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.
                                                                                                        mExcludedFieldList),
                                                           this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.IdField,
                                                                                                    this.
                                                                                                        mExcludedFieldList),
                                                           this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.IdField), tran);
                        this.mFTSMain.DbMain.UpdateTable(this.mDataLog,
                                                         this.mFTSMain.DbMain.CreateInsertCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateUpdateCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY", "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateDeleteCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"), tran);
                        if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                            tran.Commit();
                        } else {
                            this.FTSMain.DbMain.CommitTransactionOnline();
                        }
                        this.mDataSet.Tables[this.mTableName].AcceptChanges();
                    }
                } else {
                    this.mFTSMain.DbMain.UpdateDataSet(this.mDataSet, this.mTableName,
                                                       this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.mExcludedFieldList),
                                                       this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.IdField,
                                                                                                this.mExcludedFieldList),
                                                       this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.IdField),
                                                       UpdateBehavior.Standard);
                    this.mDataSet.Tables[this.mTableName].AcceptChanges();
                }
                exceptionout = null;
                return true;
            } catch (Exception ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                exceptionout = ex;
                //this.FTSMain.ExceptionManager.HandlingDbException(ex, this.DataTable, this.TableNameOrig, this.IdField);
                return false;
            }
        }

        public virtual void UpdateData() {
            DbTransaction tran = null;
            try {
                this.EndEdit();
                this.CheckBusinessRules();
                this.LogData(null);
                if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                    if (this.mFTSFunction != null && this.IsValidRow(0)) {
                        if (this.DataTable.Rows[0].RowState == DataRowState.Added) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, string.Empty);
                        } else {
                            if (this.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction,
                                                                           string.Empty);
                            } else {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction,
                                                                           string.Empty);
                            }
                        }
                    }
                } else {
                    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
                }
                if (this.mFTSMain.IsMultiSite) {
                    using (DbConnection connection = this.mFTSMain.DbMain.CreateConnection()) {
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
                        this.mFTSMain.DbMain.UpdateDataSet(this.mDataSet, this.mTableName,
                                                           this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.
                                                                                                        mExcludedFieldList),
                                                           this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.IdField,
                                                                                                    this.
                                                                                                        mExcludedFieldList),
                                                           this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName,
                                                                                                    this.mDataTable,
                                                                                                    this.IdField), tran);
                        this.mFTSMain.DbMain.UpdateTable(this.mDataLog,
                                                         this.mFTSMain.DbMain.CreateInsertCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateUpdateCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY", "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateDeleteCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"), tran);
                        if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                            tran.Commit();
                        } else {
                            this.FTSMain.DbMain.CommitTransactionOnline();
                        }
                        this.mDataSet.Tables[this.mTableName].AcceptChanges();
                    }
                } else {
                    this.mFTSMain.DbMain.UpdateDataSet(this.mDataSet, this.mTableName,
                                                       this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.mExcludedFieldList),
                                                       this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.IdField,
                                                                                                this.mExcludedFieldList),
                                                       this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName,
                                                                                                this.mDataTable,
                                                                                                this.IdField),
                                                       UpdateBehavior.Standard);
                    this.mDataSet.Tables[this.mTableName].AcceptChanges();
                }
            } catch (Exception ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                //this.FTSMain.ExceptionManager.HandlingDbException(ex, this.DataTable, this.TableNameOrig, this.IdField);
                throw;
            }
        }

        public virtual void UpdateData(DbTransaction tran) {
            try {
                this.EndEdit();
                this.CheckBusinessRules();
                this.LogData(null);
                if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                    if (this.mFTSFunction != null && this.IsValidRow(0)) {
                        if (this.DataTable.Rows[0].RowState == DataRowState.Added) {
                            this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.AddAction, string.Empty);
                        } else {
                            if (this.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction,
                                                                           string.Empty);
                            } else {
                                this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.EditAction,
                                                                           string.Empty);
                            }
                        }
                    }
                } else {
                    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
                }
                this.mFTSMain.DbMain.UpdateDataSet(this.mDataSet, this.mTableName,
                                                   this.mFTSMain.DbMain.CreateInsertCommand(this.mTableName,
                                                                                            this.mDataTable,
                                                                                            this.mExcludedFieldList),
                                                   this.mFTSMain.DbMain.CreateUpdateCommand(this.mTableName,
                                                                                            this.mDataTable,
                                                                                            this.IdField,
                                                                                            this.mExcludedFieldList),
                                                   this.mFTSMain.DbMain.CreateDeleteCommand(this.mTableName,
                                                                                            this.mDataTable,
                                                                                            this.IdField), tran);
                if (this.IsDataLog && this.mFTSMain.IsMultiSite) {
                    this.mFTSMain.DbMain.UpdateTable(this.mDataLog,
                                                     this.mFTSMain.DbMain.CreateInsertCommand("DATA_LOG", this.mDataLog,
                                                                                              "PR_KEY"),
                                                     this.mFTSMain.DbMain.CreateUpdateCommand("DATA_LOG", this.mDataLog,
                                                                                              "PR_KEY", "PR_KEY"),
                                                     this.mFTSMain.DbMain.CreateDeleteCommand("DATA_LOG", this.mDataLog,
                                                                                              "PR_KEY"), tran);
                }
                this.mDataSet.Tables[this.mTableName].AcceptChanges();
            } catch (Exception ex) {
                //this.FTSMain.ExceptionManager.HandlingDbException(ex, this.DataTable, this.TableNameOrig, this.IdField);
                throw;
            }
        }

        public virtual void LogData(DataSet ds) {
            if (this.mFTSMain.IsMultiSite) {
                this.mDataLog.RejectChanges();
            }
            if (this.IsDataLog && (this.mFTSMain.IsMultiSite) && (this.mFTSMain.CommunicateManager.IsExit(this.mTableName))) {
                DataTable dt;
                if (ds == null) {
                    dt = this.mDataTable;
                } else {
                    dt = ds.Tables[this.TableName];
                }
                foreach (DataRow row in dt.Rows) {
                    ClassInfo clsInfo = (ClassInfo) Registrator.Hash[this.mTableName.ToUpper()];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    switch (row.RowState) {
                        case DataRowState.Added:
                            if (this.mFTSMain.CommunicateManager.IsNew(this.mTableName)) {
                                flag = true;
                                ((IHead) instance).DataState = DataState.NEW;
                                ((IHead) instance).IdValue = row[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Modified:
                            if (this.mFTSMain.CommunicateManager.IsEdit(this.mTableName)) {
                                flag = true;
                                ((IHead) instance).DataState = DataState.EDIT;
                                ((IHead) instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Deleted:
                            if (this.mFTSMain.CommunicateManager.IsDelete(this.mTableName)) {
                                flag = true;
                                ((IHead) instance).DataState = DataState.DELETE;
                                ((IHead) instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRowDeleted(row, instance);
                            }
                            break;
                        default:
                            break;
                    }
                    if (flag) {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = this.mTableName.ToUpper();
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.mFTSMain.UserInfo.UserID.ToUpper();
                        if (this.mFTSMain.IsChildSite) {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        } else {
                            string mark = string.Empty;
                            int number = Convert.ToInt32(this.mFTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.mFTSMain.CommunicateManager.IsPulic(this.mTableName)) {
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
        }

        public virtual void EndEdit() {
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    row.EndEdit();
                }
            }
        }

        public virtual void CheckBusinessRules() {
            bool keystring = false;
            if (this.IdField.Length != 0 && this.IdFieldType == DbType.String) {
                keystring = true;
            }
            int pos = 0;
            foreach (DataRow row in this.mDataTable.Rows) {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified) {
                    foreach (FieldInfo c in this.mFieldCollection) {
                        if (c.IsRequired && this.mDataTable.Columns.IndexOf(c.FieldName) >= 0 &&
                            row[c.FieldName].ToString().Trim().Length == 0) {
                            throw (new FTSException(null, "DATA_EMPTY_FIELD", this.mTableNameOrig, c.FieldName, pos));
                        }
                        if ((c.FieldType == DbType.Currency) && (this.mDataTable.Columns.IndexOf(c.FieldName) >= 0)) {
                            try {
                                if ((Convert.ToDecimal(row[c.FieldName])) < (Decimal) (-922337203685477.5808) ||
                                    (Convert.ToDecimal(row[c.FieldName])) > (Decimal) (922337203685477.5807)) {
                                    throw (new FTSException(null, "DATA_NUMBER_OVERFLOW", this.mTableNameOrig,
                                                            c.FieldName, pos));
                                }
                            } catch (Exception e1) {
                                int i = 3;
                                throw e1;
                            }
                        }
                    }
                    if (keystring) {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified) {
                            string idvalue = row[this.IdField].ToString().Replace(" ", string.Empty);
                            if (row[this.IdField].ToString() != idvalue) {
                                row[this.IdField] = idvalue;
                                row.EndEdit();
                            }
                            if (row[this.IdField].ToString() == string.Empty) {
                                throw (new FTSException(null, "EMPTY_ID_FIELD", this.mTableNameOrig, this.IdField, pos));
                            }
                            if (this.NameField != string.Empty && row[this.NameField].ToString() == string.Empty) {
                                throw (new FTSException(null, "EMPTY_NAME_FIELD", this.mTableNameOrig, this.NameField,
                                                        pos));
                            }
                            if (Functions.IsTiengViet(row[this.IdField].ToString())) {
                                throw (new FTSException(null, "DATA_SPECIAL_CHARACTER", this.mTableNameOrig,
                                                        this.IdField, pos));
                            }
                            try {
                                if (row.RowState == DataRowState.Added) {
                                    this.FTSMain.IdManager.Validate(this.DataTable, this.mTableNameOrig,
                                                                    (string) row[this.IdField]);
                                } else {
                                    this.FTSMain.IdManager.Validate(this.DataTable, this.mTableNameOrig,
                                                                    (string) row[this.IdField, DataRowVersion.Original]);
                                }
                            } catch (FTSException ex) {
                                throw (new FTSException(null, ex.ExceptionID, this.mTableNameOrig, this.IdField, pos));
                            }
                        }
                    }
                    pos++;
                } else {
                    if (keystring && row.RowState == DataRowState.Deleted) {
                        try {
                            this.FTSMain.IdManager.ValidateDelete(this.DataTable, this.mTableNameOrig,
                                                                  (string) row[this.IdField, DataRowVersion.Original]);
                        } catch (FTSException ex) {
                            throw (new FTSException(null, ex.ExceptionID, this.mTableNameOrig, this.IdField, pos));
                        }
                    }
                    pos++;
                }
            }
        }

        public virtual void DeleteAll() {
            base.DeleteAllBase(this.mDataTable);
        }

        public virtual void DeleteAll(object fr_key) {
            base.DeleteAllBase(this.DataTable, fr_key);
        }

        public virtual void DeleteAllWithFilter(string filter) {
            List<DataRow> list = new List<DataRow>();
            DataView dv = new DataView(this.DataTable, filter, "", DataViewRowState.CurrentRows);
            foreach (DataRowView drv in dv) {
                list.Add(drv.Row);
            }
            foreach (DataRow row in list) {
                row.Delete();
            }
        }

        public virtual void DeleteWithID(object rowKeyValue) {
            if (this.IdField != null) {
                DataColumn[] oldprimarykey = this.mDataTable.PrimaryKey;
                this.mDataTable.PrimaryKey = new DataColumn[] {this.mDataTable.Columns[this.IdField]};
                DataRow nr = this.mDataTable.Rows.Find(rowKeyValue);
                if ((nr != null) && (nr.RowState != DataRowState.Deleted)) {
                    nr.Delete();
                }
                this.mDataTable.PrimaryKey = oldprimarykey;
            }
        }

        public virtual void DeleteAtPosition(int position) {
            if (this.IsValidRow(position)) {
                this.mDataTable.Rows[position].Delete();
            }
        }

        public virtual void DeleteRow(DataRow row) {
            if (this.IsValidRow(row)) {
                row.Delete();
            }
        }

        public virtual void DeleteInData(object id) {
            DbTransaction tran = null;
            try {
                if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.DeleteAction, string.Empty);
                } else {
                    this.FTSMain.SecurityManager.CheckSecurity(this.mFTSFunction, DataAction.UpdateAction, string.Empty);
                }
                try {
                    this.FTSMain.IdManager.ValidateDelete(this.DataTable, this.mTableNameOrig, id.ToString());
                } catch (FTSException ex) {
                    throw (new FTSException(null, ex.ExceptionID, this.mTableNameOrig, this.IdField, 0));
                }
                if (this.mFTSMain.IsMultiSite) {
                    this.mDataLog.RejectChanges();
                }
                if (this.IsDataLog && (this.mFTSMain.IsMultiSite) && (this.mFTSMain.CommunicateManager.IsExit(this.mTableName))) {
                    ClassInfo clsInfo = (ClassInfo) Registrator.Hash[this.mTableName.ToUpper()];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    if (this.mFTSMain.CommunicateManager.IsDelete(this.mTableName)) {
                        flag = true;
                        ((IHead) instance).DataState = DataState.DELETE;
                        ((IHead) instance).IdValue = id;
                    }
                    if (flag) {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = this.mTableName.ToUpper();
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.mFTSMain.UserInfo.UserID.ToUpper();
                        if (this.mFTSMain.IsChildSite) {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        } else {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.mFTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.mFTSMain.CommunicateManager.IsPulic(this.mTableName)) {
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
                string sqlquery = "delete from " + this.mTableNameOrig + " where " + this.IdField + "= " +
                                  this.mFTSMain.BuildParameterName(this.IdField);
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sqlquery);
                this.mFTSMain.DbMain.AddInParameter(cmd, this.IdField, this.IdFieldType, id);
                if (this.IsDataLog && this.mFTSMain.IsMultiSite) {
                    using (DbConnection connection = this.mFTSMain.DbMain.CreateConnection()) {
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
                        this.mFTSMain.DbMain.ExecuteNonQuery(cmd, tran);
                        this.mFTSMain.DbMain.UpdateTable(this.mDataLog,
                                                         this.mFTSMain.DbMain.CreateInsertCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateUpdateCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY", "PR_KEY"),
                                                         this.mFTSMain.DbMain.CreateDeleteCommand("DATA_LOG",
                                                                                                  this.mDataLog,
                                                                                                  "PR_KEY"), tran);
                        if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                            tran.Commit();
                        } else {
                            this.FTSMain.DbMain.CommitTransactionOnline();
                        }
                        this.mDataLog.AcceptChanges();
                    }
                } else {
                    this.mFTSMain.DbMain.ExecuteNonQuery(cmd);
                }
                DataRow row = this.GetRowWithID(id);
                if (row != null && row.RowState != DataRowState.Deleted) {
                    row.Delete();
                }
                this.AcceptChanges();
            } catch (Exception ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                //this.FTSMain.ExceptionManager.HandlingDbException(ex, this.DataTable, this.TableNameOrig, this.IdField);
                throw;
            }
        }

        public virtual void Clear() {
            this.mDataTable.Clear();
        }

        public virtual void Restore() {
            this.mDataTable.RejectChanges();
        }

        public virtual bool HasChanged() {
            return this.mDataSet.HasChanges();
        }

        public virtual void SetIDNameFields() {
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
        }

        protected virtual int GetLastOrder() {
            DataView dv = new DataView(this.mDataTable, string.Empty, "LIST_ORDER desc", DataViewRowState.CurrentRows);
            if (dv.Count > 0) {
                return Convert.ToInt32(dv[0]["list_order"]);
            } else {
                return 0;
            }
        }

        public DataRow GetRowWithID(object id) {
            if (this.mDataTable.PrimaryKey == null || this.mDataTable.PrimaryKey.Length == 0) {
                DataView dv = new DataView(this.mDataTable, string.Empty, this.IdField, DataViewRowState.CurrentRows);
                DataRowView[] drv = dv.FindRows(id);
                if (drv.Length > 0) {
                    return drv[0].Row;
                } else {
                    return null;
                }
            } else {
                return this.mDataTable.Rows.Find(id);
            }
        }

        public virtual int GetRowIndex(DataRow row) {
            IEnumerator ice = this.mDataTable.Rows.GetEnumerator();
            ice.Reset();
            int i = 0;
            while (ice.MoveNext()) {
                if (((ice.Current)) == row) {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public virtual FieldInfo GetFieldInfo(string fieldname) {
            for (int i = 0; i < this.mFieldCollection.Count; i++) {
                if (string.Compare((this.mFieldCollection[i]).FieldName, fieldname, true) == 0) {
                    return this.mFieldCollection[i];
                }
            }
            throw (new FTSException("INVALID_FIELD_NAME", new object[] {fieldname}, this.mTableNameOrig, fieldname, -1));
        }

        public virtual void SetValue(int pos, string fieldname, object colvalue) {
            if (this.IsValidRow(pos)) {
                this.mDataTable.Rows[pos][fieldname] = colvalue;
            }
        }

        public virtual void SetValue(DataRow row, string fieldname, object colvalue) {
            row[fieldname] = colvalue;
        }

        public virtual void SetValueIfChange(DataRow row, string fieldname, object colvalue) {
            if (this.IsValidRow(row)) {
                if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.String")) {
                    if (!row[fieldname].ToString().Trim().Equals(colvalue.ToString().Trim())) {
                        row[fieldname] = colvalue;
                        row.EndEdit();
                    }
                } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Decimal")) {
                    if ((decimal)row[fieldname] != Convert.ToDecimal(colvalue)) {
                        row[fieldname] = colvalue;
                        row.EndEdit();
                    }
                } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Guid")) {
                    if ((Guid)row[fieldname] != (Guid)colvalue) {
                        row[fieldname] = colvalue;
                        row.EndEdit();
                    }
                } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Int32")) {
                    if ((Int32)row[fieldname] != Convert.ToInt32(colvalue)) {
                        row[fieldname] = colvalue;
                        row.EndEdit();
                    }
                } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Int16")) {
                    if ((Int16)row[fieldname] != Convert.ToInt16(colvalue)) {
                        row[fieldname] = colvalue;
                        row.EndEdit();
                    }
                } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.DateTime")) {
                    if (row[fieldname] == DBNull.Value) {
                        if (colvalue != DBNull.Value) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else {
                        if (colvalue != DBNull.Value) {
                            if ((DateTime)row[fieldname] != (DateTime)colvalue) {
                                row[fieldname] = colvalue;
                                row.EndEdit();
                            }
                        } else {
                            row[fieldname] = colvalue;
                        }
                    }
                }
            }
        }

        public virtual void SetValue(string fieldname, object colvalue) {
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.String")) {
                        if (!row[fieldname].ToString().Trim().Equals(colvalue.ToString().Trim())) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Decimal")) {
                        if ((decimal) row[fieldname] != Convert.ToDecimal(colvalue)) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Guid")) {
                        if ((Guid) row[fieldname] != (Guid) colvalue) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Int32")) {
                        if ((Int32) row[fieldname] != Convert.ToInt32(colvalue)) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.Int16")) {
                        if ((Int16) row[fieldname] != Convert.ToInt16(colvalue)) {
                            row[fieldname] = colvalue;
                            row.EndEdit();
                        }
                    } else if (this.DataTable.Columns[fieldname].DataType == Type.GetType("System.DateTime")) {
                        if (row[fieldname] == DBNull.Value) {
                            if (colvalue != DBNull.Value) {
                                row[fieldname] = colvalue;
                                row.EndEdit();
                            }
                        } else {
                            if (colvalue != DBNull.Value) {
                                if ((DateTime) row[fieldname] != (DateTime) colvalue) {
                                    row[fieldname] = colvalue;
                                    row.EndEdit();
                                }
                            } else {
                                row[fieldname] = colvalue;
                            }
                        }
                    }
                }
            }
        }

        public virtual decimal SumColumn(string field) {
            decimal s = 0;
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    s += (decimal) row[field];
                }
            }
            return s;
        }

        public decimal SumColumn(string field, string condition) {
            DataView dv = new DataView(this.mDataTable, condition, string.Empty, DataViewRowState.CurrentRows);
            decimal s = 0;
            foreach (DataRowView drv in dv) {
                if (this.IsValidRow(drv.Row)) {
                    s += (decimal) drv[field];
                }
            }
            return s;
        }

        public string GetFieldList() {
            StringBuilder list = new StringBuilder();
            foreach (DataColumn c in this.mDataTable.Columns) {
                list.Append(c.ColumnName).Append(",");
            }
            if (list.Length != 0) {
                list.Remove(list.Length - 1, 1);
            }
            return list.ToString();
        }

        public ObjectBase Copy() {
            ObjectBase oj = (ObjectBase) this.MemberwiseClone();
            oj.mDataSet = this.mDataSet.Copy();
            return oj;
        }

        /*
        public bool HasSumFields()
        {
            for (int i = 0; i < this.mFieldCollection.Count; i++)
            {
                FieldInfo fi = this.mFieldCollection[i];
                if ((fi).IsSum)
                {
                    return true;
                }
            }
            return false;
        }
        */

        public object GetFirstRowValue(string fieldname) {
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    return row[fieldname];
                }
            }
            if (this.GetFieldInfo(fieldname).FieldType == DbType.String) {
                return string.Empty;
            } else {
                if (this.GetFieldInfo(fieldname).FieldType == DbType.Decimal ||
                    this.GetFieldInfo(fieldname).FieldType == DbType.Int32 ||
                    this.GetFieldInfo(fieldname).FieldType == DbType.Currency) {
                    return 0;
                } else {
                    return null;
                }
            }
        }

        public int GetFirstRowPos() {
            for (int i = 0; i < this.mDataTable.Rows.Count; i++) {
                if (this.IsValidRow(i)) {
                    return i;
                }
            }
            return -1;
        }

        public DataRow GetFirstRow() {
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    return row;
                }
            }
            return null;
        }

        public int GetActiveRow() {
            int i = 0;
            foreach (DataRow row in this.mDataTable.Rows) {
                if (this.IsValidRow(row)) {
                    i++;
                }
            }
            return i;
        }

        public object GetValue(string fieldname) {
            return this.GetValue(0, fieldname);
        }

        public object GetValue(int pos, string fieldname) {
            if (this.IsValidRow(pos)) {
                return this.DataTable.Rows[pos][fieldname];
            }
            throw new FTSException("MSG_NO_CURRENTROW");
        }

        public object GetValue(DataRow row, string fieldname) {
            if (this.IsValidRow(row)) {
                return row[fieldname];
            }
            throw new FTSException("MSG_NO_CURRENTROW");
        }

        public bool IsValidRow(int pos) {
            return base.IsValidRowBase(this.DataTable, pos);
        }

        public void SetDefaultValue(string fieldname, object value) {
            this.mDefaultHashTable[fieldname] = value != null ? value : string.Empty;
        }

        public virtual void RemoveEmptyRows() {
            if (this.IdField != null && this.IdFieldType == DbType.String) {
                foreach (DataRow row in this.DataTable.Rows) {
                    if (row.RowState == DataRowState.Added && row[this.IdField].ToString() == string.Empty) {
                        row.RejectChanges();
                        this.RemoveEmptyRows();
                        return;
                    }
                }
            }
        }

        protected virtual string GetOrganizationFilter() {
            DataTable dmorganization = this.GetDm("DM_ORGANIZATION");
            return Dm_Organization.GetOrganizationFilter(this.FTSMain, dmorganization);
        }

        protected virtual string GetOrganizationID() {
            if (this.IsValidRow(0)) {
                if (this.DataTable.Columns.IndexOf("ORGANIZATION_ID") >= 0) {
                    return this.GetValue("ORGANIZATION_ID").ToString();
                } else {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        public virtual void SetAllRow(string fieldname, object fieldvalue) {
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState != DataRowState.Deleted) {
                    row[fieldname] = fieldvalue;
                    row.EndEdit();
                }
            }
        }

        public virtual void CopyAllRow(string fieldsource, string fielddes) {
            foreach (DataRow row in this.DataTable.Rows) {
                if (this.IsValidRow(row)) {
                    row[fielddes] = row[fieldsource];
                    row.EndEdit();
                }
            }
        }

        public void LoadConfigValue(string tran_id) {
            if (this.mConfigHashTable != null) {
                this.mConfigHashTable.Clear();
            } else {
                this.mConfigHashTable = new Hashtable();
            }
            DbCommand cmd =
                this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_config where tran_id= " +
                                                         this.mFTSMain.BuildParameterName("tran_id"));
            this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tran_id);
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                using (IDataReader rs = this.mFTSMain.DbMain.ExecuteReader(cmd)) {
                    while (rs.Read()) {
                        this.mConfigHashTable.Add(rs["config_id"].ToString().Trim(),
                                                  new object[] {
                                                                   rs["config_value"].ToString().Trim(),
                                                                   rs["config_type"].ToString().Trim()
                                                               });
                    }
                }
            } else {
                DataTable dt = this.mFTSMain.DbMain.LoadDataTable(cmd, "sys_tran_config");
                foreach (DataRow row in dt.Rows) {
                    this.mConfigHashTable.Add(row["config_id"].ToString().Trim(),
                                              new object[] {
                                                               row["config_value"].ToString().Trim(),
                                                               row["config_type"].ToString().Trim()
                                                           });
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
            throw new FTSException("MSG_INVALID_CONFIG_ID");
        }

        protected virtual void InsertDefaultConfigs() {
        }

        public void InsertConfigValue(string tran_id, string config_id, string type, object default_value) {
            object[] foundRow = (object[]) this.mConfigHashTable[config_id];
            if (foundRow == null && tran_id != string.Empty) {
                string sql =
                    "insert into sys_tran_config(pr_key,tran_id,config_id,config_name,config_type,config_value,active,user_id) " +
                    " values( " + this.mFTSMain.BuildParameterName("pr_key") + " , " +
                    this.mFTSMain.BuildParameterName("tran_id") + " , " + this.mFTSMain.BuildParameterName("config_id") +
                    " , " + this.mFTSMain.BuildParameterName("config_name") + " , " +
                    this.mFTSMain.BuildParameterName("config_type") + " , " +
                    this.mFTSMain.BuildParameterName("config_value") + " , " +
                    this.mFTSMain.BuildParameterName("active") + " , " + this.mFTSMain.BuildParameterName("user_id") +
                    ")";
                DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
                this.mFTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency,
                                                    FunctionsBase.GetPr_key("SYS_TRAN_CONFIG", this.mFTSMain));
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tran_id);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_id", DbType.String, config_id);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_name", DbType.String, config_id);
                this.mFTSMain.DbMain.AddInParameter(cmd, "config_type", DbType.String, type);
                switch (type) {
                    case "STRING":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String, default_value);
                        break;
                    case "INT":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String,
                                                            Convert.ToString(default_value));
                        break;
                    case "DECIMAL":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String,
                                                            Convert.ToString(default_value, this.mFTSMain.FTSCultureInfo));
                        break;
                    case "DATE":
                        this.mFTSMain.DbMain.AddInParameter(cmd, "config_value", DbType.String,
                                                            Convert.ToString(default_value, this.mFTSMain.FTSCultureInfo));
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

        public virtual void LoadOtherDm(string tablename) {
        }

        public virtual DataTable GetDm(string tablename) {
            DataTable dt = this.mDataSet.Tables[tablename];
            if (dt == null) {
                this.LoadOtherDm(tablename);
                dt = this.mDataSet.Tables[tablename];
            }
            return dt;
        }

        public static DataRow GetRowByID(FTSMain ftsmain, string tablename, string idfield, string idvalue) {
            DataTable dt = ftsmain.DbMain.LoadDataTable(ftsmain.DbMain.GetSqlStringCommand("SELECT * FROM " + tablename + " WHERE " + idfield + "='" + idvalue + "'"), tablename);
            if (dt.Rows.Count > 0) {
                return dt.Rows[0];
            } else {
                return null;
            }
        }

        public virtual void ImportData(DataTable excelData, DataTable dm_template_detail) {
            DataColumn[] keys = this.DataTable.PrimaryKey;
            this.DataTable.PrimaryKey = new DataColumn[] {this.DataTable.Columns[this.IdField]};
            List<DataRow> listAdded = new List<DataRow>();
            foreach (DataRow row in excelData.Rows) {
                if (this.IsValidExcelData(row, dm_template_detail)) {
                    if (excelData.Columns.IndexOf(this.IdField) >= 0) {
                        if (this.DataTable.Rows.Find(row[this.IdField]) == null) {
                            DataRow newrow = this.AddNew();
                            foreach (DataColumn c in excelData.Columns) {
                                if (this.DataTable.Columns.IndexOf(c.ColumnName) >= 0) {
                                    newrow[c.ColumnName] = row[c.ColumnName];
                                }
                            }
                            newrow.EndEdit();
                            listAdded.Add(row);
                        }
                    } else {
                        DataRow newrow = this.AddNew();
                        foreach (DataColumn c in excelData.Columns) {
                            if (this.DataTable.Columns.IndexOf(c.ColumnName) >= 0) {
                                newrow[c.ColumnName] = row[c.ColumnName];
                            }
                        }
                        newrow.EndEdit();
                        listAdded.Add(row);
                    }
                }
            }
            foreach (DataRow row in listAdded) {
                row.Delete();
            }
            excelData.AcceptChanges();
            this.DataTable.PrimaryKey = keys;
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
                                row[c.ColumnName] = this.FTSMain.DayStartOfFirstYear;
                            } else {
                                try {
                                    DateTime cellvalue = Convert.ToDateTime(row[c.ColumnName]);
                                } catch (Exception) {
                                    return false;
                                }
                            }
                            break;
                    }
                }
            }
            return true;
        }

        public virtual bool IDExists(string id) {
            object oj = this.FTSMain.DbMain.ExecuteScalar(this.FTSMain.DbMain.GetSqlStringCommand("SELECT 'TRUE' FROM " + this.TableNameOrig + " where " + this.IdField + " = '" + id + "'"));
            if (oj != null && oj != System.DBNull.Value) {
                return true;
            } else {
                return false;
            }
        }

        public virtual void MergeRecord(string oldid, string newid) {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                return;
            }
            DataTable dt =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_FIELD_RELATION WHERE TABLE_NAME='" +
                                                             this.TableNameOrig + "'"), "DM_FIELD_RELATION");
            if (dt.Rows.Count == 0) {
                return;
            }
            DbTransaction tran = null;
            try {
                using (DbConnection connection = this.mFTSMain.DbMain.CreateConnection()) {
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
                    foreach (DataRow row in dt.Rows) {
                        string sql = "UPDATE " + row["TABLE_NAME_DES"] + " SET " + row["FIELD_NAME_DES"] + "=N'" + newid +
                                     "' WHERE " + row["FIELD_NAME_DES"] + "=N'" + oldid + "'";
                        this.mFTSMain.DbMain.ExecuteNonQuery(this.mFTSMain.DbMain.GetSqlStringCommand(sql), tran);
                    }
                    this.mFTSMain.DbMain.ExecuteNonQuery(
                        this.mFTSMain.DbMain.GetSqlStringCommand("DELETE FROM " + this.TableNameOrig + " WHERE " + this.IdField +
                                                                 "=N'" + oldid + "'"), tran);
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

        public virtual void ChangeRecord(string oldid, string newid) {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                return;
            }
            DataTable dt =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_FIELD_RELATION WHERE TABLE_NAME='" +
                                                             this.TableNameOrig + "'"), "DM_FIELD_RELATION");
            if (dt.Rows.Count > 0) {
                this.CreateNewID(this.TableNameOrig, this.IdField, oldid, newid);
                this.MergeRecord(oldid, newid);
            }
        }

        private void CreateNewID(string tablename, string idfield, string oldid, string newid) {
            DataTable dt =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand("SELECT * FROM " + tablename + " WHERE " + idfield + "=N'" +
                                                             oldid + "' OR " + idfield + "=N'" + newid + "'"), tablename);
            dt.PrimaryKey = new DataColumn[] {dt.Columns[idfield]};
            DataRow foundrow = dt.Rows.Find(newid);
            if (foundrow == null) {
                DataRow oldrow = dt.Rows.Find(oldid);
                if (oldrow != null) {
                    foundrow = dt.NewRow();
                    foundrow.ItemArray = (object[]) oldrow.ItemArray.Clone();
                    foundrow[idfield] = newid;
                    dt.Rows.Add(foundrow);
                    this.mFTSMain.DbMain.UpdateTable(dt,
                                                     this.mFTSMain.DbMain.CreateInsertCommand(tablename, dt,
                                                                                              string.Empty), null, null,
                                                     UpdateBehavior.Standard);
                }
            }
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

        #region To be overwridden

        public virtual void LoadFields() {
        }

        public virtual void LoadOtherDm() {
        }

        public virtual void RefreshDm() {
        }

        public virtual void SetRole() {
        }

        #endregion

        #region DefaultValues

        public void LoadDefaultValue(string tranid) {
            if (this.mDefaultHashTable != null) {
                this.mDefaultHashTable.Clear();
            } else {
                this.mDefaultHashTable = new Hashtable();
            }
            DataTable dm_organization = this.FTSMain.TableManager.LoadTable("DM_ORGANIZATION_MAPPING");
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                DbCommand cmd =
                    this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_default where table_name=" +
                                                             this.mFTSMain.BuildParameterName("table_name") +
                                                             " and tran_id= " +
                                                             this.mFTSMain.BuildParameterName("tran_id") + " AND ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID + "'");
                this.mFTSMain.DbMain.AddInParameter(cmd, "table_name", DbType.String, this.TableName);
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tranid);
                using (IDataReader rs = this.mFTSMain.DbMain.ExecuteReader(cmd)) {
                    while (rs.Read()) {
                        if (rs["default_value"].ToString() != string.Empty) {
                            this.mDefaultHashTable.Add(rs["field_name"].ToString().Trim(), rs["default_value"]);
                        }
                    }
                }
            } else {
                DbCommand cmd =
                    this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_default where table_name=" +
                                                             this.mFTSMain.BuildParameterName("table_name") +
                                                             " and tran_id= " +
                                                             this.mFTSMain.BuildParameterName("tran_id") +
                                                             " AND ORGANIZATION_ID='" +
                                                             this.FTSMain.UserInfo.OrganizationID + "'");
                this.mFTSMain.DbMain.AddInParameter(cmd, "table_name", DbType.String, this.TableName);
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tranid);
                DataTable dt = this.mFTSMain.DbMain.LoadDataTable(cmd, "sys_tran_default");
                foreach (DataRow row in dt.Rows) {
                    if (row["default_value"].ToString() != string.Empty) {
                        this.mDefaultHashTable.Add(row["field_name"].ToString().Trim(), row["default_value"]);
                    }
                }
            }
            DataRow foundrow1 = dm_organization.Rows.Find(this.FTSMain.UserInfo.OrganizationID);
            if (foundrow1 != null) {
                if (this.mDefaultHashTable["TAX_OFFICE_ID"] == null) {
                    this.mDefaultHashTable.Add("TAX_OFFICE_ID", foundrow1["TAX_OFFICE_ID"]);
                }
                if (this.mDefaultHashTable["WAREHOUSE_ID"] == null) {
                    this.mDefaultHashTable.Add("WAREHOUSE_ID", foundrow1["WAREHOUSE_ID"]);
                }
                if (this.mDefaultHashTable["ITEM_SOURCE_ID"] == null) {
                    this.mDefaultHashTable.Add("ITEM_SOURCE_ID", foundrow1["ITEM_SOURCE_ID"]);
                }
            }
        }

        public void LoadDefaultValue(string tranid, string tablename) {
            if (this.mDefaultHashTable != null) {
                this.mDefaultHashTable.Clear();
            } else {
                this.mDefaultHashTable = new Hashtable();
            }
            DataTable dm_organization = this.FTSMain.TableManager.LoadTable("DM_ORGANIZATION_MAPPING");
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                DbCommand cmd =
                    this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_default where table_name=" +
                                                             this.mFTSMain.BuildParameterName("table_name") +
                                                             " and tran_id= " +
                                                             this.mFTSMain.BuildParameterName("tran_id") + " AND ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID + "'");
                this.mFTSMain.DbMain.AddInParameter(cmd, "table_name", DbType.String, tablename);
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tranid);
                using (IDataReader rs = this.mFTSMain.DbMain.ExecuteReader(cmd)) {
                    while (rs.Read()) {
                        if (rs["default_value"].ToString() != string.Empty) {
                            this.mDefaultHashTable.Add(rs["field_name"].ToString().Trim(), rs["default_value"]);
                        }
                    }
                }
            } else {
                DbCommand cmd =
                    this.mFTSMain.DbMain.GetSqlStringCommand("select * from sys_tran_default where table_name=" +
                                                             this.mFTSMain.BuildParameterName("table_name") +
                                                             " and tran_id= " +
                                                             this.mFTSMain.BuildParameterName("tran_id") +
                                                             " AND ORGANIZATION_ID='" +
                                                             this.FTSMain.UserInfo.OrganizationID + "'");
                this.mFTSMain.DbMain.AddInParameter(cmd, "table_name", DbType.String, tablename);
                this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, tranid);
                DataTable dt = this.mFTSMain.DbMain.LoadDataTable(cmd, "sys_tran_default");
                foreach (DataRow row in dt.Rows) {
                    if (row["default_value"].ToString() != string.Empty) {
                        this.mDefaultHashTable.Add(row["field_name"].ToString().Trim(), row["default_value"]);
                    }
                }
            }
            DataRow foundrow1 = dm_organization.Rows.Find(this.FTSMain.UserInfo.OrganizationID);
            if (foundrow1 != null) {
                if (this.mDefaultHashTable["TAX_OFFICE_ID"] == null) {
                    this.mDefaultHashTable.Add("TAX_OFFICE_ID", foundrow1["TAX_OFFICE_ID"]);
                }
                if (this.mDefaultHashTable["WAREHOUSE_ID"] == null) {
                    this.mDefaultHashTable.Add("WAREHOUSE_ID", foundrow1["WAREHOUSE_ID"]);
                }
                if (this.mDefaultHashTable["ITEM_SOURCE_ID"] == null) {
                    this.mDefaultHashTable.Add("ITEM_SOURCE_ID", foundrow1["ITEM_SOURCE_ID"]);
                }
            }
        }

        #endregion
    }
}