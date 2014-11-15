#region

using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms{
    public partial class FTSMainForm : RibbonForm //DevComponents.DotNetBar.Office2007RibbonForm
    {
        private DataTable mDmFormInfo;
        public static FTSMainForm ApplicationMainWindow { get; private set; }

        public FTSMainForm(){
            ApplicationMainWindow = this;
            InitializeComponent();
        }

        public virtual void SetSaveReportButton(bool enabled) {}

        public virtual void SetPartReportButton(int numpartreport) {}

        public virtual void LoadReport(string reportid, string parentreportid) {}

        public virtual void LoadLayout(FTSMain ftsmain){
            this.Name = this.Name.ToUpper();
            this.mDmFormInfo = new DataTable();
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN){
                DbCommand cmd =
                    ftsmain.DbMain.GetSqlStringCommand("select * from sys_forminfo where form_name='" +
                                                       this.Name + "'");
                this.mDmFormInfo = ftsmain.DbMain.LoadDataTable(cmd, "sys_forminfo");
            } else{
                DbCommand cmd =
                    ftsmain.SysCacheVista.GetSqlStringCommand("select * from sys_forminfo where form_name='" +
                                                       this.Name + "'");
                this.mDmFormInfo = ftsmain.SysCacheVista.LoadDataTable(cmd, "sys_forminfo");
            }
            this.mDmFormInfo.PrimaryKey =
                new DataColumn[]
                    {
                        this.mDmFormInfo.Columns["FORM_NAME"], this.mDmFormInfo.Columns["OBJECT_NAME"],
                        this.mDmFormInfo.Columns["PROPERTY_NAME"]
                    };
            this.SetProperty(ftsmain, this);
            string sql = "INSERT INTO SYS_FORM VALUES('" + this.Name + "','" + this.Name + "','" +
                         this.Name + "',1,1,'ADMIN')";
            try{
                ftsmain.DbMain.ExecuteNonQuery(ftsmain.DbMain.GetSqlStringCommand(sql));
            } catch (Exception){}
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN){
                if (this.mDmFormInfo.GetChanges() != null){
                    ftsmain.DbMain.UpdateTable(this.mDmFormInfo,
                                               ftsmain.DbMain.CreateInsertCommand("sys_forminfo", this.mDmFormInfo),
                                               ftsmain.DbMain.CreateUpdateCommand("sys_forminfo", this.mDmFormInfo,
                                                                                  "PR_KEY"),
                                               null, UpdateBehavior.Standard);
                }
                Functions.ClearTable(this.mDmFormInfo);
            }
        }

        public void UpdateProperty(FTSMain ftsmain, string objectname, string propertyname, string propertytype,
                                   string propertyvalue){
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN){
                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, objectname, propertyname});
                if (foundrow != null){
                    foundrow["property_value"] = propertyvalue;
                } else{
                    foundrow = this.mDmFormInfo.NewRow();
                    foundrow["PR_KEY"] = FunctionsBase.GetPr_key("sys_forminfo", ftsmain);
                    foundrow["form_name"] = this.Name.ToUpper();
                    foundrow["object_name"] = objectname;
                    foundrow["property_name"] = propertyname;
                    foundrow["property_value"] = propertyvalue;
                    foundrow["property_type"] = propertytype;
                    this.mDmFormInfo.Rows.Add(foundrow);
                }
            }
        }

        private void SetProperty(FTSMain ftsmain, Control control){
            string ctrlname = control.Name.ToUpper();
            if (control is Form){
                control.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + control.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);
                foreach (Control ctrl in control.Controls){
                    this.SetProperty(ftsmain, ctrl);
                }
            } else if (control is FTSGroupBox || control is FTSShadowPanel /*||(control is RibbonPanel)*/){
                control.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
                if (foundrow != null){
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
                if (foundrow != null){
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foreach (Control ctrl in control.Controls){
                    this.SetProperty(ftsmain, ctrl);
                }
            } else if ((control is RibbonControl)){
                RibbonControl ribboncontrol = control as RibbonControl;
                control.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
                if (foundrow != null){
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
                if (foundrow != null){
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }               
                //foreach (Object ctrl in ribboncontrol.Items){
                //    RibbonTabItem buttonitem = ctrl as RibbonTabItem;
                //    if (buttonitem != null){
                //        this.SetProperty(ftsmain, buttonitem);
                //    }
                //}               
                foreach (Control ctrl in ribboncontrol.Controls){
                    this.SetProperty(ftsmain, ctrl);
                }
            } else if ((control is DevExpress.XtraBars.Ribbon.RibbonControl)) {
                DevExpress.XtraBars.Ribbon.RibbonControl ribboncontrol = control as DevExpress.XtraBars.Ribbon.RibbonControl;
                control.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "ENABLED" });
                if (foundrow != null) {
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "VISIBLE" });
                if (foundrow != null) {
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foreach (DevExpress.XtraBars.BarItem ctrl in ribboncontrol.Items ) {
                    DevExpress.XtraBars.BarButtonItem buttonitem = ctrl as DevExpress.XtraBars.BarButtonItem;
                    if (buttonitem != null) {
                        this.SetProperty(ftsmain, buttonitem);
                    }
                    DevExpress.XtraBars.BarSubItem subbuttonitem = ctrl as DevExpress.XtraBars.BarSubItem;
                    if (subbuttonitem != null) {
                        this.SetProperty(ftsmain, subbuttonitem);
                    }
                }
                foreach (RibbonPage ctrl in ribboncontrol.Pages) {
                    this.SetProperty(ftsmain, ctrl);
                    foreach (RibbonPageGroup ctrl1 in ctrl.Groups) {
                        this.SetProperty(ftsmain, ctrl1);
                    }
                }                   
            //} else if (control is RibbonBar) {
            //    RibbonBar ribbonbar = control as RibbonBar;
            //    control.Text =
            //        ftsmain.ResourceManager.GetValue(
            //            "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

            //    DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
            //    if (foundrow != null){
            //        control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
            //    }
            //    foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
            //    if (foundrow != null){
            //        control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
            //    }
            //    foreach (Object ctrl in ribbonbar.Items){
            //        ButtonItem buttonitem = ctrl as ButtonItem;
            //        if (buttonitem != null){
            //            this.SetProperty(ftsmain, buttonitem);
            //        }
            //    }                
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSSingleComboCom) ||
                       (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                       (control is FTSNameIDCom) || (control is FTSComboCom) || (control is FTSTranNumCom) ||
                       (control is FTSCalculatorCom) || (control is FTSVatCom) || (control is FTSButton) ||
                       (control is FTSPercentCom) || (control is FTSFreeComboCom) || (control is FTSRadioButton)){
                control.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

                IHelpField c = control as IHelpField;
                if (c != null){
                    c.HelpText =
                        ftsmain.ResourceManager.GetValue(
                            "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TOOLTIP", c.HelpText);
                }
                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
                if (foundrow != null){
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
                if (foundrow != null){
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "REQUIRE"});
                if (foundrow != null){
                    ((IRequire) control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
            }
        }       
        //private void SetProperty(FTSMain ftsmain, ButtonItem control){
        //    string ctrlname = control.Name;
        //    if (ctrlname != string.Empty){
        //        control.Text =
        //            ftsmain.ResourceManager.GetValue(
        //                "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Text);

        //        control.Tooltip =
        //            ftsmain.ResourceManager.GetValue(
        //                "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TOOLTIP", control.Tooltip);

        //        DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
        //        if (foundrow != null){
        //            control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
        //        }
        //        foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
        //        if (foundrow != null){
        //            control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
        //        }
        //        foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "REQUIRE"});
        //        if (foundrow != null){
        //            ((IRequire) control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
        //        }
        //        foreach (Object ctrl in control.SubItems){
        //            ButtonItem buttonitem = ctrl as ButtonItem;
        //            if (buttonitem != null){
        //                this.SetProperty(ftsmain, buttonitem);
        //            }
        //        }
        //    }
        //}       
        private void SetProperty(FTSMain ftsmain, DevExpress.XtraBars.BarButtonItem control) {
            string ctrlname = control.Name;
            if (ctrlname != string.Empty) {
                control.Caption =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Caption);
                /*
                control.P =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TOOLTIP", control.Tooltip);
                */
                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "ENABLED" });
                if (foundrow != null) {
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "VISIBLE" });
                if (foundrow != null) {
                    control.Visibility = (foundrow["property_value"].ToString() == "1") ? BarItemVisibility.Always : BarItemVisibility.Never;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "REQUIRE" });
                if (foundrow != null) {
                    ((IRequire)control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                /*
                foreach (Object ctrl in control.SubItems)
                {
                    ButtonItem buttonitem = ctrl as ButtonItem;
                    if (buttonitem != null)
                    {
                        this.SetProperty(ftsmain, buttonitem);
                    }
                }
                */ 
            }
        }

        private void SetProperty(FTSMain ftsmain, DevExpress.XtraBars.BarSubItem control) {
            string ctrlname = control.Name;
            if (ctrlname != string.Empty) {
                control.Caption =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT", control.Caption);
                /*
                control.P =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TOOLTIP", control.Tooltip);
                */
                DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "ENABLED" });
                if (foundrow != null) {
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "VISIBLE" });
                if (foundrow != null) {
                    control.Visibility = (foundrow["property_value"].ToString() == "1") ? BarItemVisibility.Always : BarItemVisibility.Never;
                }
                foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "REQUIRE" });
                if (foundrow != null) {
                    ((IRequire)control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
                } 
                /*
                foreach (Object ctrl in control.SubItems)
                {
                    ButtonItem buttonitem = ctrl as ButtonItem;
                    if (buttonitem != null)
                    {
                        this.SetProperty(ftsmain, buttonitem);
                    }
                } 
                */ 
            }
        }        
        //private void SetProperty(FTSMain ftsmain, RibbonTabItem control){
        //    string ctrlname = control.Name;
        //    control.Text =
        //        ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT",
        //                                         control.Text);

        //    IHelpField c = control as IHelpField;
        //    if (c != null){
        //        control.Tooltip =
        //            ftsmain.ResourceManager.GetValue(
        //                "FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TOOLTIP", control.Tooltip);
        //    }

        //    DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
        //    if (foundrow != null){
        //        control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
        //    }
        //    foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
        //    if (foundrow != null){
        //        control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
        //    }
        //    foundrow = this.mDmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "REQUIRE"});
        //    if (foundrow != null){
        //        ((IRequire) control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
        //    }
        //}       
        private void SetProperty(FTSMain ftsmain, RibbonPage control) {
            string ctrlname = control.Name;
            control.Text =
                ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT",
                                                 control.Text);
            DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "VISIBLE" });
            if (foundrow != null) {
                control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
            }
        }

        private void SetProperty(FTSMain ftsmain, RibbonPageGroup control) {
            string ctrlname = control.Name;
            control.Text =
                ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + control.Name.ToUpper() + "_TEXT",
                                                 control.Text);
            DataRow foundrow = this.mDmFormInfo.Rows.Find(new object[] { this.Name, ctrlname, "VISIBLE" });
            if (foundrow != null) {
                control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
            }
        }

        public virtual void ShowTransaction(string tranid, object prkey) {}

        public virtual void LoadReportButton() {}
    }
}