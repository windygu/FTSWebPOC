using DevExpress.XtraEditors;

namespace FTS.BaseUI.Controls {
    partial class FTSPercentCom {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.txtPercent = new FTSNumericTextBox();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.txtAmount = new FTSNumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label.Appearance.Options.UseBackColor = true;
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(80, 20);
            this.label.TabIndex = 1;
            this.label.Text = "label";
            // 
            // txtPercent
            // 
            this.txtPercent.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPercent.EditValue = "";
            this.txtPercent.EnterMoveNextControl = true;
            this.txtPercent.Location = new System.Drawing.Point(80, 0);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Properties.AutoHeight = false;
            this.txtPercent.Size = new System.Drawing.Size(25, 20);
            this.txtPercent.TabIndex = 2;
            // 
            // lblPercent
            // 
            this.lblPercent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.Options.UseBackColor = true;
            this.lblPercent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPercent.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPercent.Location = new System.Drawing.Point(101, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(19, 20);
            this.lblPercent.TabIndex = 3;
            this.lblPercent.Text = "%";
            // 
            // txtAmount
            // 
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.EditValue = "";
            this.txtAmount.EnterMoveNextControl = true;
            this.txtAmount.Location = new System.Drawing.Point(112, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Size = new System.Drawing.Size(110, 20);
            this.txtAmount.TabIndex = 4;
            // 
            // FTSVatCom
            // 
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.label);
            this.Name = "FTSVatCom";
            this.Size = new System.Drawing.Size(226, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        public FTSNumericTextBox txtPercent;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        public FTSNumericTextBox txtAmount;
    }
}
