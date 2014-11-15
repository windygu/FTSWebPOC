using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Business;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Security;

namespace FTS.MainUI.Systems {
    public partial class MainFormERP : FTSMainForm {
        private FTSMain mFTSMain;
        private List<StartProcedures> startProcedures;
     

        public MainFormERP() {
            this.InitializeComponent();
        }

        public MainFormERP(FTSMain ftsMain, List<StartProcedures> startProcedures) {
            this.startProcedures = startProcedures;
            this.mFTSMain = ftsMain;
            this.InitializeComponent();
            this.toolStripStatusLabel.Text = (string) this.mFTSMain.SystemVars.GetSystemVars("SYSTEM_NAME") + " - " +
                                             this.mFTSMain.SystemVars.GetSystemVars("COMPANY_NAME").ToString() + " - " +
                                             this.mFTSMain.WorkingDay.ToString() + " - " +
                                             this.mFTSMain.UserInfo.UserName;
            if (this.mFTSMain.DEMO) {
                this.toolStripStatusLabel.Text += " - " + "Demo Version";
            } else {
                this.toolStripStatusLabel.Text += " - " + "Registered Version";
            }
            this.tabstrip.MdiTabbedDocuments = true;
            this.LoadLayout(this.mFTSMain);
            this.Text = "FTS Business Solution 2012";
            this.LoadMenu();
            this.SetFonts();
        }

        private void SetFonts() {
            if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS) {
                this.ribbonControl.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_EXIT")) == DialogResult.No) {
                e.Cancel = true;
                return;
            }
            base.OnClosing(e);
        }

        private void CommandButton_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                foreach (StartProcedures s in this.startProcedures) {
                    s.ExecuteProcedures(e.Item.Tag.ToString());
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        private void TransactionButton_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                foreach (StartProcedures s in this.startProcedures) {
                    s.RunTransaction(e.Item.Tag.ToString());
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        public override void LoadReport(string reportid, string parentreportid) {
            try {
                foreach (StartProcedures s in this.startProcedures) {
                    s.LoadReport(reportid, parentreportid);
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        private void ReportButton_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                foreach (StartProcedures s in this.startProcedures) {
                    s.LoadReport(e.Item.Tag.ToString());
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        private void CommandButtonSystem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                this.ExecuteSystemProcedures(e.Item.Tag.ToString());
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!this.DesignMode) {
                if (this.mFTSMain.ProjectID[0] == ProjectList.Hotel) {
                    if (File.Exists(this.mFTSMain.PathName + "FTS.HotelUI.dll")) {
                        Type type =
                            Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HotelUI.dll").GetType(
                                "FTS.HotelUI.Hotel.FrmMainMap");
                        Type[] typeArray = new Type[1] {typeof (FTSMain)};
                        ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                        if (constructorInfoObj != null) {
                            Object[] objArg = new object[1] {this.mFTSMain};
                            FTSForm frmmapruntime = (FTSForm) constructorInfoObj.Invoke(objArg);
                            frmmapruntime.Show();
                            frmmapruntime.GetType().GetMethod("LoadFloors").Invoke(frmmapruntime, null);
                        }
                    }
                }
                if (this.mFTSMain.ProjectID[0] == ProjectList.HRM) {
                    if (File.Exists(this.mFTSMain.PathName + "FTS.HRMUI.dll")) {
                        Assembly assem = Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HRMUI.dll");
                        Type type = assem.GetType("FTS.HRMUI.Systems.FrmHrm_DashBoard", false, true);
                        Type[] typeArray = new Type[1] {typeof (FTSMain)};
                        ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                        if (constructorInfoObj != null) {
                            Object[] objArg = new object[1] {this.mFTSMain};
                            FTSForm frmdashboard = (FTSForm) constructorInfoObj.Invoke(objArg);
                            frmdashboard.Show();
                        }
                    }
                }
            }
        }

        private void ExecuteSystemProcedures(string menuid) {
            try {
                switch (menuid) {
                        #region Hethong

                    case "LOGGING":
                        (new FrmLogging_List(this.mFTSMain)).Show();
                        break;
                    case "USERS":
                        (new FrmiPermission(this.mFTSMain)).Show();
                        break;
                    case "LOCK":
                        (new FrmLock(this.mFTSMain)).ShowDialog();
                        break;
                    case "EXIT":
                        this.Close();
                        break;
                    case "SYS_TRAN_NO":
                        (new FrmSys_Tran_No_EditList(this.mFTSMain)).Show();
                        break;
                    case "CHANGEID":
                        /*
                        (new FrmTranManager(this.mFTSMain)).Show();
                        */
                        break;
                    case "SYS_MENU":
                        (new FrmSys_Menu_EditList(this.mFTSMain)).Show();
                        break;
                    case "SYS_REPORT":
                        (new FrmSys_Report_EditList(this.mFTSMain)).Show();
                        break;
                    case "SYS_FIELD":
                        (new FrmSys_Field_EditList(this.mFTSMain)).Show();
                        break;
                    case "SYS_TABLE":
                        (new FrmSys_Table_EditList(this.mFTSMain)).Show();
                        break;
                    case "SYS_RESOURCE":
                        (new FrmSys_Resource_EditList(this.mFTSMain)).Show();
                        break;
                    case "TRANSACTION_LIST":
                        (new FrmTranManager(this.mFTSMain)).Show();
                        break;
                    case "NIGHT_AUDIT":
                        if (File.Exists(this.mFTSMain.PathName + "FTS.HotelUI.dll")) {
                            Type type =
                                Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HotelUI.dll").GetType(
                                    "FTS.HotelUI.Hotel.FrmNight_Audit");
                            Type[] typeArray = new Type[1] {typeof (FTSMain)};
                            ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                            if (constructorInfoObj != null) {
                                Object[] objArg = new object[1] {this.mFTSMain};
                                ((FrmDataEditList) constructorInfoObj.Invoke(objArg)).Show();
                            }
                        }
                        break;
                    case "ID_CONFIG":
                        (new IdConfigForm(this.mFTSMain)).ShowDialog();
                        break;
                    case "COMMUNICATE_CONFIG":
                        (new FrmDm_Communicate_Config_EditList(this.mFTSMain)).Show();
                        break;
                    case "DATA_LOG":
                        (new FrmData_Log_EditList(this.mFTSMain)).Show();
                        break;
                    case "DM_ORGANIZATION":
                        (new FrmDm_Organization_TreeList(this.mFTSMain)).Show();
                        break;
                    case "CHECK_DATA_LOG":
                        (new FrmCheck_Data_Log(this.mFTSMain)).Show();
                        break;
                    case "POS":
                        if (File.Exists(this.mFTSMain.PathName + "FTS.AccUI.dll")) {
                            Type type =
                                Assembly.LoadFile(this.mFTSMain.PathName + "FTS.AccUI.dll").GetType(
                                    "FTS.AccUI.Systems.FrmPosData");
                            Type[] typeArray = new Type[1] {typeof (FTSMain)};
                            ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                            if (constructorInfoObj != null) {
                                Object[] objArg = new object[1] {this.mFTSMain};
                                ((FrmBaseForm) constructorInfoObj.Invoke(objArg)).ShowDialog();
                            }
                        }
                        break;

                        #endregion Hethong

                    default:
                        break;
                }
            } catch (Exception ex) {
                if (ex.InnerException is FTSException) {
                    throw new FTSException(((FTSException) ex.InnerException).ExceptionID, ((FTSException) ex.InnerException).Parameter);
                }
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
        }

        private void LoadMenu() {
            BarAndDockingController barAndDockingController = new DevExpress.XtraBars.BarAndDockingController(this.components);
            if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                barAndDockingController.AppearancesRibbon.PageGroupCaption.Font = new Font(FTSConstant.JAPANESE_FONT, barAndDockingController.AppearancesRibbon.PageGroupCaption.Font.Size);
                barAndDockingController.AppearancesRibbon.PageHeader.Font = new Font(FTSConstant.JAPANESE_FONT, barAndDockingController.AppearancesRibbon.PageHeader.Font.Size);
                barAndDockingController.AppearancesRibbon.Item.Font = new Font(FTSConstant.JAPANESE_FONT, barAndDockingController.AppearancesRibbon.Item.Font.Size);
            }
            this.ribbonControl.Controller = barAndDockingController;
            foreach (string projectid in this.mFTSMain.ProjectID) {
                this.LoadMenu(projectid);
            }
        }

        private void LoadMenu(string projectid) {
            bool is_hide = false;
            try {
                is_hide = Convert.ToBoolean(this.mFTSMain.SystemVars.GetSystemVars("IS_HIDE_MENU"));
            } catch (Exception) {
                is_hide = false;
            }
            string sql = string.Empty;
            if (is_hide) {
                sql = "SELECT  * FROM    sys_menu " +
                      " WHERE   project_id = '" + projectid + "' AND active = 1 " +
                      " AND menu_id IN ( SELECT DISTINCT menu_id FROM   sys_menu_mapping a ,sec_permission b WHERE  a.function_id = b.function_id AND b.is_view = 1) ";
            } else {
                sql = "select * from sys_menu where project_id='" + projectid +
                      "' and active=1 order by module_id,menu_order";
            }
            DataTable sysmenu = this.mFTSMain.DbMain.LoadDataTable(this.mFTSMain.DbMain.GetSqlStringCommand(sql),
                                                                   "SYS_MENU");
            sql = "select * from sec_user_group where user_group_id in " + Functions.PopulateString(this.mFTSMain.UserInfo.UserGroupID) + "";
            DataTable sec_user_group = this.mFTSMain.DbMain.LoadDataTable(
                this.mFTSMain.DbMain.GetSqlStringCommand(sql), "sec_user_group");
            string modulelist = string.Empty;
            foreach (DataRow row in sec_user_group.Rows) {
                modulelist += row["MODULE_LIST"].ToString() + ",";
            }
            string[] module_list = modulelist.Split(',');
            List<ItemCombobox> listmodule = ModuleList.GetModuleList(this.mFTSMain);
            foreach (ItemCombobox item in listmodule) {
                DataView sysmenuview = new DataView(sysmenu, "MODULE_ID='" + item.Id + "'", "MENU_ORDER",
                                                    DataViewRowState.CurrentRows);
                if (sysmenuview.Count > 0) {
                    //if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN") {
                    //    this.LoadModule(sysmenuview, item);
                    //} else {
                    if (module_list != null) {
                        for (int i = 0; i < module_list.Length; i++) {
                            if (module_list[i] == item.Id) {
                                this.LoadModule(sysmenuview, item);
                                break;
                            }
                        }
                    }
                    //}
                }
            }
        }

        private void LoadModule(DataView sysmenuview, ItemCombobox item) {
            DevExpress.XtraBars.Ribbon.RibbonPage page = new RibbonPage();
            this.ribbonControl.Pages.Add(page);
            page.Name = "PAGE_" + item.Id;
            page.Text = item.Name;
            if (Functions.FileExists(this.mFTSMain.PathName + "Graphics\\" + ModuleList.GetModuleIcon(item.Id))) {
                page.Image = Image.FromFile(this.mFTSMain.PathName + "Graphics\\" + ModuleList.GetModuleIcon(item.Id));
            }
            bool islist = false;
            foreach (DataRowView drv in sysmenuview) {
                if (drv["MENU_TYPE"].ToString() == "LIST") {
                    islist = true;
                    break;
                }
            }
            if (islist) {
                DevExpress.XtraBars.Ribbon.RibbonPageGroup groupList = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                page.Groups.Add(groupList);
                groupList.Name = "groupList";
                groupList.ShowCaptionButton = false;
                groupList.Text = string.Empty;
                BarSubItem listitem = new BarSubItem();
                if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                    listitem.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, listitem.Font.Size);
                }
                listitem.Caption = this.mFTSMain.MsgManager.GetMessage("MNU_LIST");
                listitem.Name = "MNU_LIST_" + item.Id;
                listitem.LargeWidth = 80;
                groupList.ItemLinks.Add(listitem);
                listitem.LargeGlyph = global::FTS.MainUI.Properties.Resources.index;
                int i = 0;
                foreach (DataRowView drv in sysmenuview) {
                    if (drv["MENU_TYPE"].ToString() == "LIST") {
                        DevExpress.XtraBars.BarButtonItem btn = new BarButtonItem();
                        btn.Caption = this.mFTSMain.TableManager.GetDisplayName(drv["MENU_TAG"].ToString());
                        if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                            btn.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, btn.Font.Size);
                        }
                        if (Functions.FileExists(this.mFTSMain.PathName + "Graphics\\" + drv["MENU_ICON"].ToString())) {
                            btn.Glyph =
                                Image.FromFile(this.mFTSMain.PathName + "Graphics\\" + drv["MENU_ICON"].ToString());
                        } else {
                            if (i == 0) {
                                btn.Glyph = global::FTS.MainUI.Properties.Resources.row;
                                i = 1;
                            } else {
                                btn.Glyph = global::FTS.MainUI.Properties.Resources.table;
                                i = 0;
                            }
                        }
                        btn.Name = "MNU_" + drv["MENU_ID"];
                        btn.Tag = drv["MENU_TAG"].ToString();
                        btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CommandButton_Click);
                        this.ribbonControl.Items.Add(btn);
                        listitem.AddItem(btn);
                    }
                }
            }
            DataTable transaction =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand("SELECT * FROM SYS_TRAN WHERE MODULE_ID='" + item.Id +
                                                             "' and ACTIVE=1 AND SHOW_IN_MENU=1 ORDER BY LIST_ORDER"),
                    "SYS_TRAN");
            if (transaction.Rows.Count > 0) {
                DevExpress.XtraBars.Ribbon.RibbonPageGroup groupTransaction =
                    new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                page.Groups.Add(groupTransaction);
                groupTransaction.Name = "groupTransaction";
                groupTransaction.ShowCaptionButton = false;
                groupTransaction.Text = string.Empty;
                foreach (DataRow row in transaction.Rows) {
                    DevExpress.XtraBars.BarButtonItem btn = new BarButtonItem();
                    if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                        btn.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, btn.Font.Size);
                    }
                    btn.Caption = this.mFTSMain.ResourceManager.GetValue("TRANNAME_" + row["tran_id"].ToString(),
                                                                         row["tran_id"].ToString());
                    btn.LargeGlyph = global::FTS.MainUI.Properties.Resources.transaction;
                    btn.Name = "MNU_TRAN_" + row["TRAN_ID"].ToString();
                    btn.Tag = row["TRAN_ID"].ToString();
                    btn.LargeWidth = 70;
                    btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.TransactionButton_Click);
                    groupTransaction.ItemLinks.Add(btn);
                }
            }
            DataTable function =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand(
                        "SELECT DISTINCT MENU_GROUP FROM SYS_MENU WHERE MODULE_ID='" + item.Id +
                        "' and MENU_TYPE='FUNC' AND ACTIVE=1 ORDER BY MENU_GROUP"), "SYS_MENU");
            foreach (DataRow row in function.Rows) {
                DevExpress.XtraBars.Ribbon.RibbonPageGroup groupFunction =
                    new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                page.Groups.Add(groupFunction);
                groupFunction.Name = "groupFunction" + row["MENU_GROUP"];
                groupFunction.ShowCaptionButton = false;
                if (row["MENU_GROUP"].ToString().Trim() != string.Empty) {
                    groupFunction.Text = this.mFTSMain.MsgManager.GetMessage("MNU_groupFunction_" + row["MENU_GROUP"]);
                }
                foreach (DataRowView drv in sysmenuview) {
                    if (drv["MENU_TYPE"].ToString() == "FUNC" &&
                        drv["MENU_GROUP"].ToString() == row["MENU_GROUP"].ToString()) {
                        DevExpress.XtraBars.BarButtonItem btn = new BarButtonItem();
                        if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                            btn.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, btn.Font.Size);
                        }
                        btn.Caption = this.mFTSMain.MsgManager.GetMessage("MNU_" + drv["MENU_ID"]);
                        if (
                            Functions.FileExists(this.mFTSMain.PathName + "Graphics\\" +
                                                 drv["MENU_ICON"].ToString().Trim())) {
                            btn.LargeGlyph =
                                Image.FromFile(this.mFTSMain.PathName + "Graphics\\" +
                                               drv["MENU_ICON"].ToString().Trim());
                        } else {
                            btn.LargeGlyph = global::FTS.MainUI.Properties.Resources.function;
                        }
                        btn.Name = "MNU_" + drv["MENU_ID"];
                        btn.Tag = drv["MENU_TAG"].ToString();
                        if ((int) drv["MENU_WIDTH"] == 0) {
                            btn.LargeWidth = 70;
                        } else {
                            btn.LargeWidth = (int) drv["MENU_WIDTH"];
                        }
                        btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CommandButton_Click);
                        groupFunction.ItemLinks.Add(btn);
                    }
                }
            }
            DataTable reportgroup =
                this.mFTSMain.DbMain.LoadDataTable(
                    this.mFTSMain.DbMain.GetSqlStringCommand(
                        "SELECT * from SYS_REPORT_GROUP WHERE SYS_REPORT_GROUP.ACTIVE=1 AND SYS_REPORT_GROUP.MODULE_ID='" +
                        item.Id + "' ORDER BY REPORT_GROUP_ID"), "SYS_REPORT_GROUP");
            foreach (DataRow grouprow in reportgroup.Rows) {
                DataTable report =
                    this.mFTSMain.DbMain.LoadDataTable(
                        this.mFTSMain.DbMain.GetSqlStringCommand(
                            "SELECT SYS_REPORT.REPORT_ID,SYS_REPORT.PARENT_ID,SYS_REPORT_GROUP.PROJECT_ID FROM SYS_REPORT, SYS_REPORT_GROUP WHERE SYS_REPORT.REPORT_GROUP_ID=SYS_REPORT_GROUP.REPORT_GROUP_ID AND SYS_REPORT_GROUP.ACTIVE=1 AND SYS_REPORT_GROUP.REPORT_GROUP_ID='" + grouprow["REPORT_GROUP_ID"] + "' AND SYS_REPORT_GROUP.MODULE_ID='" +
                            item.Id + "' and SYS_REPORT.ACTIVE=1 ORDER BY LIST_ORDER"), "SYS_REPORT");
                if (report.Rows.Count > 0) {
                    DevExpress.XtraBars.Ribbon.RibbonPageGroup groupReport =
                        new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                    page.Groups.Add(groupReport);
                    groupReport.Name = "groupReport" + grouprow["REPORT_GROUP_ID"];
                    groupReport.ShowCaptionButton = false;
                    groupReport.Text = string.Empty;
                    BarSubItem listreportitem = new BarSubItem();
                    listreportitem.Caption = this.mFTSMain.ResourceManager.GetReportGroupShortName(grouprow["REPORT_GROUP_ID"].ToString());
                    listreportitem.Name = "MNU_REPORT_" + item.Id + "_" + grouprow["REPORT_GROUP_ID"];
                    listreportitem.LargeWidth = 80;
                    groupReport.ItemLinks.Add(listreportitem);
                    listreportitem.LargeGlyph = global::FTS.MainUI.Properties.Resources.report;
                    foreach (DataRow row in report.Rows) {
                        DevExpress.XtraBars.BarButtonItem btn = new BarButtonItem();
                        if (this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.LAOS || this.mFTSMain.Language == FTS.BaseBusiness.Systems.Language.JP) {
                            btn.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, btn.Font.Size);
                        }
                        btn.Caption = this.mFTSMain.ResourceManager.GetReportName(row["REPORT_ID"].ToString());
                        btn.Name = "MNU_REPORT_" + row["REPORT_ID"].ToString();
                        btn.Tag = row["REPORT_ID"].ToString();
                        btn.Glyph = global::FTS.MainUI.Properties.Resources.report_list;
                        btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ReportButton_Click);
                        this.ribbonControl.Items.Add(btn);
                        listreportitem.AddItem(btn);
                    }
                }
            }
        }

        private void tabstrip_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e) {
            if (e.NewTab != null) {
                Control attachedcontrol = e.NewTab.AttachedControl;
                if (this.mFTSMain.ProjectID[0] == ProjectList.Hotel) {
                    if (File.Exists(this.mFTSMain.PathName + "FTS.HotelUI.dll")) {
                        Type type =
                            Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HotelUI.dll").GetType(
                                "FTS.HotelUI.Hotel.FrmMainMap");
                        if (attachedcontrol.GetType().Equals(type)) {
                            this.tabstrip.CloseButtonVisible = false;
                        } else {
                            this.tabstrip.CloseButtonVisible = true;
                        }
                    }
                }
            }
        }

        public override void ShowTransaction(string tranid, object key) {
            DataTable sys_tran = this.mFTSMain.TableManager.LoadTable("SYS_TRAN", "TRAN_ID,TRAN_CLASS", "1=1");
            DataRow foundrow = sys_tran.Rows.Find(tranid);
            if (foundrow != null) {
                switch (foundrow["TRAN_CLASS"].ToString()) {
                    case "SALE":
                        if (File.Exists(this.mFTSMain.PathName + "FTS.AccUI.dll")) {
                            Type type =
                                Assembly.LoadFile(this.mFTSMain.PathName + "FTS.AccUI.dll").GetType(
                                    "FTS.AccUI.Sale.FrmSale");
                            Type[] typeArray = new Type[3] {typeof (FTSMain), typeof (string), typeof (object)};
                            ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                            if (constructorInfoObj != null) {
                                Object[] objArg = new object[3] {this.mFTSMain, tranid, key};
                                FrmBase2 frmbase2 = ((FrmBase2) constructorInfoObj.Invoke(objArg));
                                frmbase2.Show();
                                frmbase2.UpdateInfo();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}