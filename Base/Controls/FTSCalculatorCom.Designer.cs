namespace FTS.BaseUI.Controls
{
    partial class FTSCalculatorCom
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
            this.calcEdit = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEdit.Properties)).BeginInit();
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
            this.label.TabIndex = 0;
            // 
            // calcEdit
            // 
            this.calcEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcEdit.EnterMoveNextControl = true;
            this.calcEdit.Location = new System.Drawing.Point(0, 0);
            this.calcEdit.Name = "calcEdit";
            this.calcEdit.Properties.AutoHeight = false;
            this.calcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEdit.Size = new System.Drawing.Size(80, 20);
            this.calcEdit.TabIndex = 0;
            // 
            // FTSCalculatorCom
            // 
            this.Controls.Add(this.calcEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.calcEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.CalcEdit calcEdit;
    }
}
