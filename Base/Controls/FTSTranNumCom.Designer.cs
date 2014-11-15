namespace FTS.BaseUI.Controls
{
    partial class FTSTranNumCom
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
            this.textEdit = new DevExpress.XtraEditors.TextEdit();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.btnConfig = new FTS.BaseUI.Controls.FTSButton();
            this.lblTranNoTemp = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit
            // 
            this.textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit.EditValue = "";
            this.textEdit.EnterMoveNextControl = true;
            this.textEdit.Location = new System.Drawing.Point(80, 0);
            this.textEdit.Name = "textEdit";
            this.textEdit.Properties.AutoHeight = false;
            this.textEdit.Size = new System.Drawing.Size(80, 20);
            this.textEdit.TabIndex = 0;
            this.textEdit.EditValueChanged += new System.EventHandler(this.Textbox_EditValueChanged);
            this.textEdit.Enter += new System.EventHandler(this.Textbox_Enter);
            // 
            // label
            // 
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(80, 20);
            this.label.TabIndex = 0;
            // 
            // btnConfig
            // 
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfig.Location = new System.Drawing.Point(160, 0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(20, 20);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "...";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // lblTranNoTemp
            // 
            this.lblTranNoTemp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTranNoTemp.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTranNoTemp.Location = new System.Drawing.Point(180, 0);
            this.lblTranNoTemp.Name = "lblTranNoTemp";
            this.lblTranNoTemp.Size = new System.Drawing.Size(0, 20);
            this.lblTranNoTemp.TabIndex = 0;
            // 
            // FTSTranNumCom
            // 
            this.Controls.Add(this.textEdit);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.lblTranNoTemp);
            this.Size = new System.Drawing.Size(180, 20);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit;
        private DevExpress.XtraEditors.LabelControl label;
        private FTS.BaseUI.Controls.FTSButton btnConfig;
        private DevExpress.XtraEditors.LabelControl lblTranNoTemp;
    }
}
