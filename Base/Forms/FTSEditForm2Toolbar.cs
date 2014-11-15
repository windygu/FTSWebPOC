#region

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ItemClickEventHandler = FTS.BaseUI.Controls.ItemClickEventHandler;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSEditForm2Toolbar : UserControl {
        public event ItemClickEventHandler ItemClick;

        public FTSEditForm2Toolbar() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.bar.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 7);
        }

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility ImportExcelVisible {
            get { return this.btnImportExcel.Visibility; }
            set { this.btnImportExcel.Visibility = value; }
        }

        [DefaultValue(false)]
        public bool ImportExcelEnable {
            get { return this.btnImportExcel.Enabled; }
            set { this.btnImportExcel.Enabled = value; }
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
        public BarItemVisibility OpenVisible {
            get { return this.btnOpen.Visibility; }
            set { this.btnOpen.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool OpenEnable {
            get { return this.btnOpen.Enabled; }
            set { this.btnOpen.Enabled = value; }
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

        [DefaultValue(BarItemVisibility.Never)]
        public BarItemVisibility EntryVisible {
            get { return this.btnEntry.Visibility; }
            set { this.btnEntry.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool EntryEnable {
            get { return this.btnEntry.Enabled; }
            set { this.btnEntry.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility MoneyVisible {
            get { return this.btnMoney.Visibility; }
            set { this.btnMoney.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool MoneyEnable {
            get { return this.btnMoney.Enabled; }
            set { this.btnMoney.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility UnequalVisible {
            get { return this.btnUnequal.Visibility; }
            set { this.btnUnequal.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool UnequalEnable {
            get { return this.btnUnequal.Enabled; }
            set { this.btnUnequal.Enabled = value; }
        }

        [DefaultValue(true)]
        public bool OptionEnable {
            get { return this.btnOption.Enabled; }
            set { this.btnOption.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility OptionVisible {
            get { return this.btnOption.Visibility; }
            set { this.btnOption.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool DepositEnable
        {
            get { return this.btnDeposit.Enabled; }
            set { this.btnDeposit.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility DepositVisible
        {
            get { return this.btnDeposit.Visibility; }
            set { this.btnDeposit.Visibility = value; }
        }

        [DefaultValue(true)]
        public bool CheckInEnable
        {
            get { return this.btnCheck_In.Enabled; }
            set { this.btnCheck_In.Enabled = value; }
        }

        [DefaultValue(BarItemVisibility.Always)]
        public BarItemVisibility CheckInVisible
        {
            get { return this.btnCheck_In.Visibility; }
            set { this.btnCheck_In.Visibility = value; }
        }

        [Browsable(false)]
        public ImageCollection ImageList {
            get { return this.imageList; }
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
            this.Name = "FTSEDITFORM2TOOLBAR";
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
                    DataRow foundrow = sys_forminfo.Rows.Find(new object[] {this.Name.ToUpper(), itemname, "ENABLED"});
                    if (foundrow != null) {
                        item.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                    } else {
                        this.UpdateProperty(ftsmain, sys_forminfo, itemname, "ENABLED", "BOOLEAN",
                                            item.Enabled ? "1" : "0");
                    }
                    foundrow = sys_forminfo.Rows.Find(new object[] {this.Name.ToUpper(), itemname, "VISIBLE"});
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
                DataRow foundrow = sys_forminfo.Rows.Find(new object[] {this.Name.ToUpper(), objectname, propertyname});
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