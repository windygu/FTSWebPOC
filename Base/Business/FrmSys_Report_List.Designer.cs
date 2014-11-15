namespace FTS.BaseUI.Business
{
    partial class FrmSys_Report_List
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
            this.txtReport_Group_Id = new FTS.BaseUI.Controls.FTSComboCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(752, 26);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Size = new System.Drawing.Size(752, 377);
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 377);
            // 
            // palBottom
            // 
            this.palBottom.Location = new System.Drawing.Point(0, 403);
            this.palBottom.Size = new System.Drawing.Size(752, 100);
            // 
            // palRight
            // 
            this.palRight.Location = new System.Drawing.Point(585, 0);
            this.palRight.Size = new System.Drawing.Size(167, 377);
            // 
            // splitRight
            // 
            this.splitRight.Location = new System.Drawing.Point(580, 0);
            this.splitRight.Size = new System.Drawing.Size(5, 377);
            // 
            // txtReport_Group_Id
            // 
            this.txtReport_Group_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtReport_Group_Id.HelpText = "";
            this.txtReport_Group_Id.IsChanged = false;
            this.txtReport_Group_Id.LabelText = "Nhóm báo cáo";
            this.txtReport_Group_Id.Location = new System.Drawing.Point(37, 16);
            this.txtReport_Group_Id.Name = "txtReport_Group_Id";
            this.txtReport_Group_Id.Size = new System.Drawing.Size(310, 20);
            this.txtReport_Group_Id.TabIndex = 0;
            this.txtReport_Group_Id.Text = "Nhóm báo cáo";
            // 
            // FrmSys_Report_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 503);
            this.Name = "FrmSys_Report_List";
            this.Text = "FrmSys_Report_List";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FTSComboCom txtReport_Group_Id;

    }
}