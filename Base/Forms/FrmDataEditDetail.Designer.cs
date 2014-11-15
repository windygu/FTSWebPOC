namespace FTS.BaseUI.Forms
{
    partial class FrmDataEditDetail
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
            this.toolbar = new FTS.BaseUI.Forms.FTSEditFormToolbar();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.EditVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.ExportExcelVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.FilterVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.PrintVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.RefreshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.SaveCloseVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.ShowEditButton = false;
            this.toolbar.Size = new System.Drawing.Size(762, 26);
            this.toolbar.TabIndex = 0;
            this.toolbar.GoItemClick += new FTS.BaseUI.Controls.GoItemToolbarEventHandler(this.toolbar_GoItemClick);
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // palMain
            // 
            this.palMain.BlankWidth = 4;
            this.palMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 26);
            this.palMain.Name = "palMain";
            this.palMain.Size = new System.Drawing.Size(762, 471);
            this.palMain.TabIndex = 0;
            this.palMain.UseBorderColor = true;
            // 
            // FrmDataEditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 497);
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataEditDetail";
            this.Text = "FrmDataEditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTSEditFormToolbar toolbar;
        protected FTS.BaseUI.Controls.FTSShadowPanel palMain;
    }
}