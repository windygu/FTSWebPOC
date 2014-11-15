namespace FTS.BaseUI.Controls
{
    partial class FTSFreeComboCom
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
            this.mruEdit = new DevExpress.XtraEditors.MRUEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mruEdit.Properties)).BeginInit();
            this.SuspendLayout();
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
            // mruEdit
            // 
            this.mruEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mruEdit.EnterMoveNextControl = true;
            this.mruEdit.Location = new System.Drawing.Point(0, 0);
            this.mruEdit.Name = "mruEdit";
            this.mruEdit.Properties.AutoHeight = false;
            this.mruEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mruEdit.Size = new System.Drawing.Size(100, 20);
            this.mruEdit.TabIndex = 0;
            // 
            // FTSFreeComboCom
            // 
            this.Controls.Add(this.mruEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            ((System.ComponentModel.ISupportInitialize)(this.mruEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.MRUEdit mruEdit;
    }
}
