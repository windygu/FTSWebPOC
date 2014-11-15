using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.BaseUI.ImportData {
    public partial class FrmImportExcel : FrmBaseFormGrid {
        private OpenFileDialog openFile;
        private ObjectBase mObjectBase = null;
        private ManagerBase mManagerBase = null;
        private DataSet mDataSet = new DataSet();
        private DataTable mDm_template_detail;

        public FrmImportExcel() {
            InitializeComponent();
        }

        public FrmImportExcel(FTSMain ftsmain, ObjectBase objectBase,ManagerBase managerBase) : base(ftsmain, true) {
            this.mObjectBase = objectBase;
            this.mManagerBase = managerBase;
            InitializeComponent();
            this.LoadTemplate();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.openFile.FileName = "Xls";
            this.openFile.Filter = "Tệp dữ liệu (*.xls)|*.xls";
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
        }

        private void LoadTemplate() {
            if (this.mObjectBase != null) {
                this.listTemplate.Items.Clear();
                DataTable dt =
                    this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_TEMPLATE WHERE TABLE_NAME='" + this.mObjectBase.TableNameOrig + "' AND ACTIVE=1"), "DT");
                foreach (DataRow row in dt.Rows) {
                    ObjectInfo oo =
                        new ObjectInfo(Convert.ToInt64(row["PR_KEY"]).ToString(),row["TEMPLATE_NAME"].ToString());
                    this.listTemplate.Items.Add(oo);
                }
                if (this.listTemplate.Items.Count > 0) {
                    this.listTemplate.SelectedIndex = 0;
                }
            }
            if (this.mManagerBase != null) {
                this.listTemplate.Items.Clear();
                DataTable dt =
                    this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_TEMPLATE WHERE TRAN_ID_NAME='" + this.mManagerBase.TranId + "' AND ACTIVE=1"), "DT");
                foreach (DataRow row in dt.Rows) {
                    ObjectInfo oo =
                        new ObjectInfo(Convert.ToInt64(row["PR_KEY"]).ToString(), row["TEMPLATE_NAME"].ToString());
                    this.listTemplate.Items.Add(oo);
                }
                if (this.listTemplate.Items.Count > 0) {
                    this.listTemplate.SelectedIndex = 0;
                }
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo != null) {
                    FrmGetString frmgetstring =
                        new FrmGetString(this.FTSMain.MsgManager.GetMessage("MSG_NEW_TEMPLATE_TITLE"),
                                         this.FTSMain.MsgManager.GetMessage("MSG_NEW_TEMPLATE"));
                    if (frmgetstring.ShowDialog() == DialogResult.Yes) {
                        decimal pr_key = FunctionsBase.GetPr_key("DM_TEMPLATE", this.FTSMain);
                        this.FTSMain.DbMain.ExecuteNonQuery(this.FTSMain.DbMain.GetSqlStringCommand("INSERT INTO DM_TEMPLATE SELECT " + Convert.ToInt64(pr_key) + ",TRAN_ID,N'" + frmgetstring.RetVal + "',TABLE_NAME,TRAN_ID_NAME,IS_FIRST_ROW_DATA,ACTIVE,'" +
                                     this.FTSMain.UserInfo.UserID + "' from DM_TEMPLATE WHERE PR_KEY=" + oo.ID));
                        DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_TEMPLATE_DETAIL WHERE FR_KEY=" + oo.ID), "dt");
                        foreach (DataRow row in dt.Rows) {
                            decimal pr_keymoi = FunctionsBase.GetPr_key("DM_TEMPLATE_DETAIL", this.FTSMain);
                            this.FTSMain.DbMain.ExecuteNonQuery(
                                this.FTSMain.DbMain.GetSqlStringCommand("INSERT INTO DM_TEMPLATE_DETAIL SELECT " + Convert.ToInt64(pr_keymoi) + "," + Convert.ToInt64(pr_key) +
                                                                        ",LIST_ORDER,EXCEL_COLUMN_NO,DATA_COLUMN_NAME,DATA_TYPE,IS_PR_KEY  from DM_TEMPLATE_DETAIL WHERE PR_KEY=" + Convert.ToInt64(row["PR_KEY"])));
                        }
                        this.LoadTemplate();
                    }
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo != null) {
                    FrmDm_Template f = new FrmDm_Template(FTSMain, "TEMPLATE", this.mManagerBase, this.mObjectBase, Convert.ToDecimal(oo.ID));
                    f.ShowDialog();
                }
                this.LoadTemplate();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo != null) {
                    this.FTSMain.DbMain.ExecuteNonQuery(
                        this.FTSMain.DbMain.GetSqlStringCommand("DELETE FROM DM_TEMPLATE WHERE PR_KEY=" +
                                                                oo.ID));
                    this.FTSMain.DbMain.ExecuteNonQuery(
                        this.FTSMain.DbMain.GetSqlStringCommand("DELETE FROM DM_TEMPLATE_DETAIL WHERE FR_KEY=" +
                                                                oo.ID));
                    this.LoadTemplate();
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void cmdImport_Click(object sender, EventArgs e) {
            try {

                DataSet ds = new DataSet();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = " zip file (*.zip)|*.zip";
                ofd.ShowDialog();
                Application.DoEvents();
                if (ofd.FileName != string.Empty) {
                    FTSZip.ExtractZip(ofd.FileName, Application.StartupPath + "\\TemplateExRate.xml");
                    ds.ReadXml(Application.StartupPath + "\\TemplateExRate.xml");
                    decimal prkey = 0;
                    foreach (DataRow item in ds.Tables["DM_TEMPLATE"].Rows) {
                        prkey = FunctionsBase.GetPr_key("DM_TEMPLATE", this.FTSMain);
                        item["PR_KEY"] = prkey;
                    }
                    foreach (DataRow item in ds.Tables["DM_TEMPLATE_DETAIL"].Rows) {
                        item["PR_KEY"] = FunctionsBase.GetPr_key("DM_TEMPLATE_DETAIL", this.FTSMain);
                        item["FR_KEY"] = prkey;
                    }
                    this.FTSMain.DbMain.UpdateTable(ds.Tables["DM_TEMPLATE"], this.FTSMain.DbMain.CreateInsertCommand("DM_TEMPLATE", ds.Tables["DM_TEMPLATE"], ""),
                                                    this.FTSMain.DbMain.CreateUpdateCommand("DM_TEMPLATE", ds.Tables["DM_TEMPLATE"], "PR_KEY", ""),
                                                    this.FTSMain.DbMain.CreateDeleteCommand("DM_TEMPLATE", ds.Tables["DM_TEMPLATE"], "PR_KEY"), UpdateBehavior.Standard);
                    this.FTSMain.DbMain.UpdateTable(ds.Tables["DM_TEMPLATE_DETAIL"], this.FTSMain.DbMain.CreateInsertCommand("DM_TEMPLATE_DETAIL", ds.Tables["DM_TEMPLATE_DETAIL"], ""),
                                                    this.FTSMain.DbMain.CreateUpdateCommand("DM_TEMPLATE_DETAIL", ds.Tables["DM_TEMPLATE_DETAIL"], "PR_KEY", ""),
                                                    this.FTSMain.DbMain.CreateDeleteCommand("DM_TEMPLATE_DETAIL", ds.Tables["DM_TEMPLATE_DETAIL"], "PR_KEY"), UpdateBehavior.Standard);
                    Functions.ClearDataSet(ds);
                    this.LoadTemplate();
                }

            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        

        private void cmdSaleFile_Click(object sender, EventArgs e) {
            try {
                DataSet ds = new DataSet("TEMPLATE");
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo == null) {
                    throw new FTSException("MSG_NO_TEMPLATE_SELECTED");
                }
                this.FTSMain.TableManager.LoadTable(ds, "DM_TEMPLATE", "PR_KEY = " + oo.ID + "");
                this.FTSMain.TableManager.LoadTable(ds, "DM_TEMPLATE_DETAIL", "FR_KEY = " + oo.ID + "");
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = " zip file (*.zip)|*.zip";
                sfd.ShowDialog();
                if (sfd.FileName != "") {
                    string[] split = sfd.FileName.Split('\\');
                    ds.WriteXml(Application.StartupPath + "\\TemplateExRate.xml");
                    int lenght = sfd.FileName.Length;
                    FTSZip.AddFilesToZip(sfd.FileName, Application.StartupPath + "\\TemplateExRate.xml", "TemplateExRate.xml");
                    if (File.Exists(Application.StartupPath + "\\TemplateExRate.xml")) {
                        File.Delete(Application.StartupPath + "\\TemplateExRate.xml");
                        FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_MOVE_FINISH"));
                    }
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        

        private void btnExcelFile_Click(object sender, EventArgs e) {
            openFile.Title = this.FTSMain.MsgManager.GetMessage("MSG_LUUBCAO_FILE");
            openFile.ShowDialog();
        }

        private void openFile_FileOk(object sender, CancelEventArgs e) {
            try {
                if (!File.Exists(openFile.FileName)) {
                    FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_FILE_NOTFOUND"));
                } else {
                    this.txtExcelFile.Textbox.Text = openFile.FileName;
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo == null) {
                    throw new FTSException("MSG_NO_TEMPLATE_SELECTED");
                }
                if (!Functions.FileExists(this.txtExcelFile.Textbox.EditValue.ToString())) {
                    throw new FTSException("MSG_INVALID_DATA_FILE");
                }
                if (this.mDm_template_detail != null) {
                    if (this.mObjectBase != null) {
                        if (this.mDataSet.Tables.IndexOf("DataExcel") >= 0) {
                            this.mObjectBase.ImportData(this.mDataSet.Tables["DataExcel"], this.mDm_template_detail);
                        }
                    }
                    if (this.mManagerBase != null) {
                        if (this.mDataSet.Tables.IndexOf("DataExcel") >= 0) {
                            this.mManagerBase.ImportData(this.mDataSet.Tables["DataExcel"], this.mDm_template_detail);
                        }
                    }
                }else {
                    throw new FTSException("MSG_DATA_NOT_LOADED");
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
        private void LoadExcelData() {
            //Lấy thông tin template cho bảng
            ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
            if (oo == null) {
                throw new FTSException("MSG_NO_TEMPLATE_SELECTED");
            }
            mDm_template_detail = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_TEMPLATE_DETAIL WHERE FR_KEY = " + oo.ID + ""),"DM_TEMPLATE_DETAIL");
            mDm_template_detail.PrimaryKey = new DataColumn[] { mDm_template_detail.Columns["DATA_COLUMN_NAME"] };
            //Lấy thông tin khóa chính của bảng
            List<string> keycolumnlist = new List<string>();
            foreach (DataRow item in this.mDm_template_detail.Rows) {
                if (item["IS_PR_KEY"].ToString() == "1") {
                    keycolumnlist.Add(item["DATA_COLUMN_NAME"].ToString());
                }
            }
            string columnlist = string.Empty;
            foreach (DataRow item in mDm_template_detail.Rows) {
                columnlist += ",[" + item["EXCEL_COLUMN_NO"].ToString().Trim() + "] as " + item["DATA_COLUMN_NAME"].ToString().Trim();
            }
            if (columnlist != string.Empty) {
                columnlist = columnlist.Remove(0, 1);
            }
            //Đổ dữ liệu import vào DataSet
            if (this.mDataSet.Tables.IndexOf("DataExcel") >= 0) this.mDataSet.Tables.Remove("DataExcel");
            DataTable dt = this.GetSheetData(this.openFile.FileName, columnlist, keycolumnlist);
            
            dt.TableName = "DataExcel";
            this.mDataSet.Tables.Add(dt);
            //Tải dữ liệu lên Grid
            Application.DoEvents();
            this.grid.DataSource = this.mDataSet;
            this.grid.DataMember = "DataExcel";
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                DataRow templaterow = this.mDm_template_detail.Rows.Find(c.FieldName);
                if (templaterow != null) {
                    c.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                }
            }
            //Validate data
           
            
        }

        private void cmdLoadData_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo == null) {
                    throw new FTSException("MSG_NO_TEMPLATE_SELECTED");
                }
                if (!Functions.FileExists(this.txtExcelFile.Textbox.EditValue.ToString())) {
                    throw new FTSException("MSG_INVALID_DATA_FILE");
                }
                this.LoadExcelData();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private string GetFirstSheetName(string excelFile) {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection objConn = new OleDbConnection(connString)) {
                objConn.Open();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null) {
                    return string.Empty;
                }
                if (dt.Rows.Count > 0) {
                    return dt.Rows[0]["TABLE_NAME"].ToString();
                }
            }
            return string.Empty;
        }

        private DataTable GetSheetData(string excelFile, string columnlist, List<string> keycolumnlist) {
            string sheetname = this.GetFirstSheetName(excelFile);
            string srcConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""";
            string srcQuery = "Select " + columnlist + " from [" + sheetname + "]";

            using (OleDbConnection srcConn = new OleDbConnection(srcConnString)) {
                srcConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(srcQuery, srcConn);
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                srcConn.Close();

                List<DataRow> invalidrowlist = new List<DataRow>();
                foreach (DataRow row in dt.Rows) {
                    bool isvalid = false;
                    foreach (string keyfield in keycolumnlist) {
                        if (row[keyfield].ToString().Trim() != string.Empty) {
                            isvalid = true;
                        }
                    }
                    if (keycolumnlist.Count == 0) {
                        isvalid = true;
                    }
                    if (!isvalid) {
                        invalidrowlist.Add(row);
                    }
                }
                foreach (DataRow row in invalidrowlist) {
                    row.Delete();
                }
                dt.AcceptChanges();
                return dt;
            }
        }
        public override bool CellWarning(CurrentCellInfo cellinfo) {
            string columnname = cellinfo.Column.FieldName;
            DataRow templaterow = mDm_template_detail.Rows.Find(columnname);
            if (templaterow != null) {
                switch (templaterow["DATA_TYPE"].ToString().ToUpper()) {
                    case "DECIMAL":
                        if (cellinfo.Value == null || cellinfo.Value.ToString().Trim() == string.Empty) {
                            cellinfo.Value = 0;
                        } else {
                            try {
                                decimal cellvalue = Convert.ToDecimal(cellinfo.Value);
                            } catch (Exception) {
                                return false;
                            }
                        }
                        break;
                    case "INT":
                        if (cellinfo.Value == null || cellinfo.Value.ToString().Trim() == string.Empty) {
                            cellinfo.Value = 0;
                        } else {
                            try {
                                Int32 cellvalue = Convert.ToInt32(cellinfo.Value);
                            } catch (Exception) {
                                return false;
                            }
                        }
                        break;
                    case "BOOLEAN":
                        if (cellinfo.Value == null || cellinfo.Value.ToString().Trim() == string.Empty) {
                            cellinfo.Value = 0;
                        } else {
                            try {
                                Int16 cellvalue = Convert.ToInt16(cellinfo.Value);
                            } catch (Exception) {
                                return false;
                            }
                        }
                        break;
                    case "DATE":
                        if (cellinfo.Value == null || cellinfo.Value.ToString().Trim() == string.Empty) {
                            cellinfo.Value = 0;
                        } else {
                            if ((bool)this.FTSMain.SystemVars.GetSystemVars("EXCEL_TEMPLATE_DATE_AS_STRING")) {
                                try {
                                    DateTime cellvalue = Convert.ToDateTime(cellinfo.Value, this.FTSMain.FTSCultureInfo);
                                } catch (Exception) {
                                    return false;
                                }

                            } else {
                                try {
                                    DateTime cellvalue = Convert.ToDateTime(cellinfo.Value);
                                } catch (Exception) {
                                    return false;
                                }
                            }
                        }
                        break;
                }
            }
            return true;
        }

        private void cmdCreateExcel_Click(object sender, EventArgs e) {
            try {
                ObjectInfo oo = this.listTemplate.SelectedItem as ObjectInfo;
                if (oo == null) {
                    throw new FTSException("MSG_NO_TEMPLATE_SELECTED");
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = " Excel file (*.xls)|*.xls";
                sfd.ShowDialog();
                if (sfd.FileName != "") {
                    DataTable dt = new DataTable();
                    DataColumn dc;
                    this.mDm_template_detail = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DM_TEMPLATE_DETAIL WHERE FR_KEY = " + oo.ID + ""),
                                                                                 "DM_TEMPLATE_DETAIL");
                    this.mDm_template_detail.PrimaryKey = new DataColumn[] {mDm_template_detail.Columns["DATA_COLUMN_NAME"]};
                    foreach (DataRow templaterow in this.mDm_template_detail.Rows) {
                        switch (templaterow["DATA_TYPE"].ToString().ToUpper()) {
                            case "STRING":
                                dc = new DataColumn(templaterow["EXCEL_COLUMN_NO"].ToString(), Type.GetType("System.String"));
                                dc.DefaultValue = string.Empty;
                                dc.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                                dt.Columns.Add(dc);
                                break;
                            case "DECIMAL":
                                dc = new DataColumn(templaterow["EXCEL_COLUMN_NO"].ToString(), Type.GetType("System.Decimal"));
                                dc.DefaultValue = 0;
                                dc.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                                dt.Columns.Add(dc);
                                break;
                            case "INT":
                                dc = new DataColumn(templaterow["EXCEL_COLUMN_NO"].ToString(), Type.GetType("System.Int32"));
                                dc.DefaultValue = 0;
                                dc.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                                dt.Columns.Add(dc);
                                break;
                            case "BOOLEAN":
                                dc = new DataColumn(templaterow["EXCEL_COLUMN_NO"].ToString(), Type.GetType("System.Int16"));
                                dc.DefaultValue = 0;
                                dc.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                                dt.Columns.Add(dc);
                                break;
                            case "DATE":
                                dc = new DataColumn(templaterow["EXCEL_COLUMN_NO"].ToString(), Type.GetType("System.DateTime"));
                                dc.Caption = templaterow["EXCEL_COLUMN_NO"].ToString();
                                dt.Columns.Add(dc);
                                break;
                        }
                    }
                    this.grid.DataSource = dt;
                    foreach (GridColumn item in this.grid.ViewGrid.Columns) {
                        item.Visible = true;
                    }
                    this.grid.ViewGrid.ExportToXls(sfd.FileName);
                    this.OpenFile(sfd.FileName);
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
        private void OpenFile(string fileName) {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();

        }
        private void cmdCreateTemplate_Click(object sender, EventArgs e) {
            try {
                    FrmDm_Template f = new FrmDm_Template(FTSMain, "TEMPLATE", this.mManagerBase, this.mObjectBase);
                    f.ShowDialog();
                    this.LoadTemplate();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
    }
}