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
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmGetDate : FrmBaseForm {
        private IContainer components = null;
        private FTSDateCom txtDate;
        private FTSButton cmdOK;
        private FTSButton cmdClose;
        public DateTime RetVal = DateTime.Today;

        public FrmGetDate(FTSMain ftsmain, string title, string label) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout();
            this.Text = title;
            this.txtDate.LabelText = label;
            this.txtDate.DateTime.EditValue = DateTime.Today;
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
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BlankWidth = 2;
            this.groupBox.Controls.Add(this.txtDate);
            this.groupBox.Controls.Add(this.cmdOK);
            this.groupBox.Controls.Add(this.cmdClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.Size = new System.Drawing.Size(292, 112);
            this.groupBox.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.Transparent;
            this.txtDate.HelpText = "";
            this.txtDate.IsChanged = false;
            this.txtDate.LabelLength = 140;
            this.txtDate.LabelText = "Mật khẩu:";
            this.txtDate.Location = new System.Drawing.Point(17, 29);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(260, 20);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "Mật khẩu:";
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
            this.cmdOK.Location = new System.Drawing.Point(53, 70);
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
            this.cmdClose.Location = new System.Drawing.Point(165, 70);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Bỏ qua";
            this.cmdClose.Click += new System.EventHandler(this.cmdCancel_ButtonPressed);
            // 
            // FrmGetDate
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(292, 112);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmGetDate";
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
            this.RetVal = (DateTime) this.txtDate.DateTime.EditValue;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}