namespace FTS.BaseUI.Controls
{
    partial class FTSMemoCom
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
            this.palLable = new DevExpress.XtraEditors.PanelControl();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.memo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.palLable)).BeginInit();
            this.palLable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // palLable
            // 
            this.palLable.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palLable.Appearance.Options.UseBackColor = true;
            this.palLable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palLable.Controls.Add(this.label);
            this.palLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.palLable.Location = new System.Drawing.Point(0, 0);
            this.palLable.Name = "palLable";
            this.palLable.Size = new System.Drawing.Size(80, 100);
            this.palLable.TabIndex = 0;
            // 
            // label
            // 
            this.label.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label.Appearance.Options.UseBackColor = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Top;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 0;
            // 
            // memo
            // 
            this.memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memo.Location = new System.Drawing.Point(80, 0);
            this.memo.Name = "memo";
            this.memo.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.memo.PromptForeColor = System.Drawing.SystemColors.GrayText;            
            this.memo.Size = new System.Drawing.Size(100, 100);
            this.memo.TabIndex = 0;
            this.memo.EditValueChanged += new System.EventHandler(this.memo_EditValueChanged);
            this.memo.Enter += new System.EventHandler(this.memo_Enter);
            // 
            // BesMemoCom
            // 
            this.Controls.Add(this.memo);
            this.Controls.Add(this.palLable);
            this.Size = new System.Drawing.Size(180, 100);
            ((System.ComponentModel.ISupportInitialize)(this.palLable)).EndInit();
            this.palLable.ResumeLayout(false);
            this.palLable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl palLable;
        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.MemoEdit memo;
    }
}
