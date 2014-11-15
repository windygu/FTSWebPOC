namespace FTS.BaseUI.ImportData {
    partial class FrmImportExcel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupCommand = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.listTemplate = new FTS.BaseUI.Controls.FTSListBox();
            this.cmdCreateTemplate = new FTS.BaseUI.Controls.FTSButton();
            this.cmdEdit = new FTS.BaseUI.Controls.FTSButton();
            this.cmdCopy = new FTS.BaseUI.Controls.FTSButton();
            this.cmdImport = new FTS.BaseUI.Controls.FTSButton();
            this.cmdExport = new FTS.BaseUI.Controls.FTSButton();
            this.cmdDelete = new FTS.BaseUI.Controls.FTSButton();
            this.txtExcelFile = new FTS.BaseUI.Controls.FTSTextCom();
            this.btnExcelFile = new FTS.BaseUI.Controls.FTSButton();
            this.cmdCreateExcel = new FTS.BaseUI.Controls.FTSButton();
            this.cmdLoadData = new FTS.BaseUI.Controls.FTSButton();
            this.btnOk = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).BeginInit();
            this.groupGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).BeginInit();
            this.palGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).BeginInit();
            this.groupCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.Location = new System.Drawing.Point(0, 78);
            this.groupGrid.Size = new System.Drawing.Size(783, 385);
            // 
            // palMain
            // 
            this.palMain.Size = new System.Drawing.Size(783, 385);
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.Size = new System.Drawing.Size(587, 385);
            // 
            // groupBottom
            // 
            this.groupBottom.Location = new System.Drawing.Point(0, 371);
            this.groupBottom.Size = new System.Drawing.Size(587, 14);
            // 
            // groupBox
            // 
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 360);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.Size = new System.Drawing.Size(587, 11);
            this.groupBox.TabIndex = 2;
            // 
            // palLeft
            // 
            this.palLeft.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palLeft.Size = new System.Drawing.Size(196, 385);
            // 
            // groupGrid2
            // 
            this.groupGrid2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupGrid2.Appearance.Options.UseBackColor = true;
            this.groupGrid2.Location = new System.Drawing.Point(0, 0);
            this.groupGrid2.Size = new System.Drawing.Size(587, 360);
            // 
            // splitGrid
            // 
            this.splitGrid.Location = new System.Drawing.Point(415, 0);
            this.splitGrid.Size = new System.Drawing.Size(5, 360);
            // 
            // palGrid2
            // 
            this.palGrid2.Location = new System.Drawing.Point(420, 0);
            this.palGrid2.Size = new System.Drawing.Size(167, 360);
            // 
            // scrollGrid
            // 
            this.scrollGrid.Size = new System.Drawing.Size(17, 360);
            // 
            // groupCommand
            // 
            this.groupCommand.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupCommand.Appearance.Options.UseBackColor = true;
            this.groupCommand.BorderColor = System.Drawing.Color.Empty;
            this.groupCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupCommand.Controls.Add(this.listTemplate);
            this.groupCommand.Controls.Add(this.cmdCreateTemplate);
            this.groupCommand.Controls.Add(this.cmdEdit);
            this.groupCommand.Controls.Add(this.cmdCopy);
            this.groupCommand.Controls.Add(this.cmdImport);
            this.groupCommand.Controls.Add(this.cmdExport);
            this.groupCommand.Controls.Add(this.cmdDelete);
            this.groupCommand.Controls.Add(this.txtExcelFile);
            this.groupCommand.Controls.Add(this.btnExcelFile);
            this.groupCommand.Controls.Add(this.cmdCreateExcel);
            this.groupCommand.Controls.Add(this.cmdLoadData);
            this.groupCommand.Controls.Add(this.btnOk);
            this.groupCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupCommand.Location = new System.Drawing.Point(0, 0);
            this.groupCommand.Name = "groupCommand";
            this.groupCommand.Size = new System.Drawing.Size(783, 78);
            this.groupCommand.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupCommand.TabIndex = 5;
            // 
            // listTemplate
            // 
            this.listTemplate.BackColor = System.Drawing.Color.Snow;
            this.listTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listTemplate.Location = new System.Drawing.Point(8, 3);
            this.listTemplate.Name = "listTemplate";
            this.listTemplate.Size = new System.Drawing.Size(188, 67);
            this.listTemplate.Sorted = true;
            this.listTemplate.TabIndex = 1;
            // 
            // cmdCreateTemplate
            // 
            this.cmdCreateTemplate.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdCreateTemplate.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdCreateTemplate.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdCreateTemplate.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdCreateTemplate.Appearance.Options.UseBackColor = true;
            this.cmdCreateTemplate.Appearance.Options.UseFont = true;
            this.cmdCreateTemplate.Appearance.Options.UseForeColor = true;
            this.cmdCreateTemplate.HelpText = "";
            this.cmdCreateTemplate.Location = new System.Drawing.Point(202, 3);
            this.cmdCreateTemplate.Name = "cmdCreateTemplate";
            this.cmdCreateTemplate.Size = new System.Drawing.Size(100, 22);
            this.cmdCreateTemplate.TabIndex = 44;
            this.cmdCreateTemplate.Text = "Tạo khai báo";
            this.cmdCreateTemplate.Click += new System.EventHandler(this.cmdCreateTemplate_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdEdit.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdEdit.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdEdit.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdEdit.Appearance.Options.UseBackColor = true;
            this.cmdEdit.Appearance.Options.UseFont = true;
            this.cmdEdit.Appearance.Options.UseForeColor = true;
            this.cmdEdit.HelpText = "";
            this.cmdEdit.Location = new System.Drawing.Point(202, 27);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 22);
            this.cmdEdit.TabIndex = 6;
            this.cmdEdit.Text = "Sửa khai báo";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
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
            this.cmdCopy.Location = new System.Drawing.Point(202, 50);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(100, 22);
            this.cmdCopy.TabIndex = 8;
            this.cmdCopy.Text = "Copy khai báo";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
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
            this.cmdImport.Location = new System.Drawing.Point(306, 3);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(100, 22);
            this.cmdImport.TabIndex = 10;
            this.cmdImport.Text = "Nhận khai báo";
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
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
            this.cmdExport.Location = new System.Drawing.Point(306, 27);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(100, 22);
            this.cmdExport.TabIndex = 11;
            this.cmdExport.Text = "Kết xuất  khai báo";
            this.cmdExport.Click += new System.EventHandler(this.cmdSaleFile_Click);
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
            this.cmdDelete.Location = new System.Drawing.Point(306, 50);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 22);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "Xóa khai báo";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFile.BackColor = System.Drawing.Color.Transparent;
            this.txtExcelFile.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtExcelFile.HelpText = "";
            this.txtExcelFile.LabelLength = 90;
            this.txtExcelFile.LabelText = "File Excel dữ liệu";
            this.txtExcelFile.Location = new System.Drawing.Point(463, 8);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(281, 21);
            this.txtExcelFile.TabIndex = 38;
            this.txtExcelFile.Text = "File Excel dữ liệu";
            // 
            // btnExcelFile
            // 
            this.btnExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelFile.HelpText = "";
            this.btnExcelFile.Location = new System.Drawing.Point(747, 7);
            this.btnExcelFile.Name = "btnExcelFile";
            this.btnExcelFile.Size = new System.Drawing.Size(24, 23);
            this.btnExcelFile.TabIndex = 39;
            this.btnExcelFile.Text = "...";
            this.btnExcelFile.Click += new System.EventHandler(this.btnExcelFile_Click);
            // 
            // cmdCreateExcel
            // 
            this.cmdCreateExcel.Appearance.BackColor = System.Drawing.Color.FloralWhite;
            this.cmdCreateExcel.Appearance.BackColor2 = System.Drawing.Color.OldLace;
            this.cmdCreateExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdCreateExcel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdCreateExcel.Appearance.Options.UseBackColor = true;
            this.cmdCreateExcel.Appearance.Options.UseFont = true;
            this.cmdCreateExcel.Appearance.Options.UseForeColor = true;
            this.cmdCreateExcel.HelpText = "";
            this.cmdCreateExcel.Location = new System.Drawing.Point(463, 35);
            this.cmdCreateExcel.Name = "cmdCreateExcel";
            this.cmdCreateExcel.Size = new System.Drawing.Size(100, 22);
            this.cmdCreateExcel.TabIndex = 43;
            this.cmdCreateExcel.Text = "Tạo file excel";
            this.cmdCreateExcel.Click += new System.EventHandler(this.cmdCreateExcel_Click);
            // 
            // cmdLoadData
            // 
            this.cmdLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadData.HelpText = "";
            this.cmdLoadData.Location = new System.Drawing.Point(608, 37);
            this.cmdLoadData.Name = "cmdLoadData";
            this.cmdLoadData.Size = new System.Drawing.Size(75, 23);
            this.cmdLoadData.TabIndex = 42;
            this.cmdLoadData.Text = "Xem dữ liệu";
            this.cmdLoadData.Click += new System.EventHandler(this.cmdLoadData_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.HelpText = "";
            this.btnOk.Location = new System.Drawing.Point(692, 37);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "Nhận dữ liệu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(783, 463);
            this.Controls.Add(this.groupCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportExcel";
            this.Text = "Nhận dữ liệu từ Excel";
            this.Controls.SetChildIndex(this.groupCommand, 0);
            this.Controls.SetChildIndex(this.groupGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).EndInit();
            this.groupGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).EndInit();
            this.palGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).EndInit();
            this.groupCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        protected FTS.BaseUI.Controls.FTSShadowPanel groupCommand;
        protected FTS.BaseUI.Controls.FTSListBox listTemplate;
        protected FTS.BaseUI.Controls.FTSButton cmdEdit;
        protected FTS.BaseUI.Controls.FTSButton cmdCopy;
        protected FTS.BaseUI.Controls.FTSButton cmdDelete;
        protected FTS.BaseUI.Controls.FTSButton cmdImport;
        protected FTS.BaseUI.Controls.FTSButton cmdExport;
        private FTS.BaseUI.Controls.FTSButton btnExcelFile;
        private FTS.BaseUI.Controls.FTSTextCom txtExcelFile;
        private FTS.BaseUI.Controls.FTSButton btnOk;
        private FTS.BaseUI.Controls.FTSButton cmdLoadData;
        protected FTS.BaseUI.Controls.FTSButton cmdCreateExcel;
        protected FTS.BaseUI.Controls.FTSButton cmdCreateTemplate;
    }
}