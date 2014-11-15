namespace FTS.AccUI.Sale
{
    partial class FrmSale_Listing
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
            this.cboDataPeriod = new FTS.BaseUI.Controls.FTSSingleComboCom();
            this.txtDay_Start = new FTS.BaseUI.Controls.FTSDateCom();
            this.txtDay_End = new FTS.BaseUI.Controls.FTSDateCom();
            this.cmdFind = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).BeginInit();
            this.groupGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).BeginInit();
            this.palGrid2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl.Appearance.Options.UseBackColor = true;
            this.groupControl.Controls.Add(this.cmdFind);
            this.groupControl.Controls.Add(this.cboDataPeriod);
            this.groupControl.Controls.Add(this.txtDay_Start);
            this.groupControl.Controls.Add(this.txtDay_End);
            this.groupControl.Size = new System.Drawing.Size(727, 34);
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(923, 26);
            // 
            // groupGrid
            // 
            this.groupGrid.Size = new System.Drawing.Size(923, 356);
            // 
            // palMain
            // 
            this.palMain.Size = new System.Drawing.Size(923, 356);
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.Size = new System.Drawing.Size(727, 356);
            // 
            // groupBottom
            // 
            this.groupBottom.Size = new System.Drawing.Size(727, 68);
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Size = new System.Drawing.Size(727, 47);
            // 
            // palLeft
            // 
            this.palLeft.Appearance.BackColor = System.Drawing.SystemColors.Control;
            // 
            // groupGrid2
            // 
            this.groupGrid2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupGrid2.Appearance.Options.UseBackColor = true;
            this.groupGrid2.Location = new System.Drawing.Point(0, 47);
            this.groupGrid2.Size = new System.Drawing.Size(727, 241);
            // 
            // splitGrid
            // 
            this.splitGrid.Location = new System.Drawing.Point(555, 0);
            this.splitGrid.Size = new System.Drawing.Size(5, 241);
            // 
            // palGrid2
            // 
            this.palGrid2.Location = new System.Drawing.Point(560, 0);
            this.palGrid2.Size = new System.Drawing.Size(167, 241);
            // 
            // scrollGrid
            // 
            this.scrollGrid.Size = new System.Drawing.Size(17, 241);
            // 
            // cboDataPeriod
            // 
            this.cboDataPeriod.BackColor = System.Drawing.Color.Transparent;
            this.cboDataPeriod.HelpText = "";
            this.cboDataPeriod.LabelLength = 70;
            this.cboDataPeriod.LabelText = "Kỳ số liệu:";
            this.cboDataPeriod.Location = new System.Drawing.Point(12, 6);
            this.cboDataPeriod.Name = "cboDataPeriod";
            this.cboDataPeriod.Size = new System.Drawing.Size(189, 20);
            this.cboDataPeriod.TabIndex = 17;
            this.cboDataPeriod.Text = "Kỳ số liệu:";
            this.cboDataPeriod.ComboChange += new FTS.BaseUI.Controls.ComboChangedEventHandler(this.cboDataPeriod_ComboChange);
            // 
            // txtDay_Start
            // 
            this.txtDay_Start.BackColor = System.Drawing.Color.Transparent;
            this.txtDay_Start.HelpText = "";
            this.txtDay_Start.IsChanged = false;
            this.txtDay_Start.LabelLength = 70;
            this.txtDay_Start.LabelText = "Từ ngày:";
            this.txtDay_Start.Location = new System.Drawing.Point(210, 6);
            this.txtDay_Start.Name = "txtDay_Start";
            this.txtDay_Start.Size = new System.Drawing.Size(146, 20);
            this.txtDay_Start.TabIndex = 15;
            this.txtDay_Start.Text = "Từ ngày:";
            this.txtDay_Start.Leave += new System.EventHandler(this.txtDay_Start_Leave);
            // 
            // txtDay_End
            // 
            this.txtDay_End.BackColor = System.Drawing.Color.Transparent;
            this.txtDay_End.HelpText = "";
            this.txtDay_End.IsChanged = false;
            this.txtDay_End.LabelLength = 70;
            this.txtDay_End.LabelText = "Đến ngày:";
            this.txtDay_End.Location = new System.Drawing.Point(368, 6);
            this.txtDay_End.Name = "txtDay_End";
            this.txtDay_End.Size = new System.Drawing.Size(146, 20);
            this.txtDay_End.TabIndex = 16;
            this.txtDay_End.Text = "Đến ngày:";
            this.txtDay_End.Leave += new System.EventHandler(this.txtDay_End_Leave);
            // 
            // cmdFind
            // 
            this.cmdFind.HelpText = "";
            this.cmdFind.Location = new System.Drawing.Point(543, 6);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(89, 22);
            this.cmdFind.TabIndex = 31;
            this.cmdFind.Text = "Tìm kiếm";
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // FrmSale_Listing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 382);
            this.Name = "FrmSale_Listing";
            this.Text = "FrmSale_Listing";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).EndInit();
            this.groupGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).EndInit();
            this.palGrid2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void txtDay_End_Leave(object sender, System.EventArgs e)
        {
            this.Filter();
        }

        void txtDay_Start_Leave(object sender, System.EventArgs e)
        {
            this.Filter();
        }

        #endregion

        private FTS.BaseUI.Controls.FTSSingleComboCom cboDataPeriod;
        private FTS.BaseUI.Controls.FTSDateCom txtDay_Start;
        private FTS.BaseUI.Controls.FTSDateCom txtDay_End;
        private BaseUI.Controls.FTSButton cmdFind;
    }
}