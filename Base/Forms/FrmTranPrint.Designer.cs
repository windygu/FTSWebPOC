namespace FTS.BaseUI.Forms
{
    partial class FrmTranPrint
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
            this.groupCommand = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.txtNoCopy = new FTS.BaseUI.Controls.FTSUpDownCom();
            this.cmdExport = new FTS.BaseUI.Controls.FTSButton();
            this.cmdImport = new FTS.BaseUI.Controls.FTSButton();
            this.cmdDelete = new FTS.BaseUI.Controls.FTSButton();
            this.cmdCopy = new FTS.BaseUI.Controls.FTSButton();
            this.cmdPreview = new FTS.BaseUI.Controls.FTSButton();
            this.cmdPrint = new FTS.BaseUI.Controls.FTSButton();
            this.listReport = new FTS.BaseUI.Controls.FTSListBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).BeginInit();
            this.groupCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 181);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(242, 40);
            this.groupBox.TabIndex = 2;
            this.groupBox.Visible = false;
            // 
            // groupCommand
            // 
            this.groupCommand.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupCommand.Appearance.Options.UseBackColor = true;
            this.groupCommand.BorderColor = System.Drawing.Color.Empty;
            this.groupCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupCommand.Controls.Add(this.txtNoCopy);
            this.groupCommand.Controls.Add(this.cmdExport);
            this.groupCommand.Controls.Add(this.cmdImport);
            this.groupCommand.Controls.Add(this.cmdDelete);
            this.groupCommand.Controls.Add(this.cmdCopy);
            this.groupCommand.Controls.Add(this.cmdPreview);
            this.groupCommand.Controls.Add(this.cmdPrint);
            this.groupCommand.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupCommand.Location = new System.Drawing.Point(242, 0);
            this.groupCommand.Name = "groupCommand";
            this.groupCommand.Size = new System.Drawing.Size(104, 221);
            this.groupCommand.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupCommand.TabIndex = 5;
            // 
            // txtNoCopy
            // 
            this.txtNoCopy.BackColor = System.Drawing.Color.Transparent;
            this.txtNoCopy.HelpText = "";
            this.txtNoCopy.IsChanged = true;
            this.txtNoCopy.LabelLength = 50;
            this.txtNoCopy.LabelText = "Copies:";
            this.txtNoCopy.Location = new System.Drawing.Point(4, 189);
            this.txtNoCopy.MaxValue = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.txtNoCopy.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNoCopy.Name = "txtNoCopy";
            this.txtNoCopy.Size = new System.Drawing.Size(96, 20);
            this.txtNoCopy.TabIndex = 4;
            this.txtNoCopy.Text = "Copies:";
            // 
            // cmdExport
            // 
            this.cmdExport.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdExport.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdExport.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdExport.Appearance.Options.UseBackColor = true;
            this.cmdExport.Appearance.Options.UseFont = true;
            this.cmdExport.Appearance.Options.UseForeColor = true;
            this.cmdExport.HelpText = "";
            this.cmdExport.Location = new System.Drawing.Point(17, 105);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(70, 22);
            this.cmdExport.TabIndex = 11;
            this.cmdExport.Text = "Kết xuất  file";
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdImport.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdImport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdImport.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdImport.Appearance.Options.UseBackColor = true;
            this.cmdImport.Appearance.Options.UseFont = true;
            this.cmdImport.Appearance.Options.UseForeColor = true;
            this.cmdImport.HelpText = "";
            this.cmdImport.Location = new System.Drawing.Point(17, 81);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(70, 22);
            this.cmdImport.TabIndex = 10;
            this.cmdImport.Text = "Nhận file";
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdDelete.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdDelete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdDelete.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdDelete.Appearance.Options.UseBackColor = true;
            this.cmdDelete.Appearance.Options.UseFont = true;
            this.cmdDelete.Appearance.Options.UseForeColor = true;
            this.cmdDelete.HelpText = "";
            this.cmdDelete.Location = new System.Drawing.Point(17, 153);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(70, 22);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "Xóa";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdCopy.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdCopy.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdCopy.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdCopy.Appearance.Options.UseBackColor = true;
            this.cmdCopy.Appearance.Options.UseFont = true;
            this.cmdCopy.Appearance.Options.UseForeColor = true;
            this.cmdCopy.HelpText = "";
            this.cmdCopy.Location = new System.Drawing.Point(17, 129);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(70, 22);
            this.cmdCopy.TabIndex = 8;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdPreview.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdPreview.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdPreview.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdPreview.Appearance.Options.UseBackColor = true;
            this.cmdPreview.Appearance.Options.UseFont = true;
            this.cmdPreview.Appearance.Options.UseForeColor = true;
            this.cmdPreview.HelpText = "";
            this.cmdPreview.Location = new System.Drawing.Point(17, 10);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(70, 22);
            this.cmdPreview.TabIndex = 6;
            this.cmdPreview.Text = "Xem";
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdPrint.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdPrint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdPrint.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdPrint.Appearance.Options.UseBackColor = true;
            this.cmdPrint.Appearance.Options.UseFont = true;
            this.cmdPrint.Appearance.Options.UseForeColor = true;
            this.cmdPrint.HelpText = "";
            this.cmdPrint.Location = new System.Drawing.Point(17, 40);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(70, 22);
            this.cmdPrint.TabIndex = 7;
            this.cmdPrint.Text = "In";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // listReport
            // 
            this.listReport.BackColor = System.Drawing.Color.Snow;
            this.listReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listReport.Location = new System.Drawing.Point(0, 0);
            this.listReport.Name = "listReport";
            this.listReport.Size = new System.Drawing.Size(242, 181);
            this.listReport.Sorted = true;
            this.listReport.TabIndex = 1;
            this.listReport.SelectedIndexChanged += new System.EventHandler(this.listReport_SelectedIndexChanged);
            // 
            // FrmTranPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(346, 221);
            this.Controls.Add(this.listReport);
            this.Controls.Add(this.groupCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTranPrint";
            this.Text = "Printing";
            this.Controls.SetChildIndex(this.groupCommand, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.listReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).EndInit();
            this.groupCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        protected FTS.BaseUI.Controls.FTSListBox listReport;
        protected FTS.BaseUI.Controls.FTSUpDownCom txtNoCopy;        
        protected Controls.FTSShadowPanel groupCommand;
        protected Controls.FTSButton cmdPrint;
        protected Controls.FTSButton cmdPreview;
        protected Controls.FTSButton cmdCopy;
        protected Controls.FTSButton cmdDelete;
        protected Controls.FTSButton cmdImport;
        protected Controls.FTSButton cmdExport;
    }
}