#region

using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraTab;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSUserControl : UserControl {
        protected CustomizationForm customizationForm;
        private DataTable DmFormInfo;
        private int mTabIndex;
        private FTSMain mFTSMain;

        public FTSUserControl() {
            this.InitializeComponent();
        }

        public FTSUserControl(FTSMain ftsmain) {
            this.FTSMain = ftsmain;
            this.InitializeComponent();
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        private void SetProperty(FTSMain ftsmain, Control control) {
            string ctrlname = control.Name.ToUpper();
            if (control is Form) {
                this.Text =
                    ftsmain.ResourceManager.GetValue(
                        "FRM_" + this.Name.ToUpper() + "_" + this.Name.ToUpper() + "_TEXT", this.Text);
                DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "HEIGHT"});
                if (foundrow != null) {
                    this.Height = Convert.ToInt32(foundrow["property_value"]);
                }
                foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "WIDTH"});
                if (foundrow != null) {
                    this.Width = Convert.ToInt32(foundrow["property_value"]);
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetProperty(ftsmain, ctrl);
                }
            } else if (control is FTSGroupBox || control is FTSShadowPanel || control is FTSCollapsablePanel ||
                       control is UserControl || control is WizardPage || control is XtraTabPage ||
                       control is XtraTabControl) {
                control.Text =
                    ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + ctrlname + "_TEXT",
                                                     control.Text);
                DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
                if (foundrow != null) {
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
                if (foundrow != null) {
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.SetProperty(ftsmain, ctrl);
                    }
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetProperty(ftsmain, ctrl);
                }
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSSingleComboCom) ||
                       (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                       (control is FTSNumericCom2) || (control is FTSMemoCom) || (control is FTSPictureCom) ||
                       (control is FTSMemoCom) || (control is FTSNameIDCom) || (control is FTSComboCom) ||
                       (control is FTSTranNumCom) || (control is FTSCalculatorCom) || (control is FTSVatCom) ||
                       (control is FTSButton) || (control is FTSUpDownCom) || (control is FTSPercentCom) ||
                       (control is FTSFreeComboCom) || (control is FTSRadioButton) || (control is FTSLabel)) {
                control.Text =
                    ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + ctrlname + "_TEXT",
                                                     control.Text);
                IHelpField c = control as IHelpField;
                if (c != null) {
                    c.HelpText =
                        ftsmain.ResourceManager.GetValue(
                            "FRM_" + this.Name.ToUpper() + "_" + ctrlname + "_TOOLTIP", c.HelpText);
                }
                DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "ENABLED"});
                if (foundrow != null) {
                    control.Enabled = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "VISIBLE"});
                if (foundrow != null) {
                    control.Visible = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
                foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, ctrlname, "REQUIRE"});
                if (foundrow != null) {
                    ((IRequire) control).Require = (foundrow["property_value"].ToString() == "1") ? true : false;
                }
            }
        }

        public virtual void SaveLayout(FTSMain ftsmain) {
            ftsmain.FormManager.SaveFormName(this.Name);
            DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, this.Name, "WIDTH"});
            if (foundrow == null) {
                ftsmain.FormManager.UpdateFormWidth(this.Name, this.Width);
            } else if (Convert.ToInt32(foundrow["PROPERTY_VALUE"]) != this.Width) {
                ftsmain.FormManager.UpdateFormWidth(this.Name, this.Width);
            }
            foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, this.Name, "HEIGHT"});
            if (foundrow == null) {
                ftsmain.FormManager.UpdateFormHeight(this.Name, this.Height);
            } else if (Convert.ToInt32(foundrow["PROPERTY_VALUE"]) != this.Height) {
                ftsmain.FormManager.UpdateFormHeight(this.Name, this.Height);
            }
        }

        protected void FormCustomization(Point showpoint, FTSMain ftsmain) {
            this.DestroyCustomization();
            this.customizationForm = this.CreateCustomizationForm(ftsmain);
            //this.AddOwnedForm(this.customizationForm);
            this.customizationForm.ShowCustomization(showpoint);
        }

        protected virtual CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, null, ftsmain);
        }

        protected void DestroyCustomization() {
            if (this.customizationForm != null) {
                this.customizationForm.Dispose();
                this.customizationForm = null;
            }
        }

        protected virtual void SetTabIndex(Control control) {
            if (control is Form) {
                foreach (Control ctrl in control.Controls) {
                    this.SetTabIndex(ctrl);
                }
            } else if (control is FTSGroupBox || control is FTSShadowPanel || control is FTSCollapsablePanel ||
                       control is UserControl || control is WizardPage || control is XtraTabPage ||
                       control is XtraTabControl) {
                control.TabIndex = this.mTabIndex;
                this.mTabIndex++;
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.SetTabIndex(ctrl);
                    }
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetTabIndex(ctrl);
                }
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSSingleComboCom) ||
                       (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                       (control is FTSNumericCom2) || (control is FTSMemoCom) || (control is FTSPictureCom) ||
                       (control is FTSNameIDCom) || (control is FTSVatCom) || (control is FTSComboCom) ||
                       (control is FTSButton) || (control is FTSUpDownCom) || (control is FTSLabel) ||
                       (control is FTSMRUEditCom) || (control is FTSCalculatorCom) || (control is FTSButton) ||
                       (control is FTSPercentCom) || (control is FTSFreeComboCom) || (control is FTSRadioButton)) {
                control.TabIndex = this.mTabIndex;
                this.mTabIndex++;
            }
        }

        public virtual void LoadLayout(FTSMain ftsmain) {
            this.Name = this.Name.ToUpper();
            this.DmFormInfo = new DataTable();
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN) {
                DbCommand cmd =
                    ftsmain.DbMain.GetSqlStringCommand("select * from sys_forminfo where form_name='" + this.Name + "'");
                this.DmFormInfo = ftsmain.DbMain.LoadDataTable(cmd, "sys_forminfo");
            } else {
                DbCommand cmd =
                    ftsmain.SysCacheVista.GetSqlStringCommand("select * from sys_forminfo where form_name='" + this.Name + "'");
                this.DmFormInfo = ftsmain.SysCacheVista.LoadDataTable(cmd, "sys_forminfo");
            }
            this.DmFormInfo.PrimaryKey = new DataColumn[] {
                                                              this.DmFormInfo.Columns["FORM_NAME"], this.DmFormInfo.Columns["OBJECT_NAME"],
                                                              this.DmFormInfo.Columns["PROPERTY_NAME"]
                                                          };
            this.SetProperty(ftsmain, this);
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN) {
                string sql = "INSERT INTO SYS_FORM VALUES('" + this.Name + "','" + this.Name + "','" + this.Name +
                             "',1,1,'ADMIN')";
                try {
                    ftsmain.DbMain.ExecuteNonQuery(ftsmain.DbMain.GetSqlStringCommand(sql));
                } catch (Exception) {
                }
                if (this.DmFormInfo.GetChanges() != null) {
                    ftsmain.DbMain.UpdateTable(this.DmFormInfo,
                                               ftsmain.DbMain.CreateInsertCommand("sys_forminfo", this.DmFormInfo),
                                               ftsmain.DbMain.CreateUpdateCommand("sys_forminfo", this.DmFormInfo,
                                                                                  "PR_KEY"), null,
                                               UpdateBehavior.Standard);
                }
            }
            this.mTabIndex = 0;
            this.SetTabIndex(this);
            if (ftsmain.Language == Language.JP || ftsmain.Language == Language.LAOS) {
                this.SetFont(this);
            }
        }

        protected virtual void SetFont(Control control) {
            if (control is Form) {
                foreach (Control ctrl in control.Controls) {
                    this.SetFont(ctrl);
                }
            } else if (control is FTSGroupBox || control is FTSShadowPanel || control is FTSCollapsablePanel ||
                       control is UserControl || control is WizardPage || control is XtraTabPage ||
                       control is XtraTabControl) {
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.SetFont(ctrl);
                    }
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetFont(ctrl);
                }
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSSingleComboCom) ||
                       (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                       (control is FTSNumericCom2) || (control is FTSMemoCom) || (control is FTSPictureCom) ||
                       (control is FTSNameIDCom) || (control is FTSVatCom) || (control is FTSComboCom) ||
                       (control is FTSButton) || (control is FTSUpDownCom) || (control is FTSLabel) ||
                       (control is FTSMRUEditCom) || (control is FTSCalculatorCom) || (control is FTSButton) ||
                       (control is FTSPercentCom) || (control is FTSFreeComboCom) || (control is FTSRadioButton)) {
            }
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            string key = keyData.ToString().Trim();
            switch (key) {
                case "F11":
                    this.FormCustomization(new Point(-10000, -10000), this.FTSMain);
                    return true;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnControlRemoved(ControlEventArgs e) {
            this.SaveLayout(this.FTSMain);
            this.DestroyCustomization();
            base.OnControlRemoved(e);
        }

        public void UpdateProperty(FTSMain ftsmain, string objectname, string propertyname, string propertytype,
                                   string propertyvalue) {
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN && ftsmain.UserInfo.UserGroupID == "ADMIN") {
                DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, objectname, propertyname});
                if (foundrow != null) {
                    foundrow["property_value"] = propertyvalue;
                } else {
                    foundrow = this.DmFormInfo.NewRow();
                    foundrow["PR_KEY"] = FunctionsBase.GetPr_key("sys_forminfo", ftsmain);
                    foundrow["form_name"] = this.Name.ToUpper();
                    foundrow["object_name"] = objectname;
                    foundrow["property_name"] = propertyname;
                    foundrow["property_value"] = propertyvalue;
                    foundrow["property_type"] = propertytype;
                    this.DmFormInfo.Rows.Add(foundrow);
                }
            }
        }
    }
}