namespace FTS.BaseUI.Controls
{
    partial class FTSCheckCom
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
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.checkbox = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label.Appearance.Options.UseBackColor = true;
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(106, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Active";
            // 
            // checkbox
            // 
            this.checkbox.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkbox.Location = new System.Drawing.Point(106, 0);
            this.checkbox.Name = "checkbox";
            this.checkbox.Properties.AutoHeight = false;
            this.checkbox.Properties.Caption = "";
            this.checkbox.Size = new System.Drawing.Size(20, 20);
            this.checkbox.TabIndex = 0;
            // 
            // FTSCheckCom
            // 
            this.Controls.Add(this.label);
            this.Controls.Add(this.checkbox);
            this.Name = "FTSCheckCom";
            this.Size = new System.Drawing.Size(126, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.checkbox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.CheckEdit checkbox;
    }
}
