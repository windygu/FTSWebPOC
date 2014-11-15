namespace FTS.BaseUI.Business
{
    partial class FrmSys_Report_EditList
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
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).BeginInit();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupGrid.Appearance.Options.UseBackColor = true;
            this.groupGrid.Location = new System.Drawing.Point(0, 96);
            this.groupGrid.Size = new System.Drawing.Size(752, 354);
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.txtReport_Group_Id);
            this.groupBox.Location = new System.Drawing.Point(0, 450);
            this.groupBox.Size = new System.Drawing.Size(752, 53);
            this.groupBox.Visible = true;
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 354);
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
            this.txtReport_Group_Id.ComboChange += new System.EventHandler(this.txtReport_Group_Id_ComboChange);
            // 
            // FrmSys_Report_EditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 503);
            this.Name = "FrmSys_Report_EditList";
            this.Text = "FrmSys_Report_EditList";
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FTSComboCom txtReport_Group_Id;

    }
}