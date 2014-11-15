namespace FTS.BaseUI.Controls
{
    partial class FTSTextCom
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
            this.textEdit = new FTSTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
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
            // FTSTextCom
            // 
            this.Controls.Add(this.textEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private FTSTextBox textEdit;
    }
}
