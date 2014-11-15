// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:53
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmAdminUser.cs
// Project Item Filename:     FrmAdminUser.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Security{
    public class FrmAdminUser : FrmBaseForm{
        private FTSButton btnCancel;
        private FTSButton btnOK;
        private Container components = null;
        public string UserId = string.Empty;
        public string UserName = string.Empty;
        public string OrganizationId = string.Empty;
        public string PassWord = string.Empty;
        public string UserGroup = string.Empty;
        public string OrganizationID = string.Empty;
        public bool Active = true;
        public string EmployeeID = string.Empty;
        protected FTSTextCom txtConfirmPassword;
        protected FTSTextCom txtPassword;
        protected FTSTextCom txtUser_Name;
        protected FTSTextCom txtUser_Id;
        private FTSTextCom cboUser_Group_Id;
        private FTSCheckCom chkActive;
        private DataTable sec_user;
        private FTSComboCom cboOrganization_Id;
        private FTSComboCom cboEmployee_ID;
        private FTSButton cmdSelect;
        private bool flagedit;

        public FrmAdminUser(){
            InitializeComponent();
        }

        public FrmAdminUser(FTSMain ftsmain, string userid, string username, string usergroupid, string organizationid,
                            string employeeid,
                            string password, bool active, bool flagedit, DataTable sec_user)
            : base(ftsmain, true){
            InitializeComponent();
            this.LoadLayout(this.FTSMain);

            DataSet ds = new DataSet();
            this.FTSMain.TableManager.LoadTable(ds, "sec_user_group");
            this.FTSMain.TableManager.LoadTable(ds, "dm_organization");
            this.cboOrganization_Id.Set(this.FTSMain, "dm_organization", ds, "ORGANIZATION_ID", "ORGANIZATION_NAME",
                                        ComboComType.NameOnly, false);

            this.FTSMain.TableManager.LoadTable(ds, "HR_EMPLOYEE_INFO");
            this.cboEmployee_ID.Set(this.FTSMain, "HR_EMPLOYEE_INFO", ds, "EMPLOYEE_ID", "EMPLOYEE_NAME",
                                    ComboComType.NameOnly, false);

            this.txtUser_Id.Textbox.Text = userid;
            this.txtUser_Name.Textbox.Text = username;
            this.txtPassword.Textbox.Text = password;
            this.txtConfirmPassword.Textbox.Text = password;
            this.chkActive.CheckBox.Checked = active;
            this.cboUser_Group_Id.Textbox.EditValue = usergroupid;
            this.cboOrganization_Id.ComboBox.EditValue = organizationid;
            this.cboEmployee_ID.ComboBox.EditValue = employeeid;
            this.txtPassword.Textbox.Properties.PasswordChar = '*';
            this.txtConfirmPassword.Textbox.Properties.PasswordChar = '*';
            this.sec_user = sec_user;
            this.flagedit = flagedit;
            this.txtUser_Id.Textbox.Properties.CharacterCasing = CharacterCasing.Upper;
            if (this.flagedit){
                this.txtUser_Id.Enabled = false;
            } else{
                this.txtUser_Id.Enabled = true;
            }
        }

        protected override void Dispose(bool disposing){
            if (disposing){
                if (components != null){
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(){
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            this.btnOK = new FTS.BaseUI.Controls.FTSButton();
            this.txtConfirmPassword = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPassword = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtUser_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtUser_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.cboUser_Group_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.cboOrganization_Id = new FTS.BaseUI.Controls.FTSComboCom();
            this.cboEmployee_ID = new FTS.BaseUI.Controls.FTSComboCom();
            this.cmdSelect = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.txtUser_Id);
            this.groupBox.Controls.Add(this.chkActive);
            this.groupBox.Controls.Add(this.txtUser_Name);
            this.groupBox.Controls.Add(this.txtPassword);
            this.groupBox.Controls.Add(this.txtConfirmPassword);
            this.groupBox.Controls.Add(this.cboUser_Group_Id);
            this.groupBox.Controls.Add(this.cmdSelect);
            this.groupBox.Controls.Add(this.cboOrganization_Id);
            this.groupBox.Controls.Add(this.cboEmployee_ID);
            this.groupBox.Controls.Add(this.btnOK);
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(323, 222);
            this.groupBox.UseBorderColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.HelpText = "";
            this.btnCancel.Location = new System.Drawing.Point(233, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.HelpText = "";
            this.btnOK.Location = new System.Drawing.Point(147, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtConfirmPassword.HelpText = "";
            this.txtConfirmPassword.LabelLength = 115;
            this.txtConfirmPassword.LabelText = "Khẳng định mật khẩu:";
            this.txtConfirmPassword.Location = new System.Drawing.Point(9, 86);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(240, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.Text = "Khẳng định mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.HelpText = "";
            this.txtPassword.LabelLength = 115;
            this.txtPassword.LabelText = "Mật khẩu:";
            this.txtPassword.Location = new System.Drawing.Point(9, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Mật khẩu:";
            // 
            // txtUser_Name
            // 
            this.txtUser_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtUser_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser_Name.HelpText = "";
            this.txtUser_Name.LabelLength = 115;
            this.txtUser_Name.LabelText = "Tên đầy đủ:";
            this.txtUser_Name.Location = new System.Drawing.Point(9, 34);
            this.txtUser_Name.Name = "txtUser_Name";
            this.txtUser_Name.Size = new System.Drawing.Size(304, 20);
            this.txtUser_Name.TabIndex = 3;
            this.txtUser_Name.Text = "Tên đầy đủ:";
            // 
            // txtUser_Id
            // 
            this.txtUser_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtUser_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser_Id.Enabled = false;
            this.txtUser_Id.HelpText = "";
            this.txtUser_Id.LabelLength = 115;
            this.txtUser_Id.LabelText = "Tên đăng nhập:";
            this.txtUser_Id.Location = new System.Drawing.Point(9, 8);
            this.txtUser_Id.Name = "txtUser_Id";
            this.txtUser_Id.Size = new System.Drawing.Size(240, 20);
            this.txtUser_Id.TabIndex = 1;
            this.txtUser_Id.Text = "Tên đăng nhập:";
            // 
            // cboUser_Group_Id
            // 
            this.cboUser_Group_Id.BackColor = System.Drawing.Color.Transparent;
            this.cboUser_Group_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboUser_Group_Id.HelpText = "";
            this.cboUser_Group_Id.LabelLength = 115;
            this.cboUser_Group_Id.LabelText = "Nhóm người dùng:";
            this.cboUser_Group_Id.Location = new System.Drawing.Point(9, 112);
            this.cboUser_Group_Id.Name = "cboUser_Group_Id";
            this.cboUser_Group_Id.Size = new System.Drawing.Size(267, 20);
            this.cboUser_Group_Id.TabIndex = 5;
            this.cboUser_Group_Id.Text = "Nhóm người dùng:";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 36;
            this.chkActive.LabelText = "Active:";
            this.chkActive.Location = new System.Drawing.Point(257, 8);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 20);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active:";
            // 
            // cboOrganization_Id
            // 
            this.cboOrganization_Id.BackColor = System.Drawing.Color.Transparent;
            this.cboOrganization_Id.HelpText = "";
            this.cboOrganization_Id.IsChanged = false;
            this.cboOrganization_Id.LabelLength = 115;
            this.cboOrganization_Id.LabelText = "Đơn vị:";
            this.cboOrganization_Id.Location = new System.Drawing.Point(9, 138);
            this.cboOrganization_Id.Name = "cboOrganization_Id";
            this.cboOrganization_Id.Size = new System.Drawing.Size(304, 20);
            this.cboOrganization_Id.TabIndex = 8;
            this.cboOrganization_Id.Text = "Đơn vị:";
            // 
            // cboEmployee_ID
            // 
            this.cboEmployee_ID.BackColor = System.Drawing.Color.Transparent;
            this.cboEmployee_ID.HelpText = "";
            this.cboEmployee_ID.IsChanged = false;
            this.cboEmployee_ID.LabelLength = 115;
            this.cboEmployee_ID.LabelText = "Nhân viên:";
            this.cboEmployee_ID.Location = new System.Drawing.Point(9, 164);
            this.cboEmployee_ID.Name = "cboEmployee_ID";
            this.cboEmployee_ID.Size = new System.Drawing.Size(304, 20);
            this.cboEmployee_ID.TabIndex = 9;
            this.cboEmployee_ID.Text = "Nhân viên:";
            // 
            // cmdSelect
            // 
            this.cmdSelect.HelpText = "";
            this.cmdSelect.Location = new System.Drawing.Point(282, 111);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(29, 21);
            this.cmdSelect.TabIndex = 10;
            this.cmdSelect.Text = "...";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // FrmAdminUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(323, 222);
            this.Name = "FrmAdminUser";
            this.Text = "Người sử dụng";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e){
            if (this.txtPassword.Textbox.Text != this.txtConfirmPassword.Textbox.Text){
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_INVALID_CONFIRM_PASSWORD"));
                return;
            }
            if (!this.flagedit){
                DataRow foundrow = this.sec_user.Rows.Find(this.txtUser_Id.Textbox.Text.Trim());
                if (foundrow != null){
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_USER_EXISTS"));
                    return;
                }
            }
            this.UserName = this.txtUser_Name.Textbox.Text.Trim();
            this.UserId = this.txtUser_Id.Textbox.Text.Trim();
            this.PassWord = this.txtPassword.Textbox.Text.Trim();
            this.Active = this.chkActive.CheckBox.Checked;
            this.UserGroup = this.cboUser_Group_Id.Textbox.EditValue.ToString();
            this.OrganizationID = this.cboOrganization_Id.ComboBox.EditValue.ToString();
            this.EmployeeID = this.cboEmployee_ID.ComboBox.EditValue.ToString();
            if (this.UserName != string.Empty && this.UserId != string.Empty && this.UserGroup != string.Empty){
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else{
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(this.FTSMain.MsgManager.GetMessage("MSG_INVALID_INPUT"));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public override Type GetFrmDicEditDetail(string tablename){
            return typeof (FrmSec_User_Group_EditDetail);
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.cboUser_Group_Id.Enabled = false;
        }
        private void cmdSelect_Click(object sender, EventArgs e) {
            GetItems.GetList(this.FTSMain,"SEC_USER_GROUP",this.cboUser_Group_Id.Textbox);
        }
    }
}