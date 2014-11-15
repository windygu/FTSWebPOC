// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:52
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmGetString.cs
// Project Item Filename:     FrmGetString.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Business;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmLock : FrmBaseForm {
        private IContainer components = null;
        private FTSDateCom txtDate;
        private FTSButton cmdOK;
        private FTSButton cmdClose;
        private FTSRadioButton rdoByModule;
        private FTSRadioButton rdoAllModule;
        private FTSComboCom cboDes_Organization_ID;
        private FTSComboCom cboModuleID;
        

        public FrmLock(FTSMain ftsmain) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout();
            this.SetData();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtDate = new FTS.BaseUI.Controls.FTSDateCom();
            this.cmdOK = new FTS.BaseUI.Controls.FTSButton();
            this.cmdClose = new FTS.BaseUI.Controls.FTSButton();
            this.rdoByModule = new FTS.BaseUI.Controls.FTSRadioButton();
            this.rdoAllModule = new FTS.BaseUI.Controls.FTSRadioButton();
            this.cboModuleID = new FTS.BaseUI.Controls.FTSComboCom();
            this.cboDes_Organization_ID = new FTS.BaseUI.Controls.FTSComboCom();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.BlankWidth = 2;
            this.groupBox.Controls.Add(this.rdoByModule);
            this.groupBox.Controls.Add(this.rdoAllModule);
            this.groupBox.Controls.Add(this.cboDes_Organization_ID);
            this.groupBox.Controls.Add(this.cboModuleID);
            this.groupBox.Controls.Add(this.txtDate);
            this.groupBox.Controls.Add(this.cmdOK);
            this.groupBox.Controls.Add(this.cmdClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.Size = new System.Drawing.Size(328, 163);
            this.groupBox.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.Transparent;
            this.txtDate.HelpText = "";
            this.txtDate.IsChanged = false;
            this.txtDate.LabelLength = 70;
            this.txtDate.LabelText = "Đến ngày:";
            this.txtDate.Location = new System.Drawing.Point(34, 96);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(158, 22);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "Đến ngày:";
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdOK.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdOK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdOK.Appearance.Options.UseBackColor = true;
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Appearance.Options.UseForeColor = true;
            this.cmdOK.HelpText = "";
            this.cmdOK.Location = new System.Drawing.Point(73, 129);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Đồng ý";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_ButtonPressed);
            // 
            // cmdClose
            // 
            this.cmdClose.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdClose.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdClose.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdClose.Appearance.Options.UseBackColor = true;
            this.cmdClose.Appearance.Options.UseFont = true;
            this.cmdClose.Appearance.Options.UseForeColor = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.HelpText = "";
            this.cmdClose.Location = new System.Drawing.Point(181, 129);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Bỏ qua";
            this.cmdClose.Click += new System.EventHandler(this.cmdCancel_ButtonPressed);
            // 
            // rdoByModule
            // 
            this.rdoByModule.AutoSize = true;
            this.rdoByModule.HelpText = "";
            this.rdoByModule.Location = new System.Drawing.Point(202, 19);
            this.rdoByModule.Name = "rdoByModule";
            this.rdoByModule.Size = new System.Drawing.Size(92, 17);
            this.rdoByModule.TabIndex = 63;
            this.rdoByModule.Text = "Từng phân hệ";
            this.rdoByModule.UseVisualStyleBackColor = true;
            this.rdoByModule.CheckedChanged += new System.EventHandler(this.rdoAllModule_CheckedChanged);
            // 
            // rdoAllModule
            // 
            this.rdoAllModule.AutoSize = true;
            this.rdoAllModule.Checked = true;
            this.rdoAllModule.HelpText = "";
            this.rdoAllModule.Location = new System.Drawing.Point(37, 19);
            this.rdoAllModule.Name = "rdoAllModule";
            this.rdoAllModule.Size = new System.Drawing.Size(119, 17);
            this.rdoAllModule.TabIndex = 62;
            this.rdoAllModule.TabStop = true;
            this.rdoAllModule.Text = "Tất cả các phân hệ";
            this.rdoAllModule.UseVisualStyleBackColor = true;
            this.rdoAllModule.CheckedChanged += new System.EventHandler(this.rdoAllModule_CheckedChanged);
            // 
            // cboModuleID
            // 
            this.cboModuleID.BackColor = System.Drawing.Color.Transparent;
            this.cboModuleID.HelpText = "";
            this.cboModuleID.IsChanged = false;
            this.cboModuleID.LabelLength = 70;
            this.cboModuleID.LabelText = "Phân hệ:";
            this.cboModuleID.Location = new System.Drawing.Point(34, 70);
            this.cboModuleID.Name = "cboModuleID";
            this.cboModuleID.Size = new System.Drawing.Size(260, 22);
            this.cboModuleID.TabIndex = 61;
            this.cboModuleID.Text = "Phân hệ:";
            this.cboModuleID.ComboChange += new System.EventHandler(this.cboModuleID_ComboChange);
            this.cboModuleID.Leave += new System.EventHandler(this.cboModuleID_ComboChange);
            // 
            // cboDes_Organization_ID
            // 
            this.cboDes_Organization_ID.BackColor = System.Drawing.Color.Transparent;
            this.cboDes_Organization_ID.HelpText = "";
            this.cboDes_Organization_ID.IsChanged = false;
            this.cboDes_Organization_ID.LabelLength = 70;
            this.cboDes_Organization_ID.LabelText = "Đơn vị:";
            this.cboDes_Organization_ID.Location = new System.Drawing.Point(34, 42);
            this.cboDes_Organization_ID.Name = "cboDes_Organization_ID";
            this.cboDes_Organization_ID.Size = new System.Drawing.Size(260, 22);
            this.cboDes_Organization_ID.TabIndex = 64;
            this.cboDes_Organization_ID.Text = "Đơn vị:";
            this.cboDes_Organization_ID.ComboChange += new System.EventHandler(this.cboDes_Organization_ID_ComboChange);
            this.cboDes_Organization_ID.Leave += new System.EventHandler(this.cboDes_Organization_ID_ComboChange);
            // 
            // FrmLock
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(328, 163);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khóa sổ";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void SetData() {
            this.cboModuleID.Set(ModuleList.GetModuleList(this.FTSMain));
            this.cboModuleID.ComboBox.EditValue = string.Empty;
            this.cboModuleID.Enabled = false;

            string organizationlist = Dm_Organization.GetChildOrganizationList(this.FTSMain.TableManager.LoadTable("DM_ORGANIZATION","ACTIVE=1"),
                                                     this.FTSMain.UserInfo.OrganizationID);
            DataTable dm_organization = this.FTSMain.TableManager.LoadTable("DM_ORGANIZATION", "ACTIVE=1 AND ORGANIZATION_ID IN " + Functions.PopulateString(organizationlist));
            this.cboDes_Organization_ID.Set(this.FTSMain,dm_organization,"ORGANIZATION_ID","ORGANIZATION_NAME",ComboComType.NameID,false);
            string sql = "select TOP 1 TO_DATE,DES_ORGANIZATION_ID from sys_lock where ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID +
                             "' and MODULE_ID=''";
            DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql), "dt");
            if (dt.Rows.Count > 0) {
                this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                this.cboDes_Organization_ID.ComboBox.EditValue = dt.Rows[0]["DES_ORGANIZATION_ID"];
            } else {
                this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                this.cboDes_Organization_ID.ComboBox.EditValue = this.FTSMain.UserInfo.OrganizationID;
            }
        }

        private void cmdCancel_ButtonPressed(object sender, EventArgs e) {
            this.Close();
        }

        private void cmdOK_ButtonPressed(object sender, EventArgs e) {
            try {
                if (this.rdoByModule.Checked &&
                    (this.cboModuleID.ComboBox.EditValue == null ||
                     this.cboModuleID.ComboBox.EditValue.ToString() == string.Empty)) {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_INVALID_MODULE_ID"));
                    this.cboModuleID.Focus();
                    return;
                }
                if (this.cboDes_Organization_ID.ComboBox.EditValue == null ||
                     this.cboDes_Organization_ID.ComboBox.EditValue.ToString() == string.Empty) {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_INVALID_ORGANIZATION_ID"));
                    this.cboDes_Organization_ID.Focus();
                    return;
                }
                this.FTSMain.Sys_Lock.SetLock(this.cboModuleID.ComboBox.EditValue.ToString(),this.cboDes_Organization_ID.ComboBox.EditValue.ToString(),
                                (DateTime) this.txtDate.DateTime.EditValue);
                this.Close();
            }catch(Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void rdoAllModule_CheckedChanged(object sender, EventArgs e) {
            if (this.rdoAllModule.Checked) {
                this.cboModuleID.ComboBox.EditValue = string.Empty;
                this.cboModuleID.Enabled = false;
                string sql = "select TOP 1 TO_DATE,DES_ORGANIZATION_ID from sys_lock where ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID +
                             "' and MODULE_ID=''";
                DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),"dt");
                if (dt.Rows.Count > 0) {
                    this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                    this.cboDes_Organization_ID.ComboBox.EditValue = dt.Rows[0]["DES_ORGANIZATION_ID"];
                }else {
                    this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                    this.cboDes_Organization_ID.ComboBox.EditValue = this.FTSMain.UserInfo.OrganizationID;
                }
            }else {
                this.cboModuleID.Enabled = true;
                this.cboModuleID.ComboBox.EditValue = ModuleList.FIN_CASHBANK;
                string sql = "select TOP 1 TO_DATE,DES_ORGANIZATION_ID from sys_lock where ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID +
                            "' and MODULE_ID='" + this.cboModuleID.ComboBox.EditValue + "'";
                DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql), "dt");
                if (dt.Rows.Count > 0) {
                    this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                    this.cboDes_Organization_ID.ComboBox.EditValue = dt.Rows[0]["DES_ORGANIZATION_ID"];
                } else {
                    this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                    this.cboDes_Organization_ID.ComboBox.EditValue = this.FTSMain.UserInfo.OrganizationID;
                }
            }
        }

        private void cboModuleID_ComboChange(object sender, EventArgs e) {
            if (this.cboModuleID.ComboBox.EditValue.ToString() != string.Empty) {
                string sql = "select TOP 1 DES_ORGANIZATION_ID, TO_DATE from sys_lock where ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID +
                             "' and MODULE_ID='" + this.cboModuleID.ComboBox.EditValue + "'";
                DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql), "dt");
                if (dt.Rows.Count > 0) {
                    this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                    this.cboDes_Organization_ID.ComboBox.EditValue = dt.Rows[0]["DES_ORGANIZATION_ID"];
                } else {
                    this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                    this.cboDes_Organization_ID.ComboBox.EditValue = this.FTSMain.UserInfo.OrganizationID;
                }
            }
        }

        private void cboDes_Organization_ID_ComboChange(object sender, EventArgs e) {
            if (this.rdoByModule.Checked) {
                if (this.cboModuleID.ComboBox.EditValue.ToString() != string.Empty) {
                    if (this.cboDes_Organization_ID.ComboBox.EditValue.ToString() != string.Empty) {
                        string sql = "select TOP 1 TO_DATE from sys_lock where ORGANIZATION_ID='" +
                                     this.FTSMain.UserInfo.OrganizationID + "' and MODULE_ID='" +
                                     this.cboModuleID.ComboBox.EditValue + "'" + "and DES_ORGANIZATION_ID='" +
                                     this.cboDes_Organization_ID.ComboBox.EditValue + "'";
                        DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),
                                                                         "dt");
                        if (dt.Rows.Count > 0) {
                            this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                        } else {
                            this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                        }
                    }
                } else {
                    if (this.cboDes_Organization_ID.ComboBox.EditValue.ToString() != string.Empty) {
                        string sql = "select TOP 1 MODULE_ID,TO_DATE from sys_lock where ORGANIZATION_ID='" +
                                     this.FTSMain.UserInfo.OrganizationID + "' and DES_ORGANIZATION_ID='" +
                                     this.cboDes_Organization_ID.ComboBox.EditValue + "'";
                        DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),
                                                                         "dt");
                        if (dt.Rows.Count > 0) {
                            this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                            this.cboModuleID.ComboBox.EditValue = dt.Rows[0]["MODULE_ID"];
                        } else {
                            this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                        }
                    }
                }
            }else {
                this.cboModuleID.ComboBox.EditValue = string.Empty;
                this.cboModuleID.Enabled = false;
                    if (this.cboDes_Organization_ID.ComboBox.EditValue.ToString() != string.Empty) {
                        string sql = "select TOP 1 MODULE_ID,TO_DATE from sys_lock where MODULE_ID='' AND ORGANIZATION_ID='" +
                                     this.FTSMain.UserInfo.OrganizationID + "' and DES_ORGANIZATION_ID='" +
                                     this.cboDes_Organization_ID.ComboBox.EditValue + "'";
                        DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),
                                                                         "dt");
                        if (dt.Rows.Count > 0) {
                            this.txtDate.DateTime.EditValue = dt.Rows[0]["TO_DATE"];
                        } else {
                            this.txtDate.DateTime.EditValue = this.FTSMain.DayStartOfFirstYear.AddDays(-1);
                        }
                    }
                
            }
        }
        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            if ((bool)this.FTSMain.SystemVars.GetSystemVars("TRANSACTION_LOCK_BY_MODULE")) {
                this.rdoByModule.Enabled = true;
            }else {
                this.rdoByModule.Enabled = false;
            }
        }
    }
}