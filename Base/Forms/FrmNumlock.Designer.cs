namespace FTS.BaseUI.Forms
{
    partial class FrmNumlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNumlock));
            this.palControl = new System.Windows.Forms.Panel();
            this.textMap = new DevExpress.XtraEditors.TextEdit();
            this.numlockControl = new FTS.BaseUI.Controls.NumlockControl();
            this.palAction = new System.Windows.Forms.Panel();
            this.btnSub = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.palControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textMap.Properties)).BeginInit();
            this.palAction.SuspendLayout();
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
            this.textMap.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.textMap_EditValueChanging);
            // 
            // numlockControl
            // 
            resources.ApplyResources(this.numlockControl, "numlockControl");
            this.numlockControl.Name = "numlockControl";
            this.numlockControl.UserKeyPressed += new FTS.BaseUI.Controls.KeyboardDelegate(this.numlockControl_UserKeyPressed);
            // 
            // palAction
            // 
            this.palAction.BackColor = System.Drawing.Color.Transparent;
            this.palAction.Controls.Add(this.btnSub);
            this.palAction.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.palAction, "palAction");
            this.palAction.Name = "palAction";
            // 
            // btnSub
            // 
            this.btnSub.AllowFocus = false;
            this.btnSub.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSub.Appearance.Options.UseFont = true;
            this.btnSub.Appearance.Options.UseTextOptions = true;
            this.btnSub.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.btnSub, "btnSub");
            this.btnSub.Name = "btnSub";
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AllowFocus = false;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseTextOptions = true;
            this.btnAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmNumlock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numlockControl);
            this.Controls.Add(this.palAction);
            this.Controls.Add(this.palControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNumlock";
            this.palControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textMap.Properties)).EndInit();
            this.palAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }              

        #endregion

        private System.Windows.Forms.Panel palControl;
        private DevExpress.XtraEditors.TextEdit textMap;
        private FTS.BaseUI.Controls.NumlockControl numlockControl;
        private System.Windows.Forms.Panel palAction;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSub;
    }
}