namespace FTS.BaseUI.Controls
{
    partial class FTSSingleComboCom
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
            this.comboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).BeginInit();
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
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox.EnterMoveNextControl = true;
            this.comboBox.Location = new System.Drawing.Point(80, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboBox.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBox.PromptText = "";
            this.comboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBox.Size = new System.Drawing.Size(80, 20);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboSelectedIndexChange);
            // 
            // FTSSingleComboCom
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.ComboBoxEdit comboBox;
    }
}
