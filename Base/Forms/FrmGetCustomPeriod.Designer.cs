namespace FTS.BaseUI.Forms
{
    partial class FrmGetCustomPeriod
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
            this.txtDay_Start = new FTS.BaseUI.Controls.FTSDateCom();
            this.txtDayEnd = new FTS.BaseUI.Controls.FTSDateCom();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.BlankWidth = 4;
            this.groupBox.Controls.Add(this.txtDay_Start);
            this.groupBox.Controls.Add(this.txtDayEnd);
            this.groupBox.Controls.Add(this.btnOk);
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(324, 86);
            // 
            // btnCancel
            // 
            this.btnCancel.HelpText = "";
            this.btnCancel.Location = new System.Drawing.Point(236, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.HelpText = "";
            this.btnOk.Location = new System.Drawing.Point(155, 51);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 27;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtDay_Start
            // 
            this.txtDay_Start.BackColor = System.Drawing.Color.Transparent;
            this.txtDay_Start.HelpText = "";
            this.txtDay_Start.IsChanged = false;
            this.txtDay_Start.LabelLength = 60;
            this.txtDay_Start.LabelText = "Từ ngày:";
            this.txtDay_Start.Location = new System.Drawing.Point(12, 16);
            this.txtDay_Start.Name = "txtDay_Start";
            this.txtDay_Start.Size = new System.Drawing.Size(141, 20);
            this.txtDay_Start.TabIndex = 0;
            this.txtDay_Start.Text = "Từ ngày:";
            // 
            // txtDayEnd
            // 
            this.txtDayEnd.BackColor = System.Drawing.Color.Transparent;
            this.txtDayEnd.HelpText = "";
            this.txtDayEnd.IsChanged = false;
            this.txtDayEnd.LabelLength = 60;
            this.txtDayEnd.LabelText = "Đến ngày:";
            this.txtDayEnd.Location = new System.Drawing.Point(173, 16);
            this.txtDayEnd.Name = "txtDayEnd";
            this.txtDayEnd.Size = new System.Drawing.Size(141, 20);
            this.txtDayEnd.TabIndex = 1;
            this.txtDayEnd.Text = "Đến ngày:";
            // 
            // FrmGetCustomPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 86);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGetCustomPeriod";
            this.Text = "Chọn kỳ số liệu";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSButton btnCancel;
        private FTS.BaseUI.Controls.FTSButton btnOk;
        private FTS.BaseUI.Controls.FTSDateCom txtDay_Start;
        private FTS.BaseUI.Controls.FTSDateCom txtDayEnd;
    }
}