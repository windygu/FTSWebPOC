namespace FTS.BaseUI.Forms
{
    partial class FTSEditFormToolbar
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSEditFormToolbar));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.txtGo = new DevExpress.XtraBars.BarEditItem();
            this.reptxtGo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.dropConfig = new DevExpress.XtraBars.BarSubItem();
            this.btnLayout = new DevExpress.XtraBars.BarButtonItem();
            this.btnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.cboItem = new DevExpress.XtraBars.BarEditItem();
            this.Combobox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptxtGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combobox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageList;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrevious,
            this.btnNext,
            this.btnNew,
            this.btnCopy,
            this.btnEdit,
            this.btnSave,
            this.btnSaveClose,
            this.btnUndo,
            this.btnDelete,
            this.btnRefresh,
            this.btnFilter,
            this.btnImportExcel,
            this.btnExportExcel,
            this.btnPrint,
            this.btnHelp,
            this.btnClose,
            this.cboItem,
            this.txtGo,
            this.dropConfig,
            this.btnLayout,
            this.btnDefault,
            this.btnSaveNew});
            this.barManager.MaxItemId = 22;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Combobox,
            this.reptxtGo});
            // 
            // bar
            // 
            this.bar.BarName = "toolBar";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrevious, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.txtGo, "", false, true, true, 80),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSaveNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnFilter, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dropConfig, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.cboItem, "", false, true, true, 179)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "toolBar";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Id = 0;
            this.btnPrevious.ImageIndex = 5;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Tag = "Previous";
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // txtGo
            // 
            this.txtGo.Edit = this.reptxtGo;
            this.txtGo.EditValue = "";
            this.txtGo.Id = 17;
            this.txtGo.Name = "txtGo";
            this.txtGo.Tag = "GoItem";
            this.txtGo.Width = 80;
            // 
            // reptxtGo
            // 
            this.reptxtGo.AutoHeight = false;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject1.Options.UseFont = true;
            this.reptxtGo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Go", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.reptxtGo.Name = "reptxtGo";
            // 
            // btnNext
            // 
            this.btnNext.Id = 1;
            this.btnNext.ImageIndex = 4;
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = "Next";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Mới";
            this.btnNew.Id = 2;
            this.btnNew.ImageIndex = 3;
            this.btnNew.Name = "btnNew";
            this.btnNew.Tag = "New";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "Sao";
            this.btnCopy.Id = 3;
            this.btnCopy.ImageIndex = 6;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Tag = "Copy";
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 4;
            this.btnEdit.ImageIndex = 9;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "Edit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xoá";
            this.btnDelete.Id = 8;
            this.btnDelete.ImageIndex = 7;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Tag = "Delete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 12;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 5;
            this.btnSave.ImageIndex = 8;
            this.btnSave.Name = "btnSave";
            this.btnSave.Tag = "Save";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Caption = "Lưu và đóng";
            this.btnSaveClose.Id = 6;
            this.btnSaveClose.ImageIndex = 17;
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Tag = "SaveClose";
            this.btnSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Caption = "Lưu và mới";
            this.btnSaveNew.Id = 21;
            this.btnSaveNew.ImageIndex = 13;
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Tag = "SaveNew";
            this.btnSaveNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Lại";
            this.btnUndo.Id = 7;
            this.btnUndo.ImageIndex = 2;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Tag = "Undo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Nạp";
            this.btnRefresh.Id = 9;
            this.btnRefresh.ImageIndex = 1;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Tag = "Refresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Caption = "Lọc";
            this.btnFilter.Id = 10;
            this.btnFilter.ImageIndex = 15;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Tag = "Filter";
            this.btnFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Caption = "Import";
            this.btnImportExcel.Id = 11;
            this.btnImportExcel.ImageIndex = 19;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Tag = "ImportExcel";
            this.btnImportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Excel";
            this.btnExportExcel.Id = 11;
            this.btnExportExcel.ImageIndex = 12;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Tag = "ExportExcel";
            this.btnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // dropConfig
            // 
            this.dropConfig.Id = 18;
            this.dropConfig.ImageIndex = 10;
            this.dropConfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDefault)});
            this.dropConfig.Name = "dropConfig";
            // 
            // btnLayout
            // 
            this.btnLayout.Caption = "Giao diện";
            this.btnLayout.Id = 19;
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Tag = "Layout";
            this.btnLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Caption = "Giá trị mặc định";
            this.btnDefault.Id = 20;
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Tag = "Default";
            this.btnDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 15;
            this.btnClose.ImageIndex = 14;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "Close";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 14;
            this.btnHelp.ImageIndex = 11;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Tag = "Help";
            this.btnHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // cboItem
            // 
            this.cboItem.Edit = this.Combobox;
            this.cboItem.Id = 16;
            this.cboItem.Name = "cboItem";
            this.cboItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.cboItem.EditValueChanged += new System.EventHandler(this.cboItem_EditValueChanged);
            // 
            // Combobox
            // 
            this.Combobox.AutoHeight = false;
            this.Combobox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Combobox.Name = "Combobox";
            this.Combobox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1076, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 26);
            this.barDockControlBottom.Size = new System.Drawing.Size(1076, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1076, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(18, "1340696757_invoice.png");
            this.imageList.Images.SetKeyName(19, "Actions system log out.png");
            // 
            // FTSEditFormToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FTSEditFormToolbar";
            this.Size = new System.Drawing.Size(1076, 26);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptxtGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combobox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageList;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnCopy;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveClose;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnFilter;
        private DevExpress.XtraBars.BarButtonItem btnImportExcel;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.BarButtonItem btnPrint;        
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarEditItem cboItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox Combobox;
        private DevExpress.XtraBars.BarEditItem txtGo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit reptxtGo;
        private DevExpress.XtraBars.BarSubItem dropConfig;
        private DevExpress.XtraBars.BarButtonItem btnLayout;
        private DevExpress.XtraBars.BarButtonItem btnDefault;
        private DevExpress.XtraBars.BarButtonItem btnSaveNew;
    }
}
