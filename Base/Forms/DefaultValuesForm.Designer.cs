namespace FTS.BaseUI.Forms
{
    partial class DefaultValuesForm
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
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboFieldName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDefaultValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldName)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.ConfigVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.CopyVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.EditVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.ExportExcelVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.FilterVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.GoItemVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.HelpVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.NextVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PreviousVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.PrintVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.RefreshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.SaveCloseVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Size = new System.Drawing.Size(824, 26);
            this.toolbar.TabIndex = 0;
            this.toolbar.UndoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 26);
            this.grid.MainView = this.view;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboFieldName});
            this.grid.Size = new System.Drawing.Size(824, 394);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFieldName,
            this.colDefaultValue});
            this.view.GridControl = this.grid;
            this.view.Name = "view";
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.view_CustomRowCellEdit);
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "Tên trường";
            this.colFieldName.ColumnEdit = this.cboFieldName;
            this.colFieldName.FieldName = "FIELD_NAME";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.OptionsFilter.AllowFilter = false;
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 0;
            this.colFieldName.Width = 180;
            // 
            // cboFieldName
            // 
            this.cboFieldName.AutoHeight = false;
            this.cboFieldName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFieldName.Name = "cboFieldName";
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.Caption = "Giá trị mặc định";
            this.colDefaultValue.FieldName = "DEFAULT_VALUE";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.OptionsFilter.AllowFilter = false;
            this.colDefaultValue.Visible = true;
            this.colDefaultValue.VisibleIndex = 1;
            this.colDefaultValue.Width = 264;
            // 
            // DefaultValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 420);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DefaultValuesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Đặt giá trị mặc định";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FTSEditFormToolbar toolbar;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultValue;
    }
}