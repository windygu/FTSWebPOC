namespace FTS.BaseUI.Controls
{
    partial class ButtonItemView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonItemView));
            this.palGroup = new DevExpress.XtraEditors.PanelControl();
            this.palBGroup = new DevExpress.XtraEditors.PanelControl();
            this.btnGDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnGUp = new DevExpress.XtraEditors.SimpleButton();
            this.palItem = new DevExpress.XtraEditors.PanelControl();
            this.palBItem = new DevExpress.XtraEditors.PanelControl();
            this.btnIDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnIUp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBGroup)).BeginInit();
            this.palBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBItem)).BeginInit();
            this.palBItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // palGroup
            // 
            this.palGroup.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palGroup.Appearance.Options.UseBackColor = true;
            this.palGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.palGroup, "palGroup");
            this.palGroup.Name = "palGroup";
            // 
            // palBGroup
            // 
            this.palBGroup.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palBGroup.Appearance.Options.UseBackColor = true;
            this.palBGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBGroup.Controls.Add(this.btnGDown);
            this.palBGroup.Controls.Add(this.btnGUp);
            resources.ApplyResources(this.palBGroup, "palBGroup");
            this.palBGroup.Name = "palBGroup";
            // 
            // btnGDown
            // 
            this.btnGDown.AllowFocus = false;
            resources.ApplyResources(this.btnGDown, "btnGDown");
            this.btnGDown.Image = global::FTS.BaseUI.Properties.Resources.arrow_down_blue;
            this.btnGDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGDown.Name = "btnGDown";
            this.btnGDown.Click += new System.EventHandler(this.btnGDown_Click);
            // 
            // btnGUp
            // 
            this.btnGUp.AllowFocus = false;
            resources.ApplyResources(this.btnGUp, "btnGUp");
            this.btnGUp.Image = global::FTS.BaseUI.Properties.Resources.arrow_up_blue;
            this.btnGUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGUp.Name = "btnGUp";
            this.btnGUp.Click += new System.EventHandler(this.btnGUp_Click);
            // 
            // palItem
            // 
            this.palItem.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palItem.Appearance.Options.UseBackColor = true;
            this.palItem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.palItem, "palItem");
            this.palItem.Name = "palItem";
            // 
            // palBItem
            // 
            this.palBItem.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palBItem.Appearance.Options.UseBackColor = true;
            this.palBItem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBItem.Controls.Add(this.btnIDown);
            this.palBItem.Controls.Add(this.btnIUp);
            resources.ApplyResources(this.palBItem, "palBItem");
            this.palBItem.Name = "palBItem";
            // 
            // btnIDown
            // 
            this.btnIDown.AllowFocus = false;
            resources.ApplyResources(this.btnIDown, "btnIDown");
            this.btnIDown.Image = global::FTS.BaseUI.Properties.Resources.arrow_down_blue;
            this.btnIDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIDown.Name = "btnIDown";
            this.btnIDown.Click += new System.EventHandler(this.btnIDown_Click);
            // 
            // btnIUp
            // 
            this.btnIUp.AllowFocus = false;
            resources.ApplyResources(this.btnIUp, "btnIUp");
            this.btnIUp.Image = global::FTS.BaseUI.Properties.Resources.arrow_up_blue;
            this.btnIUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIUp.Name = "btnIUp";
            this.btnIUp.Click += new System.EventHandler(this.btnIUp_Click);
            // 
            // ButtonItemView
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.palItem);
            this.Controls.Add(this.palBItem);
            this.Controls.Add(this.palBGroup);
            this.Controls.Add(this.palGroup);
            this.Name = "ButtonItemView";
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBGroup)).EndInit();
            this.palBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBItem)).EndInit();
            this.palBItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl palGroup;
        private DevExpress.XtraEditors.PanelControl palBGroup;
        private DevExpress.XtraEditors.PanelControl palItem;
        private DevExpress.XtraEditors.PanelControl palBItem;
        private DevExpress.XtraEditors.SimpleButton btnIUp;
        private DevExpress.XtraEditors.SimpleButton btnGDown;
        private DevExpress.XtraEditors.SimpleButton btnGUp;
        private DevExpress.XtraEditors.SimpleButton btnIDown;
    }
}
