namespace FTS.BaseUI.Controls
{
    partial class FTSUpDownCom
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
            this.spinEdit = new FTSSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
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
            // spinEdit
            // 
            this.spinEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit.EnterMoveNextControl = true;
            this.spinEdit.Location = new System.Drawing.Point(0, 0);
            this.spinEdit.Name = "spinEdit";
            this.spinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit.Size = new System.Drawing.Size(40, 20);
            this.spinEdit.TabIndex = 0;
            this.spinEdit.EditValueChanged += new System.EventHandler(this.spinEdit_EditValueChanged);
            this.spinEdit.Enter += new System.EventHandler(this.spinEdit_Enter);
            // 
            // FTSUpDownCom
            // 
            this.Controls.Add(this.spinEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(120, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private FTSSpinEdit spinEdit;
    }
}
