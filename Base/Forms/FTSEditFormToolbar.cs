#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ItemClickEventArgs = DevExpress.XtraBars.ItemClickEventArgs;
using ItemClickEventHandler = FTS.BaseUI.Controls.ItemClickEventHandler;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSEditFormToolbar : UserControl {
        public event ItemClickEventHandler ItemClick;
        public event ComboChangedEventHandler ItemChanged;
        public event GoItemToolbarEventHandler GoItemClick;
        private object mKey;

        public FTSEditFormToolbar() {
            this.InitializeComponent();
            ((RepositoryItemButtonEdit) this.txtGo.Edit).ButtonClick +=
                new ButtonPressedEventHandler(this.GoItem_ButtonClick);
            (this.txtGo.Edit).EditValueChanging += new ChangingEventHandler(this.GoItem_EditValueChanging);
        }

        public void SetFont() {
            this.bar.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 7);
        }

        private void GoItem_EditValueChanging(object sender, ChangingEventArgs e) {
            this.mKey = e.NewValue;
        }

        private void GoItem_ButtonClick(object sender, ButtonPressedEventArgs e) {
            if (this.GoItemClick != null) {
                this.GoItemClick(sender, new GoItemToolbarEventArgs(this.mKey));
            }
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility ComboboxVisible {
            get { return this.cboItem.Visibility; }
            set { this.cboItem.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ComboboxEnable {
            get { return this.cboItem.Enabled; }
            set { this.cboItem.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility NewVisible {
            get { return this.btnNew.Visibility; }
            set { this.btnNew.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool NewEnable {
            get { return this.btnNew.Enabled; }
            set { this.btnNew.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility CopyVisible {
            get { return this.btnCopy.Visibility; }
            set { this.btnCopy.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool CopyEnable {
            get { return this.btnCopy.Enabled; }
            set { this.btnCopy.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility SaveVisible {
            get { return this.btnSave.Visibility; }
            set { this.btnSave.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool SaveEnable {
            get { return this.btnSave.Enabled; }
            set { this.btnSave.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility SaveNewVisible {
            get { return this.btnSaveNew.Visibility; }
            set { this.btnSaveNew.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool SaveNewEnable {
            get { return this.btnSaveNew.Enabled; }
            set { this.btnSaveNew.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility UndoVisible {
            get { return this.btnUndo.Visibility; }
            set { this.btnUndo.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool UndoEnable {
            get { return this.btnUndo.Enabled; }
            set { this.btnUndo.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility DeleteVisible {
            get { return this.btnDelete.Visibility; }
            set { this.btnDelete.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool DeleteEnable {
            get { return this.btnDelete.Enabled; }
            set { this.btnDelete.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility RefreshVisible {
            get { return this.btnRefresh.Visibility; }
            set { this.btnRefresh.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool RefreshEnable {
            get { return this.btnRefresh.Enabled; }
            set { this.btnRefresh.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility FilterVisible {
            get { return this.btnFilter.Visibility; }
            set { this.btnFilter.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool FilterEnable {
            get { return this.btnFilter.Enabled; }
            set { this.btnFilter.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ImportExcelVisible {
            get { return this.btnImportExcel.Visibility; }
            set { this.btnImportExcel.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ImportExcelEnable {
            get { return this.btnImportExcel.Enabled; }
            set { this.btnImportExcel.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ExportExcelVisible{
            get { return this.btnExportExcel.Visibility; }
            set { this.btnExportExcel.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ExportExcelEnable {
            get { return this.btnExportExcel.Enabled; }
            set { this.btnExportExcel.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility PrintVisible {
            get { return this.btnPrint.Visibility; }
            set { this.btnPrint.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool PrintEnable {
            get { return this.btnPrint.Enabled; }
            set { this.btnPrint.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility HelpVisible {
            get { return this.btnHelp.Visibility; }
            set { this.btnHelp.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool HelpEnable {
            get { return this.btnHelp.Enabled; }
            set { this.btnHelp.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility EditVisible {
            get { return this.btnEdit.Visibility; }
            set { this.btnEdit.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool EditEnable {
            get { return this.btnEdit.Enabled; }
            set { this.btnEdit.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility CloseVisible {
            get { return this.btnClose.Visibility; }
            set { this.btnClose.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool CloseEnable {
            get { return this.btnClose.Enabled; }
            set { this.btnClose.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility NextVisible {
            get { return this.btnNext.Visibility; }
            set { this.btnNext.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool NextEnable {
            get { return this.btnNext.Enabled; }
            set { this.btnNext.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility PreviousVisible {
            get { return this.btnPrevious.Visibility; }
            set { this.btnPrevious.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool PreviousEnable {
            get { return this.btnPrevious.Enabled; }
            set { this.btnPrevious.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ConfigVisible {
            get { return this.dropConfig.Visibility; }
            set { this.dropConfig.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ConfigEnable {
            get { return this.dropConfig.Enabled; }
            set { this.dropConfig.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility SaveCloseVisible {
            get { return this.btnSaveClose.Visibility; }
            set { this.btnSaveClose.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool SaveCloseEnable {
            get { return this.btnSaveClose.Enabled; }
            set { this.btnSaveClose.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility GoItemVisible {
            get { return this.txtGo.Visibility; }
            set { this.txtGo.Visibility = value; }
        }

        [Browsable(false)]
        public ImageCollection ImageList {
            get { return this.imageList; }
        }

        private bool mShowEditButton = true;

        [DefaultValue(true)]
        public bool ShowEditButton {
            get { return this.mShowEditButton; }
            set { this.mShowEditButton = value; }
        }

        public void SetDataForCombobox(List<ItemCombobox> list) {
            if (list != null) {
                foreach (ItemCombobox item in list) {
                    this.Combobox.Items.Add(item);
                }
            }
        }

        public void SetComboBoxValue(ItemCombobox id) {
            this.cboItem.EditValue = id;
        }

        private void Item_Click(object sender, ItemClickEventArgs e) {
            if (e.Item is BarButtonItem) {
                BarButtonItem item = (BarButtonItem) e.Item;
                Controls.ItemClickEventArgs EventArg;
                if (item.Tag != null) {
                    EventArg = new Controls.ItemClickEventArgs(item.Tag.ToString());
                } else {
                    EventArg = new Controls.ItemClickEventArgs(string.Empty);
                }
                if (this.ItemClick != null) {
                    this.ItemClick(item, EventArg);
                }
            }
        }

        private void cboItem_EditValueChanged(object sender, EventArgs e) {
            if (this.ItemChanged != null) {
                this.ItemChanged(sender, new ComboChangedEventArgs((ItemCombobox) this.cboItem.EditValue));
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            SendKeys.Send("{Tab}");
        }

        public void LoadLayout(FTSMain ftsmain) {
            DataTable sys_forminfo;
            this.Name = "FTSEDITFORMTOOLBAR";
            sys_forminfo = new DataTable();
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN) {
                DbCommand cmd =
                    ftsmain.DbMain.GetSqlStringCommand("select * from sys_forminfo where form_name='" + this.Name + "'");
                sys_forminfo = ftsmain.DbMain.LoadDataTable(cmd, "sys_forminfo");
            } else {
                DbCommand cmd =
                    ftsmain.SysCacheVista.GetSqlStringCommand("select * from sys_forminfo where form_name='" + this.Name + "'");
                sys_forminfo = ftsmain.SysCacheVista.LoadDataTable(cmd, "sys_forminfo");
            }
            sys_forminfo.PrimaryKey = new DataColumn[] {
                                                          sys_forminfo.Columns["FORM_NAME"], sys_forminfo.Columns["OBJECT_NAME"],
                                                          sys_forminfo.Columns["PROPERTY_NAME"]
                                                      };
            foreach (BarItem item in this.barManager.Items) {
                BarButtonItem buttonitem = item as BarButtonItem;
                if (buttonitem != null) {
                    string itemname = item.Name.ToUpper();
                    item.Caption =
                        ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + itemname + "_TEXT",
                                                         item.Caption);
                    item.Hint =
                        ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + itemname + "_TOOLTIP",
                                                         item.Caption);
                    DataRow foundrow = sys_forminfo.Rows.Find(new object[] {this.Name, itemname, "ENABLED"});
                    if (foundrow != null) {
                        item.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                    } else {
                        this.UpdateProperty(ftsmain, sys_forminfo, itemname, "ENABLED", "BOOLEAN",
                                            item.Enabled ? "1" : "0");
                    }
                    foundrow = sys_forminfo.Rows.Find(new object[] {this.Name, itemname, "VISIBLE"});
                    if (foundrow != null) {
                        item.Visibility = (foundrow["property_value"].ToString() == "1")
                                              ? BarItemVisibility.Always
                                              : BarItemVisibility.Never;
                    } else {
                        this.UpdateProperty(ftsmain, sys_forminfo, itemname, "VISIBLE", "BOOLEAN",
                                            item.Visibility == BarItemVisibility.Always ? "1" : "0");
                    }
                }
            }
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN) {
                if (sys_forminfo.GetChanges() != null) {
                    ftsmain.DbMain.UpdateTable(sys_forminfo,
                                               ftsmain.DbMain.CreateInsertCommand("sys_forminfo", sys_forminfo),
                                               ftsmain.DbMain.CreateUpdateCommand("sys_forminfo", sys_forminfo, "PR_KEY"),
                                               null, UpdateBehavior.Standard);
                }
                Functions.ClearTable(sys_forminfo);
            }
            if (this.mShowEditButton) {
                this.btnEdit.Visibility = BarItemVisibility.Always;
            } else {
                this.btnEdit.Visibility = BarItemVisibility.Never;
            }
            if (ftsmain.Language == Language.JP || ftsmain.Language == Language.LAOS) {
                this.SetFont();
            }
        }

        public void UpdateProperty(FTSMain ftsmain, DataTable sys_forminfo, string objectname, string propertyname,
                                   string propertytype, string propertyvalue) {
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN) {
                DataRow foundrow = sys_forminfo.Rows.Find(new object[] {this.Name, objectname, propertyname});
                if (foundrow != null) {
                    foundrow["property_value"] = propertyvalue;
                } else {
                    foundrow = sys_forminfo.NewRow();
                    foundrow["PR_KEY"] = FunctionsBase.GetPr_key("sys_forminfo", ftsmain);
                    foundrow["form_name"] = this.Name;
                    foundrow["object_name"] = objectname;
                    foundrow["property_name"] = propertyname;
                    foundrow["property_value"] = propertyvalue;
                    foundrow["property_type"] = propertytype;
                    sys_forminfo.Rows.Add(foundrow);
                }
            }
        }
    }
}