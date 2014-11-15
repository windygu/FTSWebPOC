namespace FTS.BaseUI.Forms
{
    partial class FrmDataEditListDetail
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
            this.groupHeader = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.CloseVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.FilterVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.GoItemVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.NextVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PreviousVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PrintVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.SaveCloseVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Size = new System.Drawing.Size(875, 26);
            this.toolbar.TabIndex = 4;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // groupHeader
            // 
            this.groupHeader.BorderColor = System.Drawing.Color.Empty;
            this.groupHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupHeader.Location = new System.Drawing.Point(0, 26);
            this.groupHeader.Name = "groupHeader";
            this.groupHeader.Size = new System.Drawing.Size(875, 143);
            this.groupHeader.TabIndex = 5;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Name = "";
            this.grid.Location = new System.Drawing.Point(0, 169);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(875, 269);
            this.grid.TabIndex = 7;
            // 
            // FrmDataEditListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 438);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupHeader);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataEditListDetail";
            this.Text = "FrmDataEditListDEtail";
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTS.BaseUI.Controls.FTSShadowPanel groupHeader;
        protected FTS.BaseUI.Controls.FTSDataGrid grid;
        protected FTSEditFormToolbar toolbar;
    }
}