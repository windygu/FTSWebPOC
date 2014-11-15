#region

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSForm : Form {
//DevComponents.DotNetBar.Office2007Form {
        public bool AllowNew = true;
        public bool AllowNavigate = true;
        public bool AllowDelete = true;
        public bool AllowSave = true;
        public bool AllowUndo = true;
        public bool AllowRefresh = true;
        public bool AllowPrint = true;
        public bool AllowFind = true;
        public bool AllowClose = true;
        public bool AllowHelp = true;
        public bool AllowFilter = true;
        public bool AllowEdit = true;
        public bool AllowCopy = true;
        public bool AllowExcel = true;
        protected CustomizationForm customizationForm;
        private DataTable mDmFormInfo;
        private int mTabIndex;
        private bool mOnClose = false;
        public Control PreviousControl = null;

        public FTSForm() {
            this.InitializeComponent();
        }

        public int StartTabIndex {
            get { return this.mTabIndex; }
            set { this.mTabIndex = value; }
        }

        public DataTable DmFormInfo {
            get { return this.mDmFormInfo; }
            set { this.mDmFormInfo = value; }
        }

        protected void CenterToMainForm(XtraForm mainForm) {
            this.Location = new Point(((mainForm.Width - this.Width)/2) + mainForm.Location.X,
                                      ((mainForm.Height - this.Height)/2) + mainForm.Location.Y);
        }

        public virtual void SetMessage(string msg) {
        }

        public void SetHelp(string ma_menu, Database db,string pathname) {
            HelpProvider hp;
            string topic = string.Empty;
            DataTable dt_help =
                db.LoadDataTable(
                    db.GetSqlStringCommand("select TOPIC from dm_help where ma_menu= '" + ma_menu.Trim() + "' "),
                    "dm_help");
            if (dt_help.Rows.Count > 0) {
                topic = dt_help.Rows[0]["TOPIC"].ToString();
                dt_help.Clear();
            }
            hp = new HelpProvider();
            hp.HelpNamespace = pathname + "Help_FTS.chm";
            this.HelpButton = true;
            hp.SetHelpNavigator(this, HelpNavigator.Topic);
            hp.SetHelpKeyword(this, topic);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (this.ControlBox == false) {
                this.WindowState = FormWindowState.Normal;
                this.Refresh();
            }            
        }
       
        protected virtual void ShowHelp() {
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            string key = keyData.ToString().Trim();
            switch (key) {
                case "F4, Control":
                    this.Close();
                    return true;
                case "F1":
                    this.ShowHelp();
                    return true;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        public virtual void SumData() {
        }

        public virtual Type GetFrmDicList(string tablename) {
            return null;
        }

        public virtual Type GetFrmDicEditList(string tablename) {
            return null;
        }

        public virtual Type GetFrmDicEditDetail(string tablename) {
            return null;
        }

        protected void FormCustomization(Point showpoint, FTSMain ftsmain) {
            this.DestroyCustomization();
            this.customizationForm = this.CreateCustomizationForm(ftsmain);
            this.AddOwnedForm(this.customizationForm);
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
            } else if (control is FTSGroupBox || control is FTSStatus || control is FTSShadowPanel || control is FTSShadowPanel2 || control is FTSCollapsablePanel ||
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
                       (control is FTSReadOnlyNumericCom) || (control is FTSNameIDCom) ||
                       (control is FTSHourMinuteCom) || (control is FTSColorCom) ||
                       (control is FTSButton) || (control is FTSUpDownCom) || (control is FTSMRUEditCom) ||
                       (control is FTSLabel) || (control is FTSCalculatorCom) || (control is FTSVatCom) || 
                       (control is FTSPercentCom) || (control is FTSFreeComboCom) || (control is FTSRadioButton))
            {
                control.TabIndex = this.mTabIndex;
                this.mTabIndex++;
            }
        }
       
        private FTSShadowPanel GetFTSShadowPanel(Control control)
        {
            if (control is FTSShadowPanel){
                return (FTSShadowPanel)control;
            }
            else{
                foreach (Control ctrl in control.Controls){
                    return this.GetFTSShadowPanel(ctrl);
                }
                return null;
            }
        }

        protected virtual void SetFont(Control control) {
            if (control is Form) {
                foreach (Control ctrl in control.Controls) {
                    this.SetFont(ctrl);
                }
            } else if (control is FTSGroupBox || control is FTSStatus || control is FTSShadowPanel || control is FTSShadowPanel2 || control is FTSCollapsablePanel ||
                       control is UserControl || control is WizardPage || control is XtraTabPage ||
                       control is XtraTabControl) {
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.SetFont(ctrl);
                        (ctrl).Font = new Font(FTSConstant.JAPANESE_FONT, 8);
                    }
                }
                if (control is FTSGroupBox) {
                    ((FTSGroupBox) control).SetFont();
                }
                if (control is XtraTabControl) {
                    (control).Font = new Font(FTSConstant.JAPANESE_FONT, 8);
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetFont(ctrl);
                }
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSSingleComboCom) ||
                       (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                       (control is FTSNumericCom2) || (control is FTSMemoCom) || (control is FTSPictureCom) ||
                       (control is FTSReadOnlyNumericCom) || (control is FTSNameIDCom) || (control is FTSColorCom) ||
                       (control is FTSHourMinuteCom) ||  (control is FTSButton) ||
                       (control is FTSUpDownCom) || (control is FTSLabel) || (control is FTSMRUEditCom) ||
                       (control is FTSCalculatorCom) || (control is FTSVatCom) || 
                       (control is FTSPercentCom) || (control is FTSFreeComboCom) || (control is FTSRadioButton)) {
                if (control is FTSUpDownCom) {
                    ((FTSUpDownCom) control).SetFont();
                }
                if (control is FTSLabel) {
                    ((FTSLabel) control).SetFont();
                }
                if (control is FTSFreeComboCom) {
                    ((FTSFreeComboCom) control).SetFont();
                }
                if (control is FTSRadioButton) {
                    ((FTSRadioButton) control).SetFont();
                }
                if (control is FTSPercentCom) {
                    ((FTSPercentCom) control).SetFont();
                }
                if (control is FTSCheckCom) {
                    ((FTSCheckCom) control).SetFont();
                }
                if (control is FTSComboCom) {
                    ((FTSComboCom) control).SetFont();
                }
                if (control is FTSSingleComboCom) {
                    ((FTSSingleComboCom) control).SetFont();
                }
                if (control is FTSDateCom) {
                    ((FTSDateCom) control).SetFont();
                }
                if (control is FTSTextCom) {
                    ((FTSTextCom) control).SetFont();
                }
                if (control is FTSColorCom) {
                    ((FTSColorCom)control).SetFont();
                }
                if (control is FTSNumericCom) {
                    ((FTSNumericCom) control).SetFont();
                }
                if (control is FTSMemoCom) {
                    ((FTSMemoCom) control).SetFont();
                }
                if (control is FTSPictureCom) {
                    ((FTSPictureCom) control).SetFont();
                }
                if (control is FTSReadOnlyNumericCom) {
                    ((FTSReadOnlyNumericCom) control).SetFont();
                }
                if (control is FTSNumericCom2) {
                    ((FTSNumericCom2) control).SetFont();
                }
                if (control is FTSNameIDCom) {
                    ((FTSNameIDCom) control).SetFont();
                }
                if (control is FTSVatCom) {
                    ((FTSVatCom) control).SetFont();
                }
                if (control is FTSHourMinuteCom) {
                    ((FTSHourMinuteCom) control).SetFont();
                }
                if (control is FTSComboCom) {
                    ((FTSComboCom) control).SetFont();
                }
                if (control is FTSButton) {
                    ((FTSButton) control).SetFont();
                }
                if (control is FTSMRUEditCom) {
                    ((FTSMRUEditCom)control).SetFont();
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            FTSShadowPanel panel = this.GetFTSShadowPanel(this);
            if (panel != null)
                this.BackColor = panel.SkinBackColor;
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

        public virtual void CheckFormRequire(Control control) {
            if ((control is FTSComboCom) || (control is FTSSingleComboCom) || (control is FTSRadioButton) ||
                (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                (control is FTSReadOnlyNumericCom) || (control is FTSNumericCom2) || (control is FTSButton) ||
                (control is FTSLabel) || (control is FTSNameIDCom) || (control is FTSVatCom) || (control is FTSColorCom) ||
                (control is FTSTranNumCom) || (control is FTSMemoCom) || (control is FTSPictureCom) ||
                (control is FTSMRUEditCom) || (control is FTSCalculatorCom) || (control is FTSPercentCom) ||
                (control is FTSFreeComboCom) || (control is FTSHourMinuteCom)) {
                bool require = false;
                bool valid = true;
                IRequire ir = control as IRequire;
                if (ir != null) {
                    require = ir.Require;
                }
                IValid iv = control as IValid;
                if (iv != null) {
                    valid = iv.IsValid();
                }
                if ((require) && (!valid)) {
                    if (control is FTSComboCom) {
                        Control ctrl = ((FTSComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    }
                    if (control is FTSFreeComboCom) {
                        Control ctrl = ((FTSFreeComboCom) control).FreeComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSComboCom) {
                        Control ctrl = ((FTSComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSSingleComboCom) {
                        Control ctrl = ((FTSSingleComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSDateCom) {
                        Control ctrl = ((FTSDateCom) control).DateTime;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSTextCom) {
                        Control ctrl = ((FTSTextCom) control).Textbox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSTranNumCom) {
                        Control ctrl = ((FTSTranNumCom) control).Textbox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSNumericCom) {
                        Control ctrl = ((FTSNumericCom) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSMemoCom) {
                        Control ctrl = ((FTSMemoCom) control).Memo;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSPictureCom) {
                        Control ctrl = ((FTSPictureCom) control).Picture;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSReadOnlyNumericCom) {
                        Control ctrl = ((FTSReadOnlyNumericCom) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSNumericCom2) {
                        Control ctrl = ((FTSNumericCom2) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSPercentCom) {
                        Control ctrl = ((FTSPercentCom) control).txtPercent;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSCalculatorCom) {
                        Control ctrl = ((FTSCalculatorCom) control).Calculator;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSNameIDCom) {
                        Control ctrl = ((FTSNameIDCom) control).txtID;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSMRUEditCom) {
                        Control ctrl = ((FTSMRUEditCom) control).MruEdit;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSVatCom) {
                        Control ctrl = ((FTSVatCom) control).txtID;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSHourMinuteCom) {
                        Control ctrl = ((FTSHourMinuteCom) control).Hour;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    } else if (control is FTSColorCom) {
                        Control ctrl = ((FTSColorCom)control).ColorEdit;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0);
                        }
                    }
                }
            } else {
                foreach (Control ctl in control.Controls) {
                    this.CheckFormRequire(ctl);
                }
            }
        }

        public bool IsVisible(Control control) {
            if (this.DmFormInfo != null) {
                DataRow foundrow = this.DmFormInfo.Rows.Find(new object[] {this.Name, control.Name.ToUpper(), "VISIBLE"});
                if (foundrow != null) {
                    if (Convert.ToInt16(foundrow["PROPERTY_VALUE"]) == 1) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }

        public virtual void CheckFormRequire(Control control, string tableName) {
            if ((control is FTSComboCom) || (control is FTSSingleComboCom) || (control is FTSRadioButton) ||
                (control is FTSDateCom) || (control is FTSTextCom) || (control is FTSNumericCom) ||
                (control is FTSNumericCom2) || (control is FTSButton) || (control is FTSUpDownCom) ||
                (control is FTSNameIDCom) || (control is FTSVatCom) || (control is FTSHourMinuteCom) ||
                (control is FTSColorCom) || (control is FTSTranNumCom) || (control is FTSLabel) ||
                (control is FTSMemoCom) || (control is FTSPictureCom) || (control is FTSReadOnlyNumericCom) ||
                (control is FTSMRUEditCom) || (control is FTSCalculatorCom) || (control is FTSPercentCom) ||
                (control is FTSFreeComboCom)) {
                bool require = false;
                bool valid = true;
                IRequire ir = control as IRequire;
                if (ir != null) {
                    require = ir.Require;
                }
                IValid iv = control as IValid;
                if (iv != null) {
                    valid = iv.IsValid();
                }
                if ((require) && (!valid)) {
                    if (control is FTSComboCom) {
                        Control ctrl = ((FTSComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    }
                    if (control is FTSFreeComboCom) {
                        Control ctrl = ((FTSFreeComboCom) control).FreeComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSComboCom) {
                        Control ctrl = ((FTSComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSSingleComboCom) {
                        Control ctrl = ((FTSSingleComboCom) control).ComboBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSDateCom) {
                        Control ctrl = ((FTSDateCom) control).DateTime;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSTextCom) {
                        Control ctrl = ((FTSTextCom) control).Textbox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSTranNumCom) {
                        Control ctrl = ((FTSTranNumCom) control).Textbox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSNumericCom) {
                        Control ctrl = ((FTSNumericCom) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSReadOnlyNumericCom) {
                        Control ctrl = ((FTSReadOnlyNumericCom) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSNumericCom2) {
                        Control ctrl = ((FTSNumericCom2) control).NumericTextBox;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSColorCom) {
                        Control ctrl = ((FTSColorCom)control).ColorEdit;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSMemoCom) {
                        Control ctrl = ((FTSMemoCom) control).Memo;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSPictureCom) {
                        Control ctrl = ((FTSPictureCom) control).Picture;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSPercentCom) {
                        Control ctrl = ((FTSPercentCom) control).txtPercent;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSCalculatorCom) {
                        Control ctrl = ((FTSCalculatorCom) control).Calculator;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSNameIDCom) {
                        Control ctrl = ((FTSNameIDCom) control).txtID;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSVatCom) {
                        Control ctrl = ((FTSVatCom) control).txtID;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSHourMinuteCom) {
                        Control ctrl = ((FTSHourMinuteCom) control).Hour;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSUpDownCom) {
                        Control ctrl = ((FTSUpDownCom) control).UpDown;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    } else if (control is FTSMRUEditCom) {
                        Control ctrl = ((FTSMRUEditCom)control).MruEdit;
                        if (ctrl.DataBindings.Count > 0) {
                            throw new FTSException("REQUIRE_FIELD", ctrl.DataBindings[0].BindingMemberInfo.BindingField,
                                                   0, tableName);
                        }
                    }
                }
            } else {
                foreach (Control ctl in control.Controls) {
                    this.CheckFormRequire(ctl, tableName);
                }
            }
        }

        public virtual void CheckGridRequire(FTSDataGrid grid) {
            foreach (GridColumn c in grid.ViewGrid.Columns) {
                bool require = false;
                IRequire ir = c as IRequire;
                if (ir != null) {
                    require = ir.Require;
                }
                if (require) {
                    for (int i = 0; i < grid.ViewGrid.RowCount; i++) {
                        object cell = grid.ViewGrid.GetRowCellValue(i, c);
                        if (cell.ToString().Trim() == string.Empty) {
                            grid.ViewGrid.SelectCell(i, c);
                            throw (new FTSException("REQUIRE_FIELD", c.FieldName, i));
                        }
                    }
                }
            }
        }

        public virtual void CheckGridRequire(FTSDataGrid grid, string tableName) {
            foreach (GridColumn c in grid.ViewGrid.Columns) {
                bool require = false;
                IRequire ir = c as IRequire;
                if (ir != null) {
                    require = ir.Require;
                }
                if (require) {
                    for (int i = 0; i < grid.ViewGrid.RowCount; i++) {
                        object cell = grid.ViewGrid.GetRowCellValue(i, c);
                        if (cell.ToString().Trim() == string.Empty) {
                            grid.ViewGrid.SelectCell(i, c);
                            throw (new FTSException("REQUIRE_FIELD", c.FieldName, i, tableName));
                        }
                    }
                }
            }
        }

        private void SetProperty(FTSMain ftsmain, Control control) {
            string ctrlname = control.Name.ToUpper();
            if (control is Form) {
                this.Text = ftsmain.ResourceManager.GetValue("FRM_" + this.Name.ToUpper() + "_" + this.Name + "_TEXT",
                                                             this.Text);
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
            } else if (control is FTSGroupBox || control is FTSStatus || control is FTSShadowPanel || control is FTSShadowPanel2 || control is FTSCollapsablePanel ||
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
                       (control is FTSNameIDCom) || (control is FTSTranNumCom) || 
                       (control is FTSCalculatorCom) || (control is FTSVatCom) || (control is FTSHourMinuteCom) ||
                       (control is FTSButton) || (control is FTSUpDownCom) || (control is FTSReadOnlyNumericCom) ||
                       (control is FTSMRUEditCom) || (control is FTSPercentCom) || (control is FTSFreeComboCom) ||
                       (control is FTSRadioButton) || (control is FTSLabel) || (control is FTSColorCom)) {
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
            if (ftsmain.DbMain.WorkingMode == WorkingMode.LAN && ftsmain.UserInfo.UserGroupID == "ADMIN") {
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
        }

        public virtual void LayoutItems() {
        }

        public void SetBalloonTooltip(Control c, string tooltiptext) {
            /*
            this.ballTooltip.SetBalloonText(c, tooltiptext);
            */
            this.toolTipController.ShowHint(tooltiptext, c, ToolTipLocation.RightCenter);
        }

        public void UpdateProperty(FTSMain ftsmain, string objectname, string propertyname, string propertytype,
                                   string propertyvalue) {
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

        private bool mShowTransparentControl;

        [DefaultValue(false)]
        public bool ShowTransparentControl {
            get { return this.mShowTransparentControl; }
            set { this.mShowTransparentControl = value; }
        }

        public bool OnClose {
            get { return this.mOnClose; }
            set { this.mOnClose = value; }
        }
        public virtual void LoadDm(string tablename) {
            
        }
    }
}