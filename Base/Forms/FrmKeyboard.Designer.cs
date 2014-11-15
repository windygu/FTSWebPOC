namespace FTS.BaseUI.Forms
{
    partial class FrmKeyboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKeyboard));
            this.palControl = new System.Windows.Forms.Panel();
            this.textMap = new DevExpress.XtraEditors.TextEdit();
            this.keyboardControl = new FTS.BaseUI.Controls.KeyboardControl();
            this.palControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textMap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // palControl
            // 
            this.palControl.BackColor = System.Drawing.Color.Transparent;
            this.palControl.Controls.Add(this.textMap);
            resources.ApplyResources(this.palControl, "palControl");
            this.palControl.Name = "palControl";
            // 
            // textMap
            // 
            resources.ApplyResources(this.textMap, "textMap");
            this.textMap.Name = "textMap";
            this.textMap.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.textMap.PromptForeColor = System.Drawing.SystemColors.GrayText;            
            this.textMap.Properties.AutoHeight = ((bool)(resources.GetObject("textMap.Properties.AutoHeight")));
            // 
            // keyboardControl
            // 
            resources.ApplyResources(this.keyboardControl, "keyboardControl");
            this.keyboardControl.Name = "keyboardControl";
            this.keyboardControl.UserKeyPressed += new FTS.BaseUI.Controls.KeyboardDelegate(this.keyboardControl_UserKeyPressed);
            // 
            // FrmKeyboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.keyboardControl);
            this.Controls.Add(this.palControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKeyboard";
            this.palControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textMap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palControl;
        private DevExpress.XtraEditors.TextEdit textMap;
        private FTS.BaseUI.Controls.KeyboardControl keyboardControl;
    }
}