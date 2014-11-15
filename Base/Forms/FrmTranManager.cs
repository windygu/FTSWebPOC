#region

using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Security;
using FTS.BaseBusiness.Systems;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmTranManager : FrmBaseForm {
        private DataTable tblClass;
        private DataTable tblId;
        private string mTranClass = string.Empty;
        private string mTranId = string.Empty;

        public FrmTranManager() {
            this.InitializeComponent();
        }

        public FrmTranManager(FTSMain ftsMain) : this(ftsMain, string.Empty, string.Empty, false) {
        }

        public FrmTranManager(FTSMain ftsMain, string tranclass, string tranid, bool showdialog)
            : base(ftsMain, showdialog) {
            this.InitializeComponent();
            this.mTranClass = tranclass;
            this.mTranId = tranid;
            this.LoadData();
            this.SetControl();
        }

        private void LoadData() {
            this.tblClass = this.FTSMain.TableManager.LoadTable("sys_tran_class", "tran_class,tran_class_name",
                                                                (this.mTranClass == string.Empty)
                                                                    ? "active=1"
                                                                    : "active =1 and tran_class = '" +
                                                                      this.mTranClass.Trim().ToUpper() + "'");
            this.tblId = this.FTSMain.TableManager.LoadTable("sys_tran",
                                                             "tran_id,tran_class,output_form,POSTED,USER_ID,ACTIVE,TRAN_SUB_CLASS,MODULE_ID,LIST_ORDER",
                                                             (this.mTranId == string.Empty)
                                                                 ? "active=1"
                                                                 : "active =1 and tran_id = '" +
                                                                   this.mTranId.Trim().ToUpper() + "'");
        }

        private void SetControl() {
            this.lstTranClass.Items.Clear();
            foreach (DataRow row in this.tblClass.Rows) {
                this.lstTranClass.Items.Add(new ItemTranClass(row["tran_class"].ToString(),
                                                              row["tran_class_name"].ToString()));
            }
            if (this.lstTranClass.Items.Count > 0) {
                this.lstTranClass.SelectedIndex = 0;
            }
        }

        private void lstTranClass_SelectedIndexChanged(object sender, EventArgs e) {
            this.lstTranId.Items.Clear();
            ItemTranClass itemclass = (ItemTranClass) this.lstTranClass.SelectedItem;
            foreach (DataRow row in this.tblId.Rows) {
                if ((row.RowState != DataRowState.Deleted) &&
                    (row["tran_class"].ToString().Trim().ToUpper() == itemclass.TranClass.Trim().ToUpper())) {
                    this.lstTranId.Items.Add(new ItemTranId(row["tran_id"].ToString(),
                                                            this.FTSMain.ResourceManager.GetValue(
                                                                "TRANNAME_" + row["tran_id"].ToString(),
                                                                row["tran_id"].ToString()), row["tran_class"].ToString(),
                                                            row["output_form"].ToString(),
                                                            row["TRAN_SUB_CLASS"].ToString(),
                                                            row["MODULE_ID"].ToString(), (int) row["LIST_ORDER"]));
                }
            }
            if (this.lstTranId.Items.Count > 0) {
                this.lstTranId.SelectedIndex = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            try {
                this.FTSMain.SecurityManager.CheckSecurity(FTSFunctionCollection.SYS_TRAN, DataAction.ExecuteAction, string.Empty);
                ItemTranId item = (ItemTranId) this.lstTranId.SelectedItem;
                if (item != null) {
                    FrmCopyTran frm = new FrmCopyTran(this.FTSMain, item);
                    if (frm.ShowDialog() == DialogResult.OK) {
                        item = frm.NewTranId;
                        this.lstTranId.Items.Add(item);
                        this.tblId.Rows.Add(new object[] {
                                                             item.TranId, item.TranClass, item.OutputForm, 1,
                                                             this.FTSMain.UserInfo.UserID, 1, item.TranSubClass, item.ModuleID,
                                                             item.ListOrder
                                                         });
                        this.tblId.AcceptChanges();
                    }
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DbTransaction tran = null;
            ItemTranId item = (ItemTranId) this.lstTranId.SelectedItem;
            try {
                if (item != null) {
                    if ((bool) this.FTSMain.SystemVars.GetSystemVars("DETAILED_PERMISSION")) {
                        this.FTSMain.SecurityManager.CheckSecurity(FTSFunctionCollection.SYS_TRAN, DataAction.EditAction, string.Empty);
                    } else {
                        this.FTSMain.SecurityManager.CheckSecurity(FTSFunctionCollection.SYS_TRAN, DataAction.UpdateAction, string.Empty);
                    }
                    DbCommand cmdForm =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_form where form_name = '" +
                                                                item.OutputForm.Trim().ToUpper() + "_" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdFormInfo =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_forminfo where form_name = '" +
                                                                item.OutputForm.Trim().ToUpper() + "_" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdGridInfo =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_gridinfo where form_name = '" +
                                                                item.OutputForm.Trim().ToUpper() + "_" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdTran =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_tran where tran_id = '" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdTranCal =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_tran_calculation where tran_id = '" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdTranCon =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_tran_config where tran_id = '" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdTranDefault =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_tran_default where tran_id = '" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    DbCommand cmdTranOutput =
                        this.FTSMain.DbMain.GetSqlStringCommand("delete from sys_tran_output where tran_id = '" +
                                                                item.TranId.Trim().ToUpper() + "'");
                    using (DbConnection connection = this.FTSMain.DbMain.CreateConnection()) {
                        if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                            connection.Open();
                            tran = connection.BeginTransaction();
                        } else {
                            this.FTSMain.DbMain.BeginTransactionOnline();
                        }
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdForm, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdFormInfo, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdGridInfo, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdTran, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdTranCal, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdTranCon, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdTranDefault, tran);
                        this.FTSMain.DbMain.ExecuteNonQuery(cmdTranOutput, tran);
                        if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                            tran.Commit();
                        } else {
                            this.FTSMain.DbMain.CommitTransactionOnline();
                        }
                    }
                }
            } catch (FTSException ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1) {
                if (tran != null) {
                    tran.Rollback();
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
            DataRow row = this.tblId.Rows.Find(item.TranId);
            if (row != null) {
                row.Delete();
            }
            this.tblId.AcceptChanges();
            this.lstTranId.Items.Remove(item);
        }
    }

    public class ItemTranClass : Object {
        private string mTran_Class = string.Empty;
        private string mTran_Class_Name = string.Empty;

        public ItemTranClass(string tranclass, string tranclassname) {
            this.mTran_Class = tranclass;
            this.mTran_Class_Name = tranclassname;
        }

        public string TranClass {
            get { return this.mTran_Class; }
        }

        public string TranClassName {
            get { return this.mTran_Class_Name; }
        }

        public override string ToString() {
            return this.mTran_Class_Name;
        }
    }

    public class ItemTranId : Object {
        private string mTran_Id = string.Empty;
        private string mTran_Name = string.Empty;
        private string mTran_Class = string.Empty;
        private string mOutput_Form = string.Empty;
        private string mTran_Sub_Class = string.Empty;
        private string mModule_ID = string.Empty;
        private int mList_Order = 1;

        public ItemTranId(string tranid, string tranname, string tranclass, string outputform, string transubclass,
                          string moduleid, int listorder) {
            this.mTran_Id = tranid;
            this.mTran_Name = tranname;
            this.mTran_Class = tranclass;
            this.mOutput_Form = outputform;
            this.mTran_Sub_Class = transubclass;
            this.mModule_ID = moduleid;
            this.mList_Order = listorder;
        }

        public string TranId {
            get { return this.mTran_Id; }
        }

        public string TranName {
            get { return this.mTran_Name; }
        }

        public string TranClass {
            get { return this.mTran_Class; }
        }

        public string OutputForm {
            get { return this.mOutput_Form; }
        }

        public string TranSubClass {
            get { return this.mTran_Sub_Class; }
        }

        public string ModuleID {
            get { return this.mModule_ID; }
        }

        public int ListOrder {
            get { return this.mList_Order; }
        }

        public override string ToString() {
            return this.mTran_Name;
        }
    }
}