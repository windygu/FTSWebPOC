namespace FTS.BaseUI.Business
{
    partial class FrmDm_Organization_EditDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ftsGroupBox1 = new FTS.BaseUI.Controls.FTSGroupBox();
            this.txtOrganization_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.chkOffline = new FTS.BaseUI.Controls.FTSCheckCom();
            this.chkIs_Shift = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtOrganization_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtShort_Organization_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtOrganization_Name_Display = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtParent_Organization_Id = new FTS.BaseUI.Controls.FTSNameIDCom();
            this.cboOrganization_Type_Id = new FTS.BaseUI.Controls.FTSComboCom();
            this.txtAddress = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtDistrict = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtCity = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPhone = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtFax = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtEmail = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtTax_File_Number = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPfs_Service_Url = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkIs_Sub = new FTS.BaseUI.Controls.FTSCheckCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftsGroupBox1)).BeginInit();
            this.ftsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(523, 26);
            // 
            // palMain
            // 
            this.palMain.Controls.Add(this.ftsGroupBox1);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(523, 327);
            // 
            // ftsGroupBox1
            // 
            this.ftsGroupBox1.Controls.Add(this.txtOrganization_Id);
            this.ftsGroupBox1.Controls.Add(this.chkActive);
            this.ftsGroupBox1.Controls.Add(this.chkOffline);
            this.ftsGroupBox1.Controls.Add(this.chkIs_Shift);
            this.ftsGroupBox1.Controls.Add(this.chkIs_Sub);
            this.ftsGroupBox1.Controls.Add(this.txtOrganization_Name);
            this.ftsGroupBox1.Controls.Add(this.txtShort_Organization_Name);
            this.ftsGroupBox1.Controls.Add(this.txtOrganization_Name_Display);
            this.ftsGroupBox1.Controls.Add(this.txtParent_Organization_Id);
            this.ftsGroupBox1.Controls.Add(this.cboOrganization_Type_Id);
            this.ftsGroupBox1.Controls.Add(this.txtAddress);
            this.ftsGroupBox1.Controls.Add(this.txtDistrict);
            this.ftsGroupBox1.Controls.Add(this.txtCity);
            this.ftsGroupBox1.Controls.Add(this.txtPhone);
            this.ftsGroupBox1.Controls.Add(this.txtFax);
            this.ftsGroupBox1.Controls.Add(this.txtEmail);
            this.ftsGroupBox1.Controls.Add(this.txtTax_File_Number);
            this.ftsGroupBox1.Controls.Add(this.txtPfs_Service_Url);
            this.ftsGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftsGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ftsGroupBox1.Name = "ftsGroupBox1";
            this.ftsGroupBox1.ShowCaption = false;
            this.ftsGroupBox1.Size = new System.Drawing.Size(523, 327);
            this.ftsGroupBox1.TabIndex = 4;
            this.ftsGroupBox1.Text = "ftsGroupBox1";
            // 
            // txtOrganization_Id
            // 
            this.txtOrganization_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganization_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrganization_Id.HelpText = "";
            this.txtOrganization_Id.LabelText = "Mã đơn vị";
            this.txtOrganization_Id.Location = new System.Drawing.Point(14, 10);
            this.txtOrganization_Id.Name = "txtOrganization_Id";
            this.txtOrganization_Id.Size = new System.Drawing.Size(180, 22);
            this.txtOrganization_Id.TabIndex = 4;
            this.txtOrganization_Id.Text = "Mã đơn vị";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 51;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(200, 10);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(71, 22);
            this.chkActive.TabIndex = 15;
            this.chkActive.Text = "Active";
            // 
            // chkOffline
            // 
            this.chkOffline.BackColor = System.Drawing.Color.Transparent;
            this.chkOffline.HelpText = "";
            this.chkOffline.LabelLenght = 57;
            this.chkOffline.LabelText = "Offline";
            this.chkOffline.Location = new System.Drawing.Point(280, 10);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(77, 22);
            this.chkOffline.TabIndex = 16;
            this.chkOffline.Text = "Offline";
            // 
            // chkIs_Shift
            // 
            this.chkIs_Shift.BackColor = System.Drawing.Color.Transparent;
            this.chkIs_Shift.HelpText = "";
            this.chkIs_Shift.LabelLenght = 43;
            this.chkIs_Shift.LabelText = "Shift";
            this.chkIs_Shift.Location = new System.Drawing.Point(371, 10);
            this.chkIs_Shift.Name = "chkIs_Shift";
            this.chkIs_Shift.Size = new System.Drawing.Size(63, 22);
            this.chkIs_Shift.TabIndex = 18;
            this.chkIs_Shift.Text = "Shift";
            // 
            // txtOrganization_Name
            // 
            this.txtOrganization_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganization_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrganization_Name.HelpText = "";
            this.txtOrganization_Name.LabelText = "Tên đơn vị";
            this.txtOrganization_Name.Location = new System.Drawing.Point(14, 34);
            this.txtOrganization_Name.Name = "txtOrganization_Name";
            this.txtOrganization_Name.Size = new System.Drawing.Size(486, 22);
            this.txtOrganization_Name.TabIndex = 5;
            this.txtOrganization_Name.Text = "Tên đơn vị";
            // 
            // txtShort_Organization_Name
            // 
            this.txtShort_Organization_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtShort_Organization_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShort_Organization_Name.HelpText = "";
            this.txtShort_Organization_Name.LabelText = "Tên viết tắt";
            this.txtShort_Organization_Name.Location = new System.Drawing.Point(293, 58);
            this.txtShort_Organization_Name.Name = "txtShort_Organization_Name";
            this.txtShort_Organization_Name.Size = new System.Drawing.Size(141, 22);
            this.txtShort_Organization_Name.TabIndex = 17;
            this.txtShort_Organization_Name.Text = "Tên viết tắt";
            // 
            // txtOrganization_Name_Display
            // 
            this.txtOrganization_Name_Display.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganization_Name_Display.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrganization_Name_Display.HelpText = "";
            this.txtOrganization_Name_Display.LabelText = "Tên chính thức";
            this.txtOrganization_Name_Display.Location = new System.Drawing.Point(14, 248);
            this.txtOrganization_Name_Display.Name = "txtOrganization_Name_Display";
            this.txtOrganization_Name_Display.Size = new System.Drawing.Size(486, 22);
            this.txtOrganization_Name_Display.TabIndex = 13;
            this.txtOrganization_Name_Display.Text = "Tên chính thức";
            // 
            // txtParent_Organization_Id
            // 
            this.txtParent_Organization_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtParent_Organization_Id.HelpText = "";
            this.txtParent_Organization_Id.IsChanged = false;
            this.txtParent_Organization_Id.LabelText = "Thuộc đơn vị";
            this.txtParent_Organization_Id.Location = new System.Drawing.Point(14, 58);
            this.txtParent_Organization_Id.Name = "txtParent_Organization_Id";
            this.txtParent_Organization_Id.Size = new System.Drawing.Size(259, 22);
            this.txtParent_Organization_Id.TabIndex = 6;
            this.txtParent_Organization_Id.Text = "Thuộc đơn vị";
            this.txtParent_Organization_Id.TextIDLength = 99;
            this.txtParent_Organization_Id.Lookup += new FTS.BaseUI.Controls.LookupEventHandler(this.Control_Lookup);
            this.txtParent_Organization_Id.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // cboOrganization_Type_Id
            // 
            this.cboOrganization_Type_Id.BackColor = System.Drawing.Color.Transparent;
            this.cboOrganization_Type_Id.HelpText = "";
            this.cboOrganization_Type_Id.IsChanged = false;
            this.cboOrganization_Type_Id.LabelText = "Loại đơn vị:";
            this.cboOrganization_Type_Id.Location = new System.Drawing.Point(14, 82);
            this.cboOrganization_Type_Id.Name = "cboOrganization_Type_Id";
            this.cboOrganization_Type_Id.Size = new System.Drawing.Size(320, 20);
            this.cboOrganization_Type_Id.TabIndex = 5;
            this.cboOrganization_Type_Id.Text = "Loại đơn vị:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAddress.HelpText = "";
            this.txtAddress.LabelText = "Địa chỉ:";
            this.txtAddress.Location = new System.Drawing.Point(14, 104);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(486, 22);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Text = "Địa chỉ:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.BackColor = System.Drawing.Color.Transparent;
            this.txtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDistrict.HelpText = "";
            this.txtDistrict.LabelText = "Quận";
            this.txtDistrict.Location = new System.Drawing.Point(14, 152);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(275, 22);
            this.txtDistrict.TabIndex = 9;
            this.txtDistrict.Text = "Quận";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.Transparent;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCity.HelpText = "";
            this.txtCity.LabelText = "Tỉnh/TP:";
            this.txtCity.Location = new System.Drawing.Point(14, 128);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(275, 22);
            this.txtCity.TabIndex = 8;
            this.txtCity.Text = "Tỉnh/TP:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPhone.HelpText = "";
            this.txtPhone.LabelText = "Điện thoại";
            this.txtPhone.Location = new System.Drawing.Point(14, 176);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(275, 22);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.Text = "Điện thoại";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.Transparent;
            this.txtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFax.HelpText = "";
            this.txtFax.LabelText = "Fax";
            this.txtFax.Location = new System.Drawing.Point(14, 200);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(275, 22);
            this.txtFax.TabIndex = 11;
            this.txtFax.Text = "Fax";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.HelpText = "";
            this.txtEmail.LabelText = "Email";
            this.txtEmail.Location = new System.Drawing.Point(14, 272);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(275, 22);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.Text = "Email";
            // 
            // txtTax_File_Number
            // 
            this.txtTax_File_Number.BackColor = System.Drawing.Color.Transparent;
            this.txtTax_File_Number.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTax_File_Number.HelpText = "";
            this.txtTax_File_Number.LabelText = "Mã số thuế";
            this.txtTax_File_Number.Location = new System.Drawing.Point(14, 224);
            this.txtTax_File_Number.Name = "txtTax_File_Number";
            this.txtTax_File_Number.Size = new System.Drawing.Size(275, 22);
            this.txtTax_File_Number.TabIndex = 12;
            this.txtTax_File_Number.Text = "Mã số thuế";
            // 
            // txtPfs_Service_Url
            // 
            this.txtPfs_Service_Url.BackColor = System.Drawing.Color.Transparent;
            this.txtPfs_Service_Url.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPfs_Service_Url.HelpText = "";
            this.txtPfs_Service_Url.LabelText = "PFS Service URL";
            this.txtPfs_Service_Url.Location = new System.Drawing.Point(12, 298);
            this.txtPfs_Service_Url.Name = "txtPfs_Service_Url";
            this.txtPfs_Service_Url.Size = new System.Drawing.Size(488, 22);
            this.txtPfs_Service_Url.TabIndex = 19;
            this.txtPfs_Service_Url.Text = "PFS Service URL";
            // 
            // chkIs_Sub
            // 
            this.chkIs_Sub.BackColor = System.Drawing.Color.Transparent;
            this.chkIs_Sub.HelpText = "";
            this.chkIs_Sub.LabelLenght = 43;
            this.chkIs_Sub.LabelText = "Sub";
            this.chkIs_Sub.Location = new System.Drawing.Point(444, 10);
            this.chkIs_Sub.Name = "chkIs_Sub";
            this.chkIs_Sub.Size = new System.Drawing.Size(63, 22);
            this.chkIs_Sub.TabIndex = 20;
            this.chkIs_Sub.Text = "Sub";
            // 
            // FrmDm_Organization_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 353);
            this.Name = "FrmDm_Organization_EditDetail";
            this.Text = "FrmDm_Organization_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ftsGroupBox1)).EndInit();
            this.ftsGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSGroupBox ftsGroupBox1;
        protected FTS.BaseUI.Controls.FTSTextCom txtOrganization_Id;
        protected FTS.BaseUI.Controls.FTSTextCom txtOrganization_Name;
        protected FTS.BaseUI.Controls.FTSNameIDCom txtParent_Organization_Id;
        protected FTS.BaseUI.Controls.FTSTextCom txtOrganization_Name_Display;
        protected FTS.BaseUI.Controls.FTSTextCom txtTax_File_Number;
        protected FTS.BaseUI.Controls.FTSTextCom txtFax;
        protected FTS.BaseUI.Controls.FTSTextCom txtPhone;
        protected FTS.BaseUI.Controls.FTSTextCom txtDistrict;
        protected FTS.BaseUI.Controls.FTSTextCom txtCity;
        protected FTS.BaseUI.Controls.FTSTextCom txtAddress;
        protected FTS.BaseUI.Controls.FTSTextCom txtEmail;
        private FTS.BaseUI.Controls.FTSComboCom cboOrganization_Type_Id;
        protected Controls.FTSCheckCom chkActive;
        protected Controls.FTSCheckCom chkOffline;
        protected Controls.FTSTextCom txtShort_Organization_Name;
        protected Controls.FTSTextCom txtPfs_Service_Url;
        protected Controls.FTSCheckCom chkIs_Shift;
        protected Controls.FTSCheckCom chkIs_Sub;

    }
}
