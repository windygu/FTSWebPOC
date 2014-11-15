namespace FTS.BaseUI.Forms
{
    partial class FrmTouchscreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTouchscreen));
            this.palTitle = new DevExpress.XtraEditors.PanelControl();
            this.lblFts = new DevExpress.XtraEditors.LabelControl();
            this.btnMinimum = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.palMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.palTitle)).BeginInit();
            this.palTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.SuspendLayout();
            // 
            // palTitle
            // 
            this.palTitle.Controls.Add(this.lblFts);
            this.palTitle.Controls.Add(this.btnMinimum);
            this.palTitle.Controls.Add(this.btnClose);
            resources.ApplyResources(this.palTitle, "palTitle");
            this.palTitle.Name = "palTitle";
            this.palTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palTitle_MouseDown);
            // 
            // lblFts
            // 
            this.lblFts.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblIpos.Appearance.Font")));
            this.lblFts.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblIpos.Appearance.ForeColor")));
            this.lblFts.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFts.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblFts, "lblFts");
            this.lblFts.Name = "lblFts";
            // 
            // btnMinimum
            // 
            this.btnMinimum.AllowFocus = false;
            resources.ApplyResources(this.btnMinimum, "btnMinimum");
            this.btnMinimum.Image = global::FTS.BaseUI.Properties.Resources.Minimize;
            this.btnMinimum.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::FTS.BaseUI.Properties.Resources.Close;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // palMain
            // 
            resources.ApplyResources(this.palMain, "palMain");
            this.palMain.Name = "palMain";
            // 
            // FrmTouchscreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.palTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTouchscreen";
            ((System.ComponentModel.ISupportInitialize)(this.palTitle)).EndInit();
            this.palTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnMinimum;
        protected DevExpress.XtraEditors.PanelControl palMain;
        protected DevExpress.XtraEditors.PanelControl palTitle;
        private DevExpress.XtraEditors.LabelControl lblFts;
    }
}