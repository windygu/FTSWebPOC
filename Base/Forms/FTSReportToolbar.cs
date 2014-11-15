#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
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
    public partial class FTSReportToolbar : UserControl {
        public event ItemClickEventHandler ItemClick;
        public event ComboChangedEventHandler ViewChanged;

        public FTSReportToolbar() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.bar.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 7);
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ColumnsVisible {
            get { return this.btnColumns.Visibility; }
            set { this.btnColumns.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ColumnsEnable {
            get { return this.btnColumns.Enabled; }
            set { this.btnColumns.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility FirstVisible {
            get { return this.btnFirst.Visibility; }
            set { this.btnFirst.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool FirstEnable {
            get { return this.btnFirst.Enabled; }
            set { this.btnFirst.Enabled = value; }
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
        public BarItemVisibility LastVisible {
            get { return this.btnLast.Visibility; }
            set { this.btnLast.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool LastEnable {
            get { return this.btnLast.Enabled; }
            set { this.btnLast.Enabled = value; }
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
        public BarItemVisibility ExportVisible {
            get { return this.btnExport.Visibility; }
            set { this.btnExport.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ExportEnable {
            get { return this.btnExport.Enabled; }
            set { this.btnExport.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ZoomVisible {
            get { return this.btnZoom.Visibility; }
            set { this.btnZoom.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ZoomEnable {
            get { return this.btnZoom.Enabled; }
            set { this.btnZoom.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility FindVisible {
            get { return this.btnFind.Visibility; }
            set { this.btnFind.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool FindEnable {
            get { return this.btnFind.Enabled; }
            set { this.btnFind.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility PartVisible {
            get { return this.btnPart.Visibility; }
            set { this.btnPart.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool PartEnable {
            get { return this.btnPart.Enabled; }
            set { this.btnPart.Enabled = value; }
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
        public BarItemVisibility SortVisible {
            get { return this.btnSort.Visibility; }
            set { this.btnSort.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool SortEnable {
            get { return this.btnSort.Enabled; }
            set { this.btnSort.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility FontVisible {
            get { return this.btnFont.Visibility; }
            set { this.btnFont.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool FontEnable {
            get { return this.btnFont.Enabled; }
            set { this.btnFont.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility TitleVisible {
            get { return this.btnTitle.Visibility; }
            set { this.btnTitle.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool TitleEnable {
            get { return this.btnTitle.Enabled; }
            set { this.btnTitle.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility GroupVisible {
            get { return this.btnGroup.Visibility; }
            set { this.btnGroup.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool GroupEnable {
            get { return this.btnGroup.Enabled; }
            set { this.btnGroup.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility PageSetupVisible {
            get { return this.btnPageSetup.Visibility; }
            set { this.btnPageSetup.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool PageSetupEnable {
            get { return this.btnPageSetup.Enabled; }
            set { this.btnPageSetup.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ViewVisible {
            get { return this.cboView.Visibility; }
            set { this.cboView.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ViewEnable {
            get { return this.cboView.Enabled; }
            set { this.cboView.Enabled = value; }
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
        public BarItemVisibility ConfigVisible {
            get { return this.btnConfig.Visibility; }
            set { this.btnConfig.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ConfigEnable {
            get { return this.btnConfig.Enabled; }
            set { this.btnConfig.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ExcelVisible {
            get { return this.btnToExcel.Visibility; }
            set { this.btnToExcel.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ExcelEnable {
            get { return this.btnToExcel.Enabled; }
            set { this.btnToExcel.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility WordVisible {
            get { return this.btnToWord.Visibility; }
            set { this.btnToWord.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool WordEnable {
            get { return this.btnToWord.Enabled; }
            set { this.btnToWord.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility HtmlVisible {
            get { return this.btnToHtml.Visibility; }
            set { this.btnToHtml.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool HtmlEnable {
            get { return this.btnToHtml.Enabled; }
            set { this.btnToHtml.Enabled = value; }
        }

        public void CreateDropItemPart(string text) {
            ((ISupportInitialize) (this.barManager)).BeginInit();
            this.barManager.MaxItemId = this.barManager.MaxItemId + 1;
            BarCheckItem item = new BarCheckItem();
            item.Caption = ((ReportForm) this.FindForm()).FTSMain.MsgManager.GetMessage("MSG_PART") + text;
            item.Tag = text;
            item.Name = text;
            item.Id = this.barManager.MaxItemId;
            this.barManager.Items.AddRange(new BarItem[] {item});
            this.btnPart.LinksPersistInfo.AddRange(new LinkPersistInfo[] {new LinkPersistInfo(item)});
            item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropPart_Click);
            ((ISupportInitialize) (this.barManager)).EndInit();
        }

        private void DropPart_Click(object sender, ItemClickEventArgs e) {
            foreach (LinkPersistInfo link in this.btnPart.LinksPersistInfo) {
                ((BarCheckItem) link.Item).Checked = false;
            }
            BarCheckItem item = (BarCheckItem) e.Item;
            item.Checked = true;
            this.btnPart.Caption = item.Caption;
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

        private void DropExport_Click(object sender, ItemClickEventArgs e) {
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

        private void DropZoom_Click(object sender, ItemClickEventArgs e) {
            foreach (LinkPersistInfo link in this.btnZoom.LinksPersistInfo) {
                ((BarCheckItem) link.Item).Checked = false;
            }
            BarCheckItem item = (BarCheckItem) e.Item;
            item.Checked = true;
            this.btnZoom.Caption = item.Caption;
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

        public void SetDataForCombobox(List<ItemCombobox> list) {
            if (list != null) {
                foreach (ItemCombobox item in list) {
                    this.ComboBox.Items.Add(item);
                }
            }
        }

        private void cboView_EditValueChanged(object sender, EventArgs e) {
            if (this.ViewChanged != null) {
                this.ViewChanged(sender, new ComboChangedEventArgs((ItemCombobox) this.cboView.EditValue));
            }
        }

        [Browsable(false)]
        public ReportView View {
            get {
                if (this.cboView.EditValue == null || ((ItemCombobox) this.cboView.EditValue).Id == "TH") {
                    return ReportView.TH;
                } else {
                    return ReportView.CT;
                }
            }
            set {
                if (this.ComboBox.Items.Count != 0) {
                    if (value == ReportView.TH) {
                        this.cboView.EditValue = this.ComboBox.Items[0];
                    } else {
                        this.cboView.EditValue = this.ComboBox.Items[1];
                    }
                }
            }
        }

        public void LoadLayout(FTSMain ftsmain) {
            DataTable sys_forminfo;
            this.Name = "FTSREPORTTOOLBAR";
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

    public enum ReportView {
        TH = 0,
        CT = 1
    }
}