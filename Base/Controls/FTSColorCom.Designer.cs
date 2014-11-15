namespace FTS.BaseUI.Controls
{
    partial class FTSColorCom
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
            this.colorEdit = new DevExpress.XtraEditors.ColorEdit();
            this.label = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colorEdit
            // 
            this.colorEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorEdit.EnterMoveNextControl = true;
            this.colorEdit.Location = new System.Drawing.Point(80, 0);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.colorEdit.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.colorEdit.PromptText = string.Empty;
            this.colorEdit.Properties.AutoHeight = false;
            this.colorEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit.Size = new System.Drawing.Size(80, 20);
            this.colorEdit.TabIndex = 0;
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
            this.label.TabIndex = 0;
            // 
            // BesColorCom
            // 
            this.Controls.Add(this.colorEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ColorEdit colorEdit;
        private DevExpress.XtraEditors.LabelControl label;
    }
}
