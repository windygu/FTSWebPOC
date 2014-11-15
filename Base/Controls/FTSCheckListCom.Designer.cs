namespace FTS.BaseUI.Controls
{
    partial class FTSCheckListCom
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
            this.popupEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.label = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit
            // 
            this.popupEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupEdit.EditValue = null;
            this.popupEdit.EnterMoveNextControl = true;
            this.popupEdit.Location = new System.Drawing.Point(80, 0);
            this.popupEdit.Name = "dateEdit";
            this.popupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.popupEdit.Properties.AutoHeight = false;
            this.popupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupEdit.Size = new System.Drawing.Size(80, 20);
            this.popupEdit.TabIndex = 0;
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
            // ESoftCheckListCom
            // 
            this.Controls.Add(this.popupEdit);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit popupEdit;
        private DevExpress.XtraEditors.LabelControl label;
    }
}
