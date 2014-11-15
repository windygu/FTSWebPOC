#region

using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmSys_Field_EditList : FrmDataEditList {
        public FrmSys_Field_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Field_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.AllowCopy = false;
            this.AllowNew = false;
            this.ToolBar.ComboboxVisible = BarItemVisibility.Always;
            this.ToolBar.ItemChanged += new ComboChangedEventHandler(this.toolbar_ItemChanged);
            this.ConfigGrid();
            this.LoadLayout();
            this.SetControls();
            this.ConfigAction();
        }

        public override void BindGrid() {
            this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("TABLE_NAME"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("FIELD_NAME"), true);
            this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("FIELD_LENGTH"), 0);
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("REQUIRED"));
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("ALLOWDBNULL"));
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("BOUND"));
            this.Grid.BindData();
        }

        public override void LoadData() {
            this.DataObject = new Sys_Field(this.FTSMain);
        }

        public override void SetTextFooter() {
            string columnname = this.Grid.CurrentColumnName.ToUpper();
            string cellvalue = this.Grid.CurrentCellValue.ToString();
            switch (columnname) {
                default:
                    this.Grid.SetTextFooter(string.Empty);
                    break;
            }
        }

        public override void SetControls() {
            List<ItemCombobox> list = new List<ItemCombobox>();
            foreach (DataRow row in this.DataObject.DataSet.Tables["SYS_TABLE"].Rows) {
                list.Add(new ItemCombobox(row["TABLE_NAME"].ToString(), row["DISPLAY_NAME"].ToString()));
            }
            this.ToolBar.SetDataForCombobox(list);
        }

        private void toolbar_ItemChanged(object sender, ComboChangedEventArgs e) {
            try {
                if (this.CheckChanged() != ChangedStatus.CANCEL) {
                    ((Sys_Field) this.DataObject).parenttablename = e.Item.Id;
                    this.DataObject.LoadData();
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        public override void UpdateRecord() {
            base.UpdateRecord();
            this.FTSMain.FieldManager.ReLoadData(((Sys_Field) this.DataObject).parenttablename);
        }
    }
}