#region

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ItemClickEventHandler = FTS.BaseUI.Controls.ItemClickEventHandler;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSTranPrintToolbar : UserControl {
        public event ItemClickEventHandler ItemClick;

        public FTSTranPrintToolbar() {
            this.InitializeComponent();
            this.btnLast.Visibility = BarItemVisibility.Never;
            this.btnNext.Visibility = BarItemVisibility.Never;
            this.btnFirst.Visibility = BarItemVisibility.Never;
            this.btnPrevious.Visibility = BarItemVisibility.Never;
        }

        public void SetFont() {
            this.bar.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 7);
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility PrintVisible {
            get { return this.btnPrint.Visibility; }
            set { this.btnPrint.Visibility = value; }
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility FirstVisible {
            get { return this.btnFirst.Visibility; }
            set { this.btnFirst.Visibility = value; }
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility LastVisible {
            get { return this.btnLast.Visibility; }
            set { this.btnLast.Visibility = value; }
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility NextVisible {
            get { return this.btnNext.Visibility; }
            set { this.btnNext.Visibility = value; }
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility PreviousVisible {
            get { return this.btnPrevious.Visibility; }
            set { this.btnPrevious.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool PrintEnable {
            get { return this.btnPrint.Enabled; }
            set { this.btnPrint.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility DesignVisible {
            get { return this.btnDesign.Visibility; }
            set { this.btnDesign.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool DesignEnable {
            get { return this.btnDesign.Enabled; }
            set { this.btnDesign.Enabled = value; }
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
        public BarItemVisibility HelpVisible {
            get { return this.btnHelp.Visibility; }
            set { this.btnHelp.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool HelpEnable {
            get { return this.btnHelp.Enabled; }
            set { this.btnHelp.Enabled = value; }
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

        protected override void OnGotFocus(EventArgs e) {
            SendKeys.Send("{Tab}");
        }

        public void LoadLayout(FTSMain ftsmain) {
            DataTable sys_forminfo;
            this.Name = "FTSTRANPRINTTOOLBAR";
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
}