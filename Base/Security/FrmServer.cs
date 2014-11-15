using System;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.BaseUI.Security {
    /// <summary>
    /// Summary description for FrmServer.
    /// </summary>
    public class FrmServer : FTS.BaseUI.Forms.FTSForm {
        private FTS.BaseUI.Controls.FTSShadowPanel groupBox1;
        protected FTS.BaseUI.Controls.FTSLabel lblMa_donvi;
        protected FTS.BaseUI.Controls.FTSLabel lblTen_cty;
        private FTS.BaseUI.Controls.FTSButton cmdOK;
        private FTS.BaseUI.Controls.FTSButton cmdClose;
        protected FTS.BaseUI.Controls.FTSLabel efsLabel1;
        protected FTS.BaseUI.Controls.FTSTextBox txtUserID;
        protected FTS.BaseUI.Controls.FTSTextBox txtPassword;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public string ServerName = "";
        public string UserID = "";
        public string Password = "";
        public WorkingMode ClientWorkingMode;
        private FTS.BaseUI.Controls.FTSTextBox cboServer;
        private FTS.BaseUI.Controls.FTSGroupBox groupWorkingMode;
        private FTS.BaseUI.Controls.FTSRadioButton rdoLAN;
        private FTS.BaseUI.Controls.FTSRadioButton rdoRemote;
        public bool Cancel = false;
        private FTSMain mFTSMain;

        public FrmServer(FTSMain ftsmain) {
            this.InitializeComponent();
            this.mFTSMain = ftsmain;
            if (this.mFTSMain.Config.AppSettings.Settings["WORKINGMODE"].Value == "1") {
                this.rdoLAN.Checked = true;
                this.txtPassword.Enabled = true;
                this.txtUserID.Enabled = true;
                this.cboServer.Text = this.mFTSMain.Config.AppSettings.Settings["SERVERNAME"].Value;
                this.txtUserID.Text = this.mFTSMain.Config.AppSettings.Settings["USERID"].Value;
                this.txtPassword.Text = Functions.Decrypt(this.mFTSMain.Config.AppSettings.Settings["PASSWORD"].Value);
            }else {
                this.rdoRemote.Checked = true;
                this.txtPassword.Enabled = false;
                this.txtUserID.Enabled = false;
                this.cboServer.Text = this.mFTSMain.Config.AppSettings.Settings["SERVERURL"].Value;

            }

        }

        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupWorkingMode = new FTS.BaseUI.Controls.FTSGroupBox();
            this.rdoLAN = new FTS.BaseUI.Controls.FTSRadioButton();
            this.rdoRemote = new FTS.BaseUI.Controls.FTSRadioButton();
            this.cboServer = new FTS.BaseUI.Controls.FTSTextBox();
            this.txtPassword = new FTS.BaseUI.Controls.FTSTextBox();
            this.efsLabel1 = new FTS.BaseUI.Controls.FTSLabel();
            this.lblMa_donvi = new FTS.BaseUI.Controls.FTSLabel();
            this.txtUserID = new FTS.BaseUI.Controls.FTSTextBox();
            this.lblTen_cty = new FTS.BaseUI.Controls.FTSLabel();
            this.cmdOK = new FTS.BaseUI.Controls.FTSButton();
            this.cmdClose = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupWorkingMode)).BeginInit();
            this.groupWorkingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BlankWidth = 5;
            this.groupBox1.BorderColor = System.Drawing.Color.Empty;
            this.groupBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox1.Controls.Add(this.groupWorkingMode);
            this.groupBox1.Controls.Add(this.cboServer);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.efsLabel1);
            this.groupBox1.Controls.Add(this.lblMa_donvi);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.lblTen_cty);
            this.groupBox1.Controls.Add(this.cmdOK);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 196);
            this.groupBox1.TabIndex = 0;
            // 
            // groupWorkingMode
            // 
            this.groupWorkingMode.Controls.Add(this.rdoLAN);
            this.groupWorkingMode.Controls.Add(this.rdoRemote);
            this.groupWorkingMode.Location = new System.Drawing.Point(41, 12);
            this.groupWorkingMode.Name = "groupWorkingMode";
            this.groupWorkingMode.Size = new System.Drawing.Size(302, 49);
            this.groupWorkingMode.TabIndex = 38;
            this.groupWorkingMode.Text = "Working Mode";
            this.groupWorkingMode.Click += new System.EventHandler(this.groupWorkingMode_Click);
            // 
            // rdoLAN
            // 
            this.rdoLAN.AutoSize = true;
            this.rdoLAN.Checked = true;
            this.rdoLAN.HelpText = "";
            this.rdoLAN.Location = new System.Drawing.Point(100, 23);
            this.rdoLAN.Name = "rdoLAN";
            this.rdoLAN.Size = new System.Drawing.Size(46, 17);
            this.rdoLAN.TabIndex = 3;
            this.rdoLAN.TabStop = true;
            this.rdoLAN.Text = "LAN";
            this.rdoLAN.UseVisualStyleBackColor = true;
            this.rdoLAN.Click += new System.EventHandler(this.groupWorkingMode_Click);
            // 
            // rdoRemote
            // 
            this.rdoRemote.AutoSize = true;
            this.rdoRemote.HelpText = "";
            this.rdoRemote.Location = new System.Drawing.Point(190, 23);
            this.rdoRemote.Name = "rdoRemote";
            this.rdoRemote.Size = new System.Drawing.Size(62, 17);
            this.rdoRemote.TabIndex = 4;
            this.rdoRemote.Text = "Remote";
            this.rdoRemote.UseVisualStyleBackColor = true;
            this.rdoRemote.Click += new System.EventHandler(this.groupWorkingMode_Click);
            // 
            // cboServer
            // 
            this.cboServer.EnterMoveNextControl = true;
            this.cboServer.HelpText = "";
            this.cboServer.Location = new System.Drawing.Point(138, 69);
            this.cboServer.Name = "cboServer";
            this.cboServer.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboServer.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.cboServer.PromptText = "";
            this.cboServer.Size = new System.Drawing.Size(205, 20);
            this.cboServer.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.HelpText = "";
            this.txtPassword.Location = new System.Drawing.Point(138, 124);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtPassword.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPassword.PromptText = "";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // efsLabel1
            // 
            this.efsLabel1.AutoSize = true;
            this.efsLabel1.BackColor = System.Drawing.Color.Transparent;
            this.efsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.efsLabel1.ForeColor = System.Drawing.Color.Black;
            this.efsLabel1.HelpText = "";
            this.efsLabel1.Location = new System.Drawing.Point(43, 129);
            this.efsLabel1.Name = "efsLabel1";
            this.efsLabel1.Size = new System.Drawing.Size(56, 13);
            this.efsLabel1.TabIndex = 5;
            this.efsLabel1.Text = "Password:";
            // 
            // lblMa_donvi
            // 
            this.lblMa_donvi.AutoSize = true;
            this.lblMa_donvi.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_donvi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMa_donvi.ForeColor = System.Drawing.Color.Black;
            this.lblMa_donvi.HelpText = "";
            this.lblMa_donvi.Location = new System.Drawing.Point(43, 73);
            this.lblMa_donvi.Name = "lblMa_donvi";
            this.lblMa_donvi.Size = new System.Drawing.Size(88, 13);
            this.lblMa_donvi.TabIndex = 1;
            this.lblMa_donvi.Text = "Database server:";
            // 
            // txtUserID
            // 
            this.txtUserID.EditValue = "";
            this.txtUserID.EnterMoveNextControl = true;
            this.txtUserID.HelpText = "";
            this.txtUserID.Location = new System.Drawing.Point(138, 96);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtUserID.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtUserID.PromptText = "";
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Size = new System.Drawing.Size(205, 21);
            this.txtUserID.TabIndex = 4;
            // 
            // lblTen_cty
            // 
            this.lblTen_cty.AutoSize = true;
            this.lblTen_cty.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_cty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTen_cty.ForeColor = System.Drawing.Color.Black;
            this.lblTen_cty.HelpText = "";
            this.lblTen_cty.Location = new System.Drawing.Point(43, 101);
            this.lblTen_cty.Name = "lblTen_cty";
            this.lblTen_cty.Size = new System.Drawing.Size(61, 13);
            this.lblTen_cty.TabIndex = 3;
            this.lblTen_cty.Text = "User name:";
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.HelpText = "";
            this.cmdOK.Location = new System.Drawing.Point(106, 158);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(70, 22);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdClose.Appearance.Options.UseFont = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.HelpText = "";
            this.cmdClose.Location = new System.Drawing.Point(210, 158);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(70, 22);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "Cancel";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 196);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmServer";
            this.Text = "Connecting to database server";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupWorkingMode)).EndInit();
            this.groupWorkingMode.ResumeLayout(false);
            this.groupWorkingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void cmdOK_Click(object sender, System.EventArgs e) {
            this.ClientWorkingMode = this.rdoLAN.Checked ? WorkingMode.LAN : WorkingMode.WAN;
            this.ServerName = this.cboServer.Text.Trim();
            this.UserID = this.txtUserID.Text.Trim();
            this.Password = this.txtPassword.Text.Trim();
            this.Hide();
        }

        private void cmdClose_Click(object sender, System.EventArgs e) {
            this.Cancel = true;
            this.Hide();
        }

        private void groupWorkingMode_Click(object sender, EventArgs e) {
            if (this.rdoLAN.Checked) {
                this.txtPassword.Enabled = true;
                this.txtUserID.Enabled = true;
                this.cboServer.Text = this.mFTSMain.Config.AppSettings.Settings["SERVERNAME"].Value;
                this.txtUserID.Text = this.mFTSMain.Config.AppSettings.Settings["USERID"].Value;
                this.txtPassword.Text = Functions.Decrypt(this.mFTSMain.Config.AppSettings.Settings["PASSWORD"].Value);
            }else {
                this.txtPassword.Enabled = false;
                this.txtUserID.Enabled = false;
                this.cboServer.Text = this.mFTSMain.Config.AppSettings.Settings["SERVERURL"].Value;

            }
        }
    }
}