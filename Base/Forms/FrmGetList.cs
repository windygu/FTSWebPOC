// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:52
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmGetList.cs
// Project Item Filename:     FrmGetList.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
#endregion

namespace FTS.BaseUI.Forms {
    public class FrmGetList : FrmBaseForm {
        private IContainer components = null;
        private string mTableName;
        private TextEdit t;
        private FTSButton cmdClose;
        private FTSButton cmdOK;
        private FTSButton cmdRemoveAll;
        private FTSButton cmdRemove;
        private FTSButton cmdAddAll;
        private FTSButton cmdAdd;
        private FTSDataGrid gridSource;
        private FTSDataGrid gridDestination;
        private string mConditionString = string.Empty;
        private List<FieldInfo> mFieldCollection;
        private DataTable mScrtable;
        private DataTable mDestable;
        private DataTable mDataTable = null;
        private string mIdField = string.Empty;
        private string mNameField = string.Empty;

        public FrmGetList() {
            // This call is required by the Windows Form Designer.
            this.InitializeComponent();
        }

        public FrmGetList(FTSMain ftsmain, string tablename, TextEdit t) : base(ftsmain, true) {
            // This call is required by the Windows Form Designer.
            this.t = t;
            this.mTableName = tablename;
            this.InitializeComponent();
            this.InitDataTable();
            this.LoadFieldTemp();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);            
            this.LoadDanhMuc();
        }

        public FrmGetList(FTSMain ftsmain, DataTable datatable, string idfield, string namefield, TextEdit t): base(ftsmain, true)
        {
            // This call is required by the Windows Form Designer.
            this.t = t;
            this.mTableName = datatable.TableName;
            this.mDataTable = datatable;
            this.mIdField = idfield;
            this.mNameField = namefield;
            this.InitializeComponent();
            this.InitDataTable();
            this.LoadFieldTemp();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);
            this.LoadDanhMuc();
        }

        public FrmGetList(FTSMain ftsmain, string tablename, TextEdit t, string dieukieu) : base(ftsmain, true) {
            // This call is required by the Windows Form Designer.
            this.FTSMain = ftsmain;
            this.t = t;
            this.mConditionString = dieukieu;
            this.mTableName = tablename;
            this.InitializeComponent();
            this.InitDataTable();
            this.LoadFieldTemp();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);            
            this.LoadDanhMuc();
        }

        public FrmGetList(FTSMain ftsmain, DataTable datatable, string idfield, string namefield, TextEdit t, string dieukieu): base(ftsmain, true)
        {
            // This call is required by the Windows Form Designer.
            this.FTSMain = ftsmain;
            this.t = t;
            this.mConditionString = dieukieu;
            this.mTableName = datatable.TableName;
            this.mDataTable = datatable;
            this.mIdField = idfield;
            this.mNameField = namefield;
            this.InitializeComponent();
            this.InitDataTable();
            this.LoadFieldTemp();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);
            this.LoadDanhMuc();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdClose = new FTS.BaseUI.Controls.FTSButton();
            this.cmdOK = new FTS.BaseUI.Controls.FTSButton();
            this.cmdRemoveAll = new FTS.BaseUI.Controls.FTSButton();
            this.cmdRemove = new FTS.BaseUI.Controls.FTSButton();
            this.cmdAddAll = new FTS.BaseUI.Controls.FTSButton();
            this.cmdAdd = new FTS.BaseUI.Controls.FTSButton();
            this.gridSource = new FTS.BaseUI.Controls.FTSDataGrid();
            this.gridDestination = new FTS.BaseUI.Controls.FTSDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDestination)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.gridDestination);
            this.groupBox.Controls.Add(this.gridSource);
            this.groupBox.Controls.Add(this.cmdRemoveAll);
            this.groupBox.Controls.Add(this.cmdRemove);
            this.groupBox.Controls.Add(this.cmdAddAll);
            this.groupBox.Controls.Add(this.cmdAdd);
            this.groupBox.Controls.Add(this.cmdClose);
            this.groupBox.Controls.Add(this.cmdOK);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.Size = new System.Drawing.Size(572, 355);
            // 
            // cmdClose
            // 
            this.cmdClose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdClose.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdClose.Appearance.Options.UseBackColor = true;
            this.cmdClose.Appearance.Options.UseFont = true;
            this.cmdClose.Appearance.Options.UseForeColor = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.HelpText = "";
            this.cmdClose.Location = new System.Drawing.Point(288, 321);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(70, 22);
            this.cmdClose.TabIndex = 33;
            this.cmdClose.Text = "Bỏ qua";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdOK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdOK.Appearance.Options.UseBackColor = true;
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Appearance.Options.UseForeColor = true;
            this.cmdOK.HelpText = "";
            this.cmdOK.Location = new System.Drawing.Point(200, 321);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(70, 22);
            this.cmdOK.TabIndex = 32;
            this.cmdOK.Text = "Đồng ý";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdRemoveAll.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdRemoveAll.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdRemoveAll.Appearance.Options.UseBackColor = true;
            this.cmdRemoveAll.Appearance.Options.UseFont = true;
            this.cmdRemoveAll.Appearance.Options.UseForeColor = true;
            this.cmdRemoveAll.HelpText = "";
            this.cmdRemoveAll.Location = new System.Drawing.Point(264, 200);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(35, 22);
            this.cmdRemoveAll.TabIndex = 39;
            this.cmdRemoveAll.Text = "<<";
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdRemove.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdRemove.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdRemove.Appearance.Options.UseBackColor = true;
            this.cmdRemove.Appearance.Options.UseFont = true;
            this.cmdRemove.Appearance.Options.UseForeColor = true;
            this.cmdRemove.HelpText = "";
            this.cmdRemove.Location = new System.Drawing.Point(264, 168);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(35, 22);
            this.cmdRemove.TabIndex = 38;
            this.cmdRemove.Text = "<";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAddAll
            // 
            this.cmdAddAll.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddAll.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdAddAll.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdAddAll.Appearance.Options.UseBackColor = true;
            this.cmdAddAll.Appearance.Options.UseFont = true;
            this.cmdAddAll.Appearance.Options.UseForeColor = true;
            this.cmdAddAll.HelpText = "";
            this.cmdAddAll.Location = new System.Drawing.Point(264, 136);
            this.cmdAddAll.Name = "cmdAddAll";
            this.cmdAddAll.Size = new System.Drawing.Size(35, 22);
            this.cmdAddAll.TabIndex = 37;
            this.cmdAddAll.Text = ">>";
            this.cmdAddAll.Click += new System.EventHandler(this.cmdAddAll_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdAdd.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdAdd.Appearance.Options.UseBackColor = true;
            this.cmdAdd.Appearance.Options.UseFont = true;
            this.cmdAdd.Appearance.Options.UseForeColor = true;
            this.cmdAdd.HelpText = "";
            this.cmdAdd.Location = new System.Drawing.Point(264, 104);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(35, 22);
            this.cmdAdd.TabIndex = 36;
            this.cmdAdd.Text = ">";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // gridSource
            // 
            this.gridSource.Location = new System.Drawing.Point(8, 8);
            this.gridSource.Name = "gridSource";
            this.gridSource.Size = new System.Drawing.Size(250, 300);
            this.gridSource.TabIndex = 40;
            this.gridSource.ChooseRow += new FTS.BaseUI.Controls.SelectRowEventHandler(this.gridSource_ChooseRow);
            // 
            // gridDestination
            // 
            this.gridDestination.Location = new System.Drawing.Point(310, 8);
            this.gridDestination.Name = "gridDestination";
            this.gridDestination.Size = new System.Drawing.Size(250, 300);
            this.gridDestination.TabIndex = 41;
            this.gridDestination.ChooseRow += new FTS.BaseUI.Controls.SelectRowEventHandler(this.gridDestination_ChooseRow);
            // 
            // FrmGetList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(572, 355);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmGetList";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDestination)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private void LoadFieldTemp()
        {            
            this.mFieldCollection = new List<FieldInfo>();
            this.mFieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo("FRMGETLIST", "ID", DbType.String, false));
            this.mFieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo("FRMGETLIST", "NAME", DbType.String, false));            
        }
        private void InitDataTable()
        {            
            this.mScrtable = new DataTable("Source");
            this.mScrtable.Columns.Add("ID", Type.GetType("System.String"));
            this.mScrtable.Columns.Add("NAME", Type.GetType("System.String"));
            this.mDestable = new DataTable("Destination");
            this.mDestable.Columns.Add("ID", Type.GetType("System.String"));
            this.mDestable.Columns.Add("NAME", Type.GetType("System.String"));            
        }
        private void ConfigGrid()
        {            
            int index = 0;
            foreach (GridColumn col in this.gridSource.ViewGrid.Columns)
            {
                col.VisibleIndex = index;
                index++;
            }
            index = 0;
            foreach (GridColumn col in this.gridDestination.ViewGrid.Columns)
            {
                col.VisibleIndex = index;
                index++;
            }
            this.gridSource.ViewGrid.OptionsBehavior.Editable = false;
            this.gridSource.ViewGrid.OptionsView.ShowAutoFilterRow = true;
            this.gridSource.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridSource.ViewGrid.OptionsView.ShowIndicator = false;
            this.gridSource.ViewGrid.OptionsView.ShowFooter = false;
            this.gridSource.ViewGrid.Columns["ID"].Width = 60;
            this.gridSource.ViewGrid.Columns["NAME"].Width = 180;
            this.gridDestination.ViewGrid.OptionsBehavior.Editable = false;
            this.gridDestination.ViewGrid.OptionsView.ShowAutoFilterRow = true;
            this.gridDestination.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridDestination.ViewGrid.OptionsView.ShowIndicator = false;
            this.gridDestination.ViewGrid.OptionsView.ShowFooter = false;
            this.gridDestination.ViewGrid.Columns["ID"].Width = 60;
            this.gridDestination.ViewGrid.Columns["NAME"].Width = 180;            
        }
        private void BindGrid()
        {            
            this.gridSource.CreateGrid(this.mScrtable);
            this.gridSource.SetIDTextColumn(this.GetFieldInfo("ID"));
            this.gridSource.SetTextColumn(this.GetFieldInfo("NAME"), false);
            this.gridSource.BindDataTable();
            this.gridDestination.CreateGrid(this.mDestable);
            this.gridDestination.SetIDTextColumn(this.GetFieldInfo("ID"));
            this.gridDestination.SetTextColumn(this.GetFieldInfo("NAME"), false);
            this.gridDestination.BindDataTable();            
        }
        private FieldInfo GetFieldInfo(string fieldname)
        {
            try
            {
                for (int i = 0; i < this.mFieldCollection.Count; i++)
                {
                    if (string.Compare((this.mFieldCollection[i]).FieldName, fieldname, true) == 0)
                    {
                        return this.mFieldCollection[i];
                    }
                }
                throw (new FTSException("INVALID_FIELD_NAME", new object[] { fieldname }));
            }
            catch (FTSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw (new FTSException(ex));
            }
        }

        private void LoadDanhMuc() {
            this.mScrtable.Clear();
            this.mDestable.Clear();
            DataTable dt = null;
            string idField = string.Empty;
            string nameField = string.Empty;
            if (this.mDataTable == null)
            {
                idField = this.FTSMain.TableManager.GetIDField(this.mTableName);
                nameField = this.FTSMain.TableManager.GetNameField(this.mTableName);
                DbCommand cmd = null;
                if (this.mConditionString.Length == 0)
                {
                    cmd =
                        this.FTSMain.DbMain.GetSqlStringCommand("select " + idField + "," + nameField + " from " +
                                                                this.mTableName + " order by " + idField);
                }
                else
                {
                    cmd =
                        this.FTSMain.DbMain.GetSqlStringCommand("select " + idField + "," + nameField + " from " +
                                                                this.mTableName + " where " + this.mConditionString +
                                                                " order by " + idField);
                }
                dt = this.FTSMain.DbMain.LoadDataTable(cmd, this.mTableName);
            }
            else
            {
                idField = this.mIdField;
                nameField = this.mNameField;
                dt = this.mDataTable.Copy();
            }
            foreach (DataRow row in dt.Rows) {
                if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(row[idField].ToString(), this.t.Text.Trim())) {
                    this.mScrtable.Rows.Add(new object[] { row[idField].ToString(), row[nameField].ToString() });
                } else {
                    this.mDestable.Rows.Add(new object[] { row[idField].ToString(), row[nameField].ToString() });
                }
            }
            this.mScrtable.AcceptChanges();
            this.mDestable.AcceptChanges();
            dt.Clear();
        }

        private void cmdAdd_Click(object sender, EventArgs e) {
            try {
                this.AddSelectedItems(false);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdAddAll_Click(object sender, EventArgs e) {
            try {
                this.AddSelectedItems(true);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e) {
            try {
                this.RemoveSelectedItems(false);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e) {
            try {
                this.RemoveSelectedItems(true);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }        

        private void AddSelectedItems(bool All)
        {            
            if (!All)
            {
                if (this.gridSource.ViewGrid.FocusedRowHandle < 0)
                {
                    return;
                }
                DataRow scrRow = this.gridSource.ViewGrid.GetDataRow(this.gridSource.ViewGrid.FocusedRowHandle);
                this.mDestable.Rows.Add(new object[] { scrRow["ID"], scrRow["NAME"] });
                this.mScrtable.Rows.Remove(scrRow);
            }
            else
            {
                foreach (DataRow scrRow in this.mScrtable.Rows)
                {
                    this.mDestable.Rows.Add(new object[] { scrRow["ID"], scrRow["NAME"] });
                }
                this.mScrtable.Rows.Clear();
            }           
        }

        private void RemoveSelectedItems(bool All)
        {           
            if (!All)
            {
                if (this.gridDestination.ViewGrid.FocusedRowHandle < 0)
                {
                    return;
                }
                DataRow desRow = this.gridDestination.ViewGrid.GetDataRow(this.gridDestination.ViewGrid.FocusedRowHandle);
                this.mScrtable.Rows.Add(new object[] { desRow["ID"], desRow["NAME"] });
                this.mDestable.Rows.Remove(desRow);
            }
            else
            {
                foreach (DataRow desRow in this.mDestable.Rows)
                {
                    this.mScrtable.Rows.Add(new object[] { desRow["ID"], desRow["NAME"] });
                }
                this.mDestable.Rows.Clear();
            }            
        }

        private void cmdClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder rtn = new StringBuilder();
                for (int i = 0; i < this.gridDestination.ViewGrid.RowCount; i++)
                {
                    if (rtn.Length == 0)
                    {
                        rtn.Append(this.gridDestination.GetValue(i, "ID").ToString());
                    }
                    else
                    {
                        rtn.Append(",");
                        rtn.Append(this.gridDestination.GetValue(i, "ID").ToString());
                    }
                }
                if (this.t.Text.Trim() != rtn.ToString())
                {
                    this.t.Text = rtn.ToString();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void gridSource_ChooseRow(object sender, SelectRowEventArgs e)
        {
            try
            {
                this.AddSelectedItems(false);
            }            
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void gridDestination_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                this.RemoveSelectedItems(false);
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }
        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.Height = 383;
            this.Width = 578;
        }
    }
}