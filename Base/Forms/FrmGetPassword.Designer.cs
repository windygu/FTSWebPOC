namespace FTS.BaseUI.Forms
{
    partial class FrmGetPassword
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
            this.txtPassword = new FTS.BaseUI.Controls.FTSTextCom();
            this.btnOk = new FTS.BaseUI.Controls.FTSButton();
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.LabelLength = 100;
            this.txtPassword.LabelText = "Mật khẩu:";
            this.txtPassword.Location = new System.Drawing.Point(12, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(241, 20);
            this.txtPassword.TabIndex = 24;
            this.txtPassword.Text = "Mật khẩu:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(97, 50);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(178, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmGetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 88);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGetPassword";
            this.Text = "Nhập mật khẩu";
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSTextCom txtPassword;
        private FTS.BaseUI.Controls.FTSButton btnOk;
        private FTS.BaseUI.Controls.FTSButton btnCancel;
    }
}