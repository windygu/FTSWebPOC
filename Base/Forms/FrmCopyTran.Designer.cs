namespace FTS.BaseUI.Forms
{
    partial class FrmCopyTran
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
            this.txtOrgTranId = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtNewTranId = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtNewTranName = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtOrgTranName = new FTS.BaseUI.Controls.FTSTextCom();
            this.btnOk = new FTS.BaseUI.Controls.FTSButton();
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Controls.Add(this.btnOk);
            this.groupBox.Controls.Add(this.txtOrgTranName);
            this.groupBox.Controls.Add(this.txtNewTranId);
            this.groupBox.Controls.Add(this.txtNewTranName);
            this.groupBox.Controls.Add(this.txtOrgTranId);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Size = new System.Drawing.Size(455, 109);
            // 
            // txtOrgTranId
            // 
            this.txtOrgTranId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrgTranId.LabelText = "Giao dịch gốc:";
            this.txtOrgTranId.Location = new System.Drawing.Point(8, 8);
            this.txtOrgTranId.Name = "txtOrgTranId";
            this.txtOrgTranId.Size = new System.Drawing.Size(160, 20);
            this.txtOrgTranId.TabIndex = 0;
            this.txtOrgTranId.Text = "Giao dịch gốc:";
            // 
            // txtNewTranId
            // 
            this.txtNewTranId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewTranId.LabelText = "Giao dịch mới:";
            this.txtNewTranId.Location = new System.Drawing.Point(8, 34);
            this.txtNewTranId.Name = "txtNewTranId";
            this.txtNewTranId.Size = new System.Drawing.Size(160, 20);
            this.txtNewTranId.TabIndex = 1;
            this.txtNewTranId.Text = "Giao dịch mới:";
            // 
            // txtNewTranName
            // 
            this.txtNewTranName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewTranName.LabelLength = 0;
            this.txtNewTranName.LabelText = "";
            this.txtNewTranName.Location = new System.Drawing.Point(167, 34);
            this.txtNewTranName.Name = "txtNewTranName";
            this.txtNewTranName.Size = new System.Drawing.Size(279, 20);
            this.txtNewTranName.TabIndex = 3;
            // 
            // txtOrgTranName
            // 
            this.txtOrgTranName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrgTranName.LabelLength = 0;
            this.txtOrgTranName.LabelText = "";
            this.txtOrgTranName.Location = new System.Drawing.Point(167, 8);
            this.txtOrgTranName.Name = "txtOrgTranName";
            this.txtOrgTranName.Size = new System.Drawing.Size(279, 20);
            this.txtOrgTranName.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 71);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCopyTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 109);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCopyTran";
            this.Text = "Sao chép giao dịch";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSTextCom txtOrgTranId;
        private FTS.BaseUI.Controls.FTSTextCom txtNewTranId;
        private FTS.BaseUI.Controls.FTSTextCom txtOrgTranName;
        private FTS.BaseUI.Controls.FTSTextCom txtNewTranName;
        private FTS.BaseUI.Controls.FTSButton btnCancel;
        private FTS.BaseUI.Controls.FTSButton btnOk;
    }
}