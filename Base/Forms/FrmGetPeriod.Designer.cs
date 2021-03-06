namespace FTS.BaseUI.Forms
{
    partial class FrmGetPeriod
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
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            this.btnOk = new FTS.BaseUI.Controls.FTSButton();
            this.cboPeriod = new FTS.BaseUI.Controls.FTSSingleComboCom();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BlankWidth = 4;
            this.groupBox.Controls.Add(this.cboPeriod);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(295, 86);
            // 
            // btnCancel
            // 
            this.btnCancel.HelpText = "";
            this.btnCancel.Location = new System.Drawing.Point(208, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.HelpText = "";
            this.btnOk.Location = new System.Drawing.Point(127, 49);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 27;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboPeriod
            // 
            this.cboPeriod.BackColor = System.Drawing.Color.Transparent;
            this.cboPeriod.HelpText = "";
            this.cboPeriod.LabelText = "Kỳ số liệu:";
            this.cboPeriod.Location = new System.Drawing.Point(12, 16);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(271, 20);
            this.cboPeriod.TabIndex = 0;
            this.cboPeriod.Text = "Kỳ số liệu:";
            // 
            // FrmGetPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 86);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGetPeriod";
            this.Text = "Chọn kỳ số liệu";
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSButton btnCancel;
        private FTS.BaseUI.Controls.FTSButton btnOk;
        private FTS.BaseUI.Controls.FTSSingleComboCom cboPeriod;
    }
}