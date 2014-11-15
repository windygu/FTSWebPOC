namespace FTS.AccUI.Sale
{
    partial class FrmSale
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
            this.txtPr_Detail_Id = new FTS.BaseUI.Controls.FTSNameIDCom();
            this.txtOrganization = new FTS.BaseUI.Controls.FTSNameIDCom();
            this.txtDescription = new FTS.BaseUI.Controls.FTSTextCom();
            this.DateTranDate = new FTS.BaseUI.Controls.FTSDateCom();
            this.txtTran_No = new FTS.BaseUI.Controls.FTSTextCom();
            this.groupPr_Detail = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.txtAddress = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtTax_File_Number = new FTS.BaseUI.Controls.FTSTextCom();
            this.groupVoucher = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.cmdCopyLine = new FTS.BaseUI.Controls.FTSButton();
            this.cmdDeleteLine = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).BeginInit();
            this.groupBottom0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).BeginInit();
            this.groupHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).BeginInit();
            this.palExtTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            this.palRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPr_Detail)).BeginInit();
            this.groupPr_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(674, 26);
            // 
            // palMain
            // 
            this.palMain.Size = new System.Drawing.Size(674, 462);
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.Size = new System.Drawing.Size(664, 462);
            // 
            // groupBottom
            // 
            this.groupBottom.Location = new System.Drawing.Point(0, 424);
            this.groupBottom.Size = new System.Drawing.Size(664, 10);
            // 
            // groupBottom0
            // 
            this.groupBottom0.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBottom0.Appearance.Options.UseBackColor = true;
            this.groupBottom0.Controls.Add(this.cmdDeleteLine);
            this.groupBottom0.Controls.Add(this.cmdCopyLine);
            this.groupBottom0.Location = new System.Drawing.Point(0, 434);
            this.groupBottom0.Size = new System.Drawing.Size(664, 28);
            // 
            // groupHeader
            // 
            this.groupHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupHeader.Appearance.Options.UseBackColor = true;
            this.groupHeader.Controls.Add(this.groupVoucher);
            this.groupHeader.Controls.Add(this.groupPr_Detail);
            this.groupHeader.Location = new System.Drawing.Point(0, 34);
            this.groupHeader.Size = new System.Drawing.Size(664, 146);
            this.groupHeader.TabIndex = 0;
            // 
            // groupGrid
            // 
            this.groupGrid.Location = new System.Drawing.Point(0, 180);
            this.groupGrid.Size = new System.Drawing.Size(664, 244);
            // 
            // palExtTop
            // 
            this.palExtTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palExtTop.Appearance.Options.UseBackColor = true;
            this.palExtTop.Controls.Add(this.txtOrganization);
            this.palExtTop.Size = new System.Drawing.Size(664, 34);
            // 
            // palRight
            // 
            this.palRight.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palRight.Appearance.Options.UseBackColor = true;
            this.palRight.Location = new System.Drawing.Point(664, 0);
            this.palRight.Size = new System.Drawing.Size(10, 462);
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 462);
            // 
            // txtPr_Detail_Id
            // 
            this.txtPr_Detail_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtPr_Detail_Id.HelpText = "";
            this.txtPr_Detail_Id.IsChanged = false;
            this.txtPr_Detail_Id.LabelText = "Khách hàng:";
            this.txtPr_Detail_Id.Location = new System.Drawing.Point(6, 6);
            this.txtPr_Detail_Id.Name = "txtPr_Detail_Id";
            this.txtPr_Detail_Id.Size = new System.Drawing.Size(620, 20);
            this.txtPr_Detail_Id.TabIndex = 1;
            this.txtPr_Detail_Id.Text = "Khách hàng:";
            this.txtPr_Detail_Id.TextIDLength = 108;
            this.txtPr_Detail_Id.TextNameLength = 432;
            this.txtPr_Detail_Id.Lookup += new FTS.BaseUI.Controls.LookupEventHandler(this.Control_Lookup);
            this.txtPr_Detail_Id.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtOrganization
            // 
            this.txtOrganization.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganization.HelpText = "";
            this.txtOrganization.IsChanged = false;
            this.txtOrganization.LabelText = "Tổ chức :";
            this.txtOrganization.Location = new System.Drawing.Point(15, 9);
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Size = new System.Drawing.Size(620, 20);
            this.txtOrganization.TabIndex = 0;
            this.txtOrganization.Text = "Tổ chức :";
            this.txtOrganization.TextIDLength = 107;
            this.txtOrganization.TextNameLength = 433;
            this.txtOrganization.Lookup += new FTS.BaseUI.Controls.LookupEventHandler(this.Control_Lookup);
            this.txtOrganization.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.HelpText = "";
            this.txtDescription.LabelText = "Ghi chú :";
            this.txtDescription.Location = new System.Drawing.Point(6, 74);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(620, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Ghi chú :";
            // 
            // DateTranDate
            // 
            this.DateTranDate.BackColor = System.Drawing.Color.Transparent;
            this.DateTranDate.HelpText = "";
            this.DateTranDate.IsChanged = false;
            this.DateTranDate.LabelText = "Ngày hđơn :";
            this.DateTranDate.Location = new System.Drawing.Point(215, 10);
            this.DateTranDate.Name = "DateTranDate";
            this.DateTranDate.Size = new System.Drawing.Size(183, 20);
            this.DateTranDate.TabIndex = 1;
            this.DateTranDate.Text = "Ngày hđơn :";
            // 
            // txtTran_No
            // 
            this.txtTran_No.BackColor = System.Drawing.Color.Transparent;
            this.txtTran_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTran_No.HelpText = "";
            this.txtTran_No.LabelText = "Số hóa đơn :";
            this.txtTran_No.Location = new System.Drawing.Point(6, 10);
            this.txtTran_No.Name = "txtTran_No";
            this.txtTran_No.Size = new System.Drawing.Size(188, 20);
            this.txtTran_No.TabIndex = 0;
            this.txtTran_No.Text = "Số hóa đơn :";
            // 
            // groupPr_Detail
            // 
            this.groupPr_Detail.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupPr_Detail.Appearance.Options.UseBackColor = true;
            this.groupPr_Detail.BorderColor = System.Drawing.Color.Empty;
            this.groupPr_Detail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupPr_Detail.Controls.Add(this.txtPr_Detail_Id);
            this.groupPr_Detail.Controls.Add(this.txtAddress);
            this.groupPr_Detail.Controls.Add(this.txtTax_File_Number);
            this.groupPr_Detail.Controls.Add(this.txtDescription);
            this.groupPr_Detail.Location = new System.Drawing.Point(9, 43);
            this.groupPr_Detail.Name = "groupPr_Detail";
            this.groupPr_Detail.Size = new System.Drawing.Size(640, 97);
            this.groupPr_Detail.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupPr_Detail.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAddress.HelpText = "";
            this.txtAddress.LabelText = "Địa chỉ:";
            this.txtAddress.Location = new System.Drawing.Point(6, 29);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(620, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "Địa chỉ:";
            // 
            // txtTax_File_Number
            // 
            this.txtTax_File_Number.BackColor = System.Drawing.Color.Transparent;
            this.txtTax_File_Number.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTax_File_Number.HelpText = "";
            this.txtTax_File_Number.LabelText = "Mã số thuế:";
            this.txtTax_File_Number.Location = new System.Drawing.Point(6, 52);
            this.txtTax_File_Number.Name = "txtTax_File_Number";
            this.txtTax_File_Number.Size = new System.Drawing.Size(620, 20);
            this.txtTax_File_Number.TabIndex = 4;
            this.txtTax_File_Number.Text = "Mã số thuế:";
            // 
            // groupVoucher
            // 
            this.groupVoucher.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupVoucher.Appearance.Options.UseBackColor = true;
            this.groupVoucher.BorderColor = System.Drawing.Color.Empty;
            this.groupVoucher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupVoucher.Controls.Add(this.txtTran_No);
            this.groupVoucher.Controls.Add(this.DateTranDate);
            this.groupVoucher.Location = new System.Drawing.Point(9, 5);
            this.groupVoucher.Name = "groupVoucher";
            this.groupVoucher.Size = new System.Drawing.Size(640, 38);
            this.groupVoucher.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupVoucher.TabIndex = 2;
            // 
            // cmdCopyLine
            // 
            this.cmdCopyLine.HelpText = "";
            this.cmdCopyLine.Location = new System.Drawing.Point(7, 2);
            this.cmdCopyLine.Name = "cmdCopyLine";
            this.cmdCopyLine.Size = new System.Drawing.Size(69, 23);
            this.cmdCopyLine.TabIndex = 1;
            this.cmdCopyLine.Text = "Thêm dòng";
            this.cmdCopyLine.Click += new System.EventHandler(this.cmdCopyLine_Click);
            // 
            // cmdDeleteLine
            // 
            this.cmdDeleteLine.HelpText = "";
            this.cmdDeleteLine.Location = new System.Drawing.Point(82, 2);
            this.cmdDeleteLine.Name = "cmdDeleteLine";
            this.cmdDeleteLine.Size = new System.Drawing.Size(69, 23);
            this.cmdDeleteLine.TabIndex = 2;
            this.cmdDeleteLine.Text = "Xóa dòng";
            this.cmdDeleteLine.Click += new System.EventHandler(this.cmdDeleteLine_Click);
            // 
            // FrmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 488);
            this.Name = "FrmSale";
            this.Text = "FrmSale";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).EndInit();
            this.groupBottom0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).EndInit();
            this.groupHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).EndInit();
            this.palExtTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            this.palRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPr_Detail)).EndInit();
            this.groupPr_Detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSDateCom DateTranDate;
        private FTS.BaseUI.Controls.FTSTextCom txtTran_No;
        private FTS.BaseUI.Controls.FTSNameIDCom txtOrganization;
        private FTS.BaseUI.Controls.FTSNameIDCom txtPr_Detail_Id;
        private FTS.BaseUI.Controls.FTSTextCom txtDescription;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupPr_Detail;
        private BaseUI.Controls.FTSShadowPanel groupVoucher;
        private BaseUI.Controls.FTSTextCom txtTax_File_Number;
        private BaseUI.Controls.FTSTextCom txtAddress;
        private BaseUI.Controls.FTSButton cmdCopyLine;
        private BaseUI.Controls.FTSButton cmdDeleteLine;
    }
}