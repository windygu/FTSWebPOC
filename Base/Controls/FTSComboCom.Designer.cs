namespace FTS.BaseUI.Controls
{
    partial class FTSComboCom
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
            this.lookUp = new FTSLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp.Properties)).BeginInit();
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
            // lookUp
            // 
            this.lookUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUp.EditValue = "";
            this.lookUp.EnterMoveNextControl = true;
            this.lookUp.Location = new System.Drawing.Point(80, 0);
            this.lookUp.Name = "lookUp";
            this.lookUp.Properties.AutoHeight = false;
            this.lookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp.Properties.NullText = "";
            this.lookUp.Properties.ShowHeader = false;
            this.lookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUp.Size = new System.Drawing.Size(80, 20);
            this.lookUp.TabIndex = 0;
            this.lookUp.Leave += new System.EventHandler(this.lookUp_Leave);
            this.lookUp.EditValueChanged += new System.EventHandler(this.lookUp_EditValueChanged);
            this.lookUp.ButtonsFooterClick += new DevExpress.XtraEditors.Controls.ButtonsFooterClickEventHandler(this.lookUp_ButtonsFooterClick);
            this.lookUp.QueryPopUp += new System.ComponentModel.CancelEventHandler(lookUp_QueryPopUp);
            this.lookUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(lookUp_KeyPress);
            this.lookUp.LostFocus += new System.EventHandler(lookUp_LostFocus);
            // 
            // FTSComboCom
            // 
            this.Controls.Add(this.lookUp);
            this.Controls.Add(this.label);
            this.lookUp.BringToFront();
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.lookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private FTSLookUpEdit lookUp;
    }
}
