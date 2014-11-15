namespace FTS.BaseUI.Forms
{
    partial class FrmDataEditList
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
            this.groupGrid = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            this.split = new DevExpress.XtraEditors.SplitterControl();
            this.treeList = new FTS.BaseUI.Controls.FTSTreeList();
            this.groupBox = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupTop = new FTS.BaseUI.Controls.FTSShadowPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.EditVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.GoItemVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.NextVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PreviousVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PrintVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.RefreshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.SaveCloseVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.ShowEditButton = false;
            this.toolbar.Size = new System.Drawing.Size(752, 26);
            this.toolbar.TabIndex = 1;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // groupGrid
            // 
            this.groupGrid.BorderColor = System.Drawing.Color.Empty;
            this.groupGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupGrid.Controls.Add(this.grid);
            this.groupGrid.Controls.Add(this.split);
            this.groupGrid.Controls.Add(this.treeList);
            this.groupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGrid.Location = new System.Drawing.Point(0, 96);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(752, 337);
            this.groupGrid.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(209, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(543, 337);
            this.grid.TabIndex = 1;
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(204, 0);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(5, 337);
            this.split.TabIndex = 3;
            this.split.TabStop = false;
            // 
            // treeList
            // 
            this.treeList.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.treeList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeList.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.EnterMovesNextColumn = true;
            this.treeList.OptionsMenu.EnableColumnMenu = false;
            this.treeList.OptionsMenu.EnableFooterMenu = false;
            this.treeList.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList.OptionsView.EnableAppearanceOddRow = true;
            this.treeList.Size = new System.Drawing.Size(204, 337);
            this.treeList.TabIndex = 2;
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.Empty;
            this.groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 433);
            this.groupBox.Name = "groupBox";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(752, 70);
            this.groupBox.TabIndex = 6;
            this.groupBox.Visible = false;
            // 
            // groupTop
            // 
            this.groupTop.BorderColor = System.Drawing.Color.Empty;
            this.groupTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupTop.Location = new System.Drawing.Point(0, 26);
            this.groupTop.Name = "groupTop";
            this.groupTop.NoBorderColor = true;
            this.groupTop.Size = new System.Drawing.Size(752, 70);
            this.groupTop.TabIndex = 7;
            this.groupTop.Visible = false;
            // 
            // FrmDataEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 503);
            this.Controls.Add(this.groupGrid);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.groupTop);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataEditList";
            this.Text = "FrmDataEditList";
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FTSEditFormToolbar toolbar;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupGrid;
        protected FTS.BaseUI.Controls.FTSDataGrid grid;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupBox;
        protected DevExpress.XtraEditors.SplitterControl split;
        protected FTS.BaseUI.Controls.FTSTreeList treeList;
        protected Controls.FTSShadowPanel groupTop;
    }
}