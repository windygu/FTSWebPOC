namespace FTS.BaseUI.Controls
{
    partial class FTSAccountDoubleCom
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpAccount = new DevExpress.XtraEditors.GroupControl();
            this.CreditId = new DevExpress.XtraEditors.LabelControl();
            this.DebtId = new DevExpress.XtraEditors.LabelControl();
            this.txtCredit = new DevExpress.XtraEditors.LabelControl();
            this.txtDebt = new DevExpress.XtraEditors.LabelControl();
            this.lblCredit = new DevExpress.XtraEditors.LabelControl();
            this.lblDebt = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpAccount)).BeginInit();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(this.CreditId);
            this.grpAccount.Controls.Add(this.DebtId);
            this.grpAccount.Controls.Add(this.txtCredit);
            this.grpAccount.Controls.Add(this.txtDebt);
            this.grpAccount.Controls.Add(this.lblCredit);
            this.grpAccount.Controls.Add(this.lblDebt);
            this.grpAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAccount.Location = new System.Drawing.Point(0, 0);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(202, 100);
            this.grpAccount.TabIndex = 0;
            // 
            // CreditId
            // 
            this.CreditId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CreditId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.CreditId.Location = new System.Drawing.Point(196, 62);
            this.CreditId.Name = "CreditId";
            this.CreditId.Size = new System.Drawing.Size(0, 18);
            this.CreditId.TabIndex = 5;
            this.CreditId.TextChanged += new System.EventHandler(this.CreditId_TextChanged);
            // 
            // DebtId
            // 
            this.DebtId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DebtId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.DebtId.Location = new System.Drawing.Point(196, 23);
            this.DebtId.Name = "DebtId";
            this.DebtId.Size = new System.Drawing.Size(0, 18);
            this.DebtId.TabIndex = 4;
            this.DebtId.TextChanged += new System.EventHandler(this.DebtId_TextChanged);
            // 
            // txtCredit
            // 
            this.txtCredit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtCredit.Location = new System.Drawing.Point(30, 65);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(160, 0);
            this.txtCredit.TabIndex = 3;
            // 
            // txtDebt
            // 
            this.txtDebt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtDebt.Location = new System.Drawing.Point(30, 29);
            this.txtDebt.Name = "txtDebt";
            this.txtDebt.Size = new System.Drawing.Size(160, 0);
            this.txtDebt.TabIndex = 2;
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblCredit.Location = new System.Drawing.Point(10, 65);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(8, 26);
            this.lblCredit.TabIndex = 1;
            this.lblCredit.Text = "Có";
            // 
            // lblDebt
            // 
            this.lblDebt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblDebt.Location = new System.Drawing.Point(10, 29);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(8, 26);
            this.lblDebt.TabIndex = 0;
            this.lblDebt.Text = "Nợ";
            // 
            // FTSAccountDoubleCom
            // 
            this.Controls.Add(this.grpAccount);
            this.Name = "FTSAccountDoubleCom";
            this.Size = new System.Drawing.Size(202, 100);
            ((System.ComponentModel.ISupportInitialize)(this.grpAccount)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpAccount;
        private DevExpress.XtraEditors.LabelControl lblDebt;
        private DevExpress.XtraEditors.LabelControl lblCredit;
        private DevExpress.XtraEditors.LabelControl txtCredit;
        private DevExpress.XtraEditors.LabelControl txtDebt;
        private DevExpress.XtraEditors.LabelControl DebtId;
        private DevExpress.XtraEditors.LabelControl CreditId;
    }
}
