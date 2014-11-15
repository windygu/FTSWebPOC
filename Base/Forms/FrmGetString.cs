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
using System.Windows.Forms;
using FTS.BaseUI.Controls;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmGetString : Form {
        private IContainer components = null;
        protected FTSShadowPanel groupBox;
        private FTSButton cmdOK;
        private FTSTextCom txtString;
        private FTSButton cmdClose;
        public string RetVal = string.Empty;

        public FrmGetString() {
            this.InitializeComponent();
        }

        public FrmGetString(string title, string label) {
            this.InitializeComponent();
            this.Text = title;
            this.txtString.LabelText = label;
        }

        public FrmGetString(string title, string label, string val) {
            this.InitializeComponent();
            this.Text = title;
            this.txtString.LabelText = label;
            this.txtString.Textbox.EditValue = val;
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
            this.groupBox = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.cmdOK = new FTS.BaseUI.Controls.FTSButton();
            this.txtString = new FTS.BaseUI.Controls.FTSTextCom();
            this.cmdClose = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BlankWidth = 4;
            this.groupBox.BorderColor = System.Drawing.Color.Empty;
            this.groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox.Controls.Add(this.txtString);
            this.groupBox.Controls.Add(this.cmdOK);
            this.groupBox.Controls.Add(this.cmdClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(338, 112);
            this.groupBox.TabIndex = 0;
            // 
            // cmdOK
            // 
            this.cmdOK.HelpText = "";
            this.cmdOK.Location = new System.Drawing.Point(76, 70);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Đồng ý";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_ButtonPressed);
            // 
            // txtString
            // 
            this.txtString.BackColor = System.Drawing.Color.Transparent;
            this.txtString.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtString.HelpText = "";
            this.txtString.LabelText = "Mật khẩu:";
            this.txtString.Location = new System.Drawing.Point(17, 29);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(304, 20);
            this.txtString.TabIndex = 1;
            this.txtString.Text = "Mật khẩu:";
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.HelpText = "";
            this.cmdClose.Location = new System.Drawing.Point(188, 70);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Bỏ qua";
            this.cmdClose.Click += new System.EventHandler(this.cmdCancel_ButtonPressed);
            // 
            // FrmGetString
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(338, 112);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmGetString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập mật khẩu";
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void cmdCancel_ButtonPressed(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdOK_ButtonPressed(object sender, EventArgs e) {
            this.RetVal = this.txtString.Textbox.EditValue.ToString();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}