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
    public partial class FTSSelectItemToolbar : UserControl {
        public event ItemClickEventHandler ItemClick;

        public FTSSelectItemToolbar() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.bar.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 7);
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
        public BarItemVisibility EditListVisible {
            get { return this.btnEditList.Visibility; }
            set { this.btnEditList.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool EditListEnable {
            get { return this.btnEditList.Enabled; }
            set { this.btnEditList.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility ChoiceVisible {
            get { return this.btnChoice.Visibility; }
            set { this.btnChoice.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ChoiceEnable {
            get { return this.btnChoice.Enabled; }
            set { this.btnChoice.Enabled = value; }
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
        public BarItemVisibility ChangeIDVisible {
            get { return this.btnChangeID.Visibility; }
            set { this.btnChangeID.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ChangeIDEnable {
            get { return this.btnChangeID.Enabled; }
            set { this.btnChangeID.Enabled = value; }
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
        public BarItemVisibility ExportExcelVisible {
            get { return this.btnExportExcel.Visibility; }
            set { this.btnExportExcel.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool ExportExcelEnable {
            get { return this.btnExportExcel.Enabled; }
            set { this.btnExportExcel.Enabled = value; }
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

        protected override void OnGotFocus(EventArgs e) {
            SendKeys.Send("{Tab}");
        }

        public void LoadLayout(FTSMain ftsmain) {
            DataTable sys_forminfo;
            this.Name = "FTSSELECTITEMTOOLBAR";
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
                    foundrow["form_name"] = "FTSSELECTITEMTOOLBAR";
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