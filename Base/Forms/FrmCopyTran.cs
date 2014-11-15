#region

using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmCopyTran : FrmBaseForm {
        private ItemTranId mTranId;
        private ItemTranId mNewTranId;

        public FrmCopyTran() {
            this.InitializeComponent();
        }

        public FrmCopyTran(FTSMain ftsMain, ItemTranId tranId) : base(ftsMain, true) {
            this.mTranId = tranId;
            this.InitializeComponent();
            this.txtOrgTranId.Textbox.Text = this.mTranId.TranId;
            this.txtOrgTranName.Textbox.Text = this.mTranId.TranName;
            this.txtOrgTranId.Textbox.Enabled = false;
            this.txtOrgTranName.Textbox.Enabled = false;
            this.txtNewTranId.Textbox.EditValue = string.Empty;
            this.txtNewTranName.Textbox.EditValue = string.Empty;
            this.txtNewTranId.SetCase(true);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            DbTransaction tran = null;
            try {
                if ((this.txtNewTranId.Textbox.EditValue.ToString().Trim() == string.Empty) ||
                    (this.txtNewTranName.Textbox.EditValue.ToString().Trim() == string.Empty)) {
                    throw (new FTSException("INFOMATION_NOT_ENOUGH"));
                }
                string sql = "select count(*) from sys_tran where tran_id ='" +
                             this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper() + "'";
                object exits = this.FTSMain.DbMain.ExecuteScalar(this.FTSMain.DbMain.GetSqlStringCommand(sql));
                if (Convert.ToInt32(exits) > 0) {
                    throw (new FTSException("DUPLICATE_PRIMARY_KEY"));
                }
                DataTable tblTemp;
                DataTable tblForm = this.FTSMain.TableManager.LoadTable("sys_form", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_form",
                                                              "form_name ='" + this.mTranId.OutputForm.Trim().ToUpper() +
                                                              "_" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblForm.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["form_name"] = this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                          this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow.EndEdit();
                    tblForm.Rows.Add(newRow);
                }
                DataTable tblFormInfo = this.FTSMain.TableManager.LoadTable("sys_forminfo", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_forminfo",
                                                              "form_name ='" + this.mTranId.OutputForm.Trim().ToUpper() +
                                                              "_" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblFormInfo.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_FORMINFO", this.FTSMain);
                    newRow["form_name"] = this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                          this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow.EndEdit();
                    tblFormInfo.Rows.Add(newRow);
                }
                DataTable tblGridInfo = this.FTSMain.TableManager.LoadTable("sys_gridinfo", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_gridinfo",
                                                              "form_name ='" + this.mTranId.OutputForm.Trim().ToUpper() +
                                                              "_" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblGridInfo.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_GRIDINFO", this.FTSMain);
                    newRow["form_name"] = this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                          this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow.EndEdit();
                    tblGridInfo.Rows.Add(newRow);
                }
                DataTable tblTran = this.FTSMain.TableManager.LoadTable("sys_tran", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_tran",
                                                              "tran_id='" + this.mTranId.TranId.Trim().ToUpper() + "'");
                string tranclass = string.Empty;
                if (tblTemp.Rows.Count > 0) {
                    tranclass = tblTemp.Rows[0]["TRAN_CLASS"].ToString();
                }
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblTran.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["tran_id"] = this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow["tran_name"] = this.txtNewTranName.Textbox.EditValue.ToString().Trim();
                    newRow.EndEdit();
                    tblTran.Rows.Add(newRow);
                    this.FTSMain.ResourceManager.SetValue(
                        "TRANNAME_" + this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper(),
                        this.txtNewTranName.Textbox.EditValue.ToString().Trim());
                }
                if (tblTran.Rows.Count > 0) {
                    this.mNewTranId = new ItemTranId(tblTran.Rows[0]["tran_id"].ToString(),
                                                     tblTran.Rows[0]["tran_name"].ToString(),
                                                     tblTran.Rows[0]["tran_class"].ToString(),
                                                     tblTran.Rows[0]["output_form"].ToString(),
                                                     tblTran.Rows[0]["tran_sub_class"].ToString(),
                                                     tblTran.Rows[0]["module_id"].ToString(),
                                                     (int) tblTran.Rows[0]["list_order"]);
                }
                DataTable tblTranCal = this.FTSMain.TableManager.LoadTable("sys_tran_calculation", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_tran_calculation",
                                                              "tran_id='" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblTranCal.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["tran_id"] = this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_TRAN_CALCULATION", this.FTSMain);
                    newRow.EndEdit();
                    tblTranCal.Rows.Add(newRow);
                }
                DataTable tblTranCon = this.FTSMain.TableManager.LoadTable("sys_tran_config", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_tran_config",
                                                              "tran_id='" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblTranCon.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["tran_id"] = this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_TRAN_CONFIG", this.FTSMain);
                    newRow.EndEdit();
                    tblTranCon.Rows.Add(newRow);
                }
                DataTable tblTranDefault = this.FTSMain.TableManager.LoadTable("sys_tran_default", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_tran_default",
                                                              "tran_id='" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblTranDefault.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["tran_id"] = this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_TRAN_DEFAULT", this.FTSMain);
                    newRow.EndEdit();
                    tblTranDefault.Rows.Add(newRow);
                }
                DataTable tblTranOutput = this.FTSMain.TableManager.LoadTable("sys_tran_output", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_tran_output",
                                                              "tran_id='" + this.mTranId.TranId.Trim().ToUpper() + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblTranOutput.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["tran_id"] = this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_TRAN_OUTPUT", this.FTSMain);
                    newRow.EndEdit();
                    tblTranOutput.Rows.Add(newRow);
                }
                DataTable tblResource = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE",
                                                              "(RES_ID LIKE 'FRM_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() +
                                                              "%' OR RES_ID LIKE 'GRID_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() + "%')");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblResource.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_RESOURCE", this.FTSMain);
                    newRow.EndEdit();
                    tblResource.Rows.Add(newRow);
                }
                DataTable tblResourceEN = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_EN", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_EN",
                                                              "(RES_ID LIKE 'FRM_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() +
                                                              "%' OR RES_ID LIKE 'GRID_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() + "%')");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblResourceEN.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_RESOURCE_EN", this.FTSMain);
                    newRow.EndEdit();
                    tblResourceEN.Rows.Add(newRow);
                }
                DataTable tblResourceJP = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_JP", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_JP",
                                                              "(RES_ID LIKE 'FRM_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() +
                                                              "%' OR RES_ID LIKE 'GRID_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() + "%')");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblResourceJP.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_RESOURCE_JP", this.FTSMain);
                    newRow.EndEdit();
                    tblResourceJP.Rows.Add(newRow);
                }
                DataTable tblResourceKR = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_KR", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("SYS_RESOURCE_KR",
                                                              "(RES_ID LIKE 'FRM_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() +
                                                              "%' OR RES_ID LIKE 'GRID_" +
                                                              this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                                              this.mTranId.TranId.Trim().ToUpper() + "%')");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblResourceKR.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "FRM_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["RES_ID"] =
                        newRow["RES_ID"].ToString().Replace(
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.mTranId.TranId.Trim().ToUpper(),
                            "GRID_" + this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                            this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper());
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_RESOURCE_KR", this.FTSMain);
                    newRow.EndEdit();
                    tblResourceKR.Rows.Add(newRow);
                }
                using (DbConnection connection = this.FTSMain.DbMain.CreateConnection()) {
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        connection.Open();
                        tran = connection.BeginTransaction();
                    } else {
                        this.FTSMain.DbMain.BeginTransactionOnline();
                    }
                    this.FTSMain.DbMain.UpdateTable(tblForm, this.FTSMain.DbMain.CreateInsertCommand("sys_form", tblForm),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblFormInfo,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_forminfo", tblFormInfo),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblGridInfo,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_gridinfo", tblGridInfo),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblTran, this.FTSMain.DbMain.CreateInsertCommand("sys_tran", tblTran),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblTranCal,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_tran_calculation",
                                                                                            tblTranCal), null, null,
                                                    tran);
                    this.FTSMain.DbMain.UpdateTable(tblTranCon,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_tran_config", tblTranCon),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblTranDefault,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_tran_default",
                                                                                            tblTranDefault), null, null,
                                                    tran);
                    this.FTSMain.DbMain.UpdateTable(tblTranOutput,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_tran_output",
                                                                                            tblTranOutput), null, null,
                                                    tran);
                    this.FTSMain.DbMain.UpdateTable(tblResource,
                                                    this.FTSMain.DbMain.CreateInsertCommand("SYS_RESOURCE", tblResource),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblResourceEN,
                                                    this.FTSMain.DbMain.CreateInsertCommand("SYS_RESOURCE_EN",
                                                                                            tblResourceEN), null, null,
                                                    tran);
                    this.FTSMain.DbMain.UpdateTable(tblResourceJP,
                                                    this.FTSMain.DbMain.CreateInsertCommand("SYS_RESOURCE_JP",
                                                                                            tblResourceJP), null, null,
                                                    tran);
                    this.FTSMain.DbMain.UpdateTable(tblResourceKR,
                                                    this.FTSMain.DbMain.CreateInsertCommand("SYS_RESOURCE_KR",
                                                                                            tblResourceKR), null, null,
                                                    tran);
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        tran.Commit();
                    } else {
                        this.FTSMain.DbMain.CommitTransactionOnline();
                    }
                }
                string oldformname = this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                     this.mTranId.TranId.Trim().ToUpper();
                string newformname = this.mTranId.OutputForm.Trim().ToUpper() + "_" +
                                     this.txtNewTranId.Textbox.EditValue.ToString().Trim().ToUpper();
                //foreach (DataRow row in tblFormInfo.Rows) {
                //    string ctrlname = row["OBJECT_NAME"].ToString().Trim();
                //    this.FTSMain.ResourceManager.DuplicateRow(oldformname, newformname, ctrlname);
                //}
                this.FTSMain.ResourceManager.SetValue("FRM_" + newformname + "_" + newformname + "_TEXT",
                                                      this.txtNewTranName.Textbox.EditValue.ToString());
                //foreach (DataRow row in tblGridInfo.Rows) {
                //    this.FTSMain.ResourceManager.DuplicateRow(oldformname, newformname, row["GRID_NAME"].ToString().Trim(), row["COLUMN_NAME"].ToString().Trim());
                //}
                switch (tranclass) {
                    case "TP_ORDER":
                        this.CopyListing("FRMTP_ORDER_LISTING", this.mTranId.TranId,
                                         this.txtNewTranId.Textbox.EditValue.ToString());
                        break;
                    case "SALE":
                        this.CopyListing("FRMSALE_LISTING", this.mTranId.TranId,
                                         this.txtNewTranId.Textbox.EditValue.ToString());
                        break;
                    case "PURCHASE":
                        this.CopyListing("FRMPURCHASE_LISTING", this.mTranId.TranId,
                                         this.txtNewTranId.Textbox.EditValue.ToString());
                        break;
                    case "KT":
                        this.CopyListing("FRMVOUCHER_LISTING", this.mTranId.TranId,
                                         this.txtNewTranId.Textbox.EditValue.ToString());
                        break;
                    default:
                        break;
                }
                this.DialogResult = DialogResult.OK;
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
            }
        }

        private void CopyListing(string formname, string oldtranid, string newtranid) {
            DbTransaction tran = null;
            try {
                string oldformname = formname + "_" + oldtranid;
                string newformname = formname + "_" + newtranid;
                DataTable tblForm = this.FTSMain.TableManager.LoadTable("sys_form", "1=0");
                DataTable tblTemp = this.FTSMain.TableManager.LoadTable("sys_form", "form_name ='" + oldformname + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblForm.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["form_name"] = newformname;
                    newRow.EndEdit();
                    tblForm.Rows.Add(newRow);
                }
                DataTable tblFormInfo = this.FTSMain.TableManager.LoadTable("sys_forminfo", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_forminfo", "form_name ='" + oldformname + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblFormInfo.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_FORMINFO", this.FTSMain);
                    newRow["form_name"] = newformname;
                    newRow.EndEdit();
                    tblFormInfo.Rows.Add(newRow);
                }
                DataTable tblGridInfo = this.FTSMain.TableManager.LoadTable("sys_gridinfo", "1=0");
                tblTemp = this.FTSMain.TableManager.LoadTable("sys_gridinfo", "form_name ='" + oldformname + "'");
                foreach (DataRow row in tblTemp.Rows) {
                    DataRow newRow = tblGridInfo.NewRow();
                    newRow.ItemArray = (object[]) row.ItemArray.Clone();
                    newRow["pr_key"] = FunctionsBase.GetPr_key("SYS_GRIDINFO", this.FTSMain);
                    newRow["form_name"] = newformname;
                    newRow.EndEdit();
                    tblGridInfo.Rows.Add(newRow);
                }
                using (DbConnection connection = this.FTSMain.DbMain.CreateConnection()) {
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        connection.Open();
                        tran = connection.BeginTransaction();
                    } else {
                        this.FTSMain.DbMain.BeginTransactionOnline();
                    }
                    this.FTSMain.DbMain.UpdateTable(tblForm, this.FTSMain.DbMain.CreateInsertCommand("sys_form", tblForm),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblFormInfo,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_forminfo", tblFormInfo),
                                                    null, null, tran);
                    this.FTSMain.DbMain.UpdateTable(tblGridInfo,
                                                    this.FTSMain.DbMain.CreateInsertCommand("sys_gridinfo", tblGridInfo),
                                                    null, null, tran);
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        tran.Commit();
                    } else {
                        this.FTSMain.DbMain.CommitTransactionOnline();
                    }
                }
                foreach (DataRow row in tblFormInfo.Rows) {
                    string ctrlname = row["OBJECT_NAME"].ToString().Trim();
                    this.FTSMain.ResourceManager.DuplicateRow(oldformname, newformname, ctrlname);
                }
                this.FTSMain.ResourceManager.SetValue("FRM_" + newformname + "_" + newformname + "_TEXT",
                                                      this.txtNewTranName.Textbox.EditValue.ToString());
                foreach (DataRow row in tblGridInfo.Rows) {
                    this.FTSMain.ResourceManager.DuplicateRow(oldformname, newformname,
                                                              row["GRID_NAME"].ToString().Trim(),
                                                              row["COLUMN_NAME"].ToString().Trim());
                }
            } catch (FTSException ex) {
                try {
                    tran.Rollback();
                } catch (Exception) {
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                if (tran != null) {
                    tran.Rollback();
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        public ItemTranId NewTranId {
            get { return this.mNewTranId; }
        }
    }
}