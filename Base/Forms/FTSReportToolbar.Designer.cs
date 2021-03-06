namespace FTS.BaseUI.Forms
{
    partial class FTSReportToolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSReportToolbar));
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarSubItem();
            this.btnToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnToWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnToPdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnToHtml = new DevExpress.XtraBars.BarButtonItem();
            this.btnZoom = new DevExpress.XtraBars.BarSubItem();
            this.btnPageWidth = new DevExpress.XtraBars.BarCheckItem();
            this.btnWholePage = new DevExpress.XtraBars.BarCheckItem();
            this.btn300 = new DevExpress.XtraBars.BarCheckItem();
            this.btn200 = new DevExpress.XtraBars.BarCheckItem();
            this.btn150 = new DevExpress.XtraBars.BarCheckItem();
            this.btn100 = new DevExpress.XtraBars.BarCheckItem();
            this.btn75 = new DevExpress.XtraBars.BarCheckItem();
            this.btn50 = new DevExpress.XtraBars.BarCheckItem();
            this.btn25 = new DevExpress.XtraBars.BarCheckItem();
            this.btnFind = new DevExpress.XtraBars.BarButtonItem();
            this.btnPart = new DevExpress.XtraBars.BarSubItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.cboView = new DevExpress.XtraBars.BarEditItem();
            this.ComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnSort = new DevExpress.XtraBars.BarButtonItem();
            this.btnFont = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroup = new DevExpress.XtraBars.BarButtonItem();
            this.btnColumns = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageSetup = new DevExpress.XtraBars.BarButtonItem();
            this.btnTitle = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
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
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.btnPrint,
            this.btnExport,
            this.btnToExcel,
            this.btnToWord,
            this.btnToPdf,
            this.btnToHtml,
            this.btnZoom,
            this.btnPageWidth,
            this.btnWholePage,
            this.btn300,
            this.btn200,
            this.btn150,
            this.btn100,
            this.btn75,
            this.btn50,
            this.btn25,
            this.btnFind,
            this.btnPart,
            this.btnSave,
            this.cboView,
            this.btnSort,
            this.btnFont,
            this.btnGroup,
            this.btnColumns,
            this.btnTitle,
            this.btnPageSetup,
            this.btnFilter,
            this.btnConfig});
            this.barManager.MaxItemId = 37;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ComboBox});
            // 
            // bar
            // 
            this.bar.BarName = "toolBar";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnFirst, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrevious, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLast),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnZoom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFind),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPart, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.cboView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSort),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFont),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGroup),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnColumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageSetup),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTitle),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfig)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "toolBar";
            // 
            // btnFirst
            // 
            this.btnFirst.Id = 0;
            this.btnFirst.ImageIndex = 24;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Tag = "First";
            this.btnFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Id = 1;
            this.btnPrevious.ImageIndex = 25;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Tag = "Previous";
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnNext
            // 
            this.btnNext.Id = 2;
            this.btnNext.ImageIndex = 23;
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = "Next";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnLast
            // 
            this.btnLast.Id = 3;
            this.btnLast.ImageIndex = 26;
            this.btnLast.Name = "btnLast";
            this.btnLast.Tag = "Last";
            this.btnLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Id = 4;
            this.btnPrint.ImageIndex = 7;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnExport
            // 
            this.btnExport.Id = 6;
            this.btnExport.ImageIndex = 2;
            this.btnExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnToWord),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnToHtml)});
            this.btnExport.Name = "btnExport";
            this.btnExport.Tag = "Export";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Caption = "Excel";
            this.btnToExcel.Id = 7;
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Tag = "ToExcel";
            this.btnToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropExport_Click);
            // 
            // btnToWord
            // 
            this.btnToWord.Caption = "Word";
            this.btnToWord.Id = 8;
            this.btnToWord.Name = "btnToWord";
            this.btnToWord.Tag = "ToWord";
            this.btnToWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropExport_Click);
            // 
            // btnToPdf
            // 
            this.btnToPdf.Caption = "Pdf";
            this.btnToPdf.Id = 9;
            this.btnToPdf.Name = "btnToPdf";
            this.btnToPdf.Tag = "ToPdf";
            this.btnToPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropExport_Click);
            // 
            // btnToHtml
            // 
            this.btnToHtml.Caption = "Html";
            this.btnToHtml.Id = 10;
            this.btnToHtml.Name = "btnToHtml";
            this.btnToHtml.Tag = "ToHtml";
            this.btnToHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropExport_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Id = 12;
            this.btnZoom.ImageIndex = 9;
            this.btnZoom.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageWidth),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWholePage),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn300),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn200),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn150),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn100),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn75),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn50),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn25)});
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Tag = "Zoom";
            // 
            // btnPageWidth
            // 
            this.btnPageWidth.Caption = "Page Width";
            this.btnPageWidth.Id = 13;
            this.btnPageWidth.Name = "btnPageWidth";
            this.btnPageWidth.Tag = "PageWidth";
            this.btnPageWidth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btnWholePage
            // 
            this.btnWholePage.Caption = "Whole Page";
            this.btnWholePage.Id = 14;
            this.btnWholePage.Name = "btnWholePage";
            this.btnWholePage.Tag = "WholePage";
            this.btnWholePage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn300
            // 
            this.btn300.Caption = "300%";
            this.btn300.Id = 15;
            this.btn300.Name = "btn300";
            this.btn300.Tag = "300";
            this.btn300.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn200
            // 
            this.btn200.Caption = "200%";
            this.btn200.Id = 16;
            this.btn200.Name = "btn200";
            this.btn200.Tag = "200";
            this.btn200.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn150
            // 
            this.btn150.Caption = "150%";
            this.btn150.Id = 17;
            this.btn150.Name = "btn150";
            this.btn150.Tag = "150";
            this.btn150.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn100
            // 
            this.btn100.Caption = "100%";
            this.btn100.Id = 18;
            this.btn100.Name = "btn100";
            this.btn100.Tag = "100";
            this.btn100.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn75
            // 
            this.btn75.Caption = "75%";
            this.btn75.Id = 19;
            this.btn75.Name = "btn75";
            this.btn75.Tag = "75";
            this.btn75.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn50
            // 
            this.btn50.Caption = "50%";
            this.btn50.Id = 20;
            this.btn50.Name = "btn50";
            this.btn50.Tag = "50";
            this.btn50.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btn25
            // 
            this.btn25.Caption = "25%";
            this.btn25.Id = 21;
            this.btn25.Name = "btn25";
            this.btn25.Tag = "25";
            this.btn25.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DropZoom_Click);
            // 
            // btnFind
            // 
            this.btnFind.Id = 22;
            this.btnFind.ImageIndex = 12;
            this.btnFind.Name = "btnFind";
            this.btnFind.Tag = "Find";
            this.btnFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPart
            // 
            this.btnPart.Id = 24;
            this.btnPart.ImageIndex = 20;
            this.btnPart.Name = "btnPart";
            this.btnPart.Tag = "Part";
            // 
            // btnSave
            // 
            this.btnSave.Id = 25;
            this.btnSave.ImageIndex = 11;
            this.btnSave.Name = "btnSave";
            this.btnSave.Tag = "Save";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // cboView
            // 
            this.cboView.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.cboView.Edit = this.ComboBox;
            this.cboView.Id = 28;
            this.cboView.Name = "cboView";
            this.cboView.Width = 75;
            this.cboView.EditValueChanged += new System.EventHandler(this.cboView_EditValueChanged);
            // 
            // ComboBox
            // 
            this.ComboBox.AutoHeight = false;
            this.ComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnSort
            // 
            this.btnSort.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSort.Id = 29;
            this.btnSort.ImageIndex = 14;
            this.btnSort.Name = "btnSort";
            this.btnSort.Tag = "Sort";
            this.btnSort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnFont
            // 
            this.btnFont.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnFont.Id = 30;
            this.btnFont.ImageIndex = 15;
            this.btnFont.Name = "btnFont";
            this.btnFont.Tag = "Font";
            this.btnFont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnGroup.Id = 31;
            this.btnGroup.ImageIndex = 22;
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Tag = "Group";
            this.btnGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnColumns
            // 
            this.btnColumns.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnColumns.Id = 32;
            this.btnColumns.ImageIndex = 21;
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Tag = "Columns";
            this.btnColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageSetup.Id = 34;
            this.btnPageSetup.ImageIndex = 27;
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Tag = "PageSetup";
            this.btnPageSetup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnTitle
            // 
            this.btnTitle.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnTitle.Id = 33;
            this.btnTitle.ImageIndex = 16;
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Tag = "Title";
            this.btnTitle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Id = 35;
            this.btnFilter.ImageIndex = 0;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Tag = "Filter";
            this.btnFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Id = 36;
            this.btnConfig.ImageIndex = 19;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Tag = "Config";
            this.btnConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // FTSReportToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FTSReportToolbar";
            this.Size = new System.Drawing.Size(675, 26);
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageList;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarButtonItem btnFirst;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnLast;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarSubItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnToExcel;
        private DevExpress.XtraBars.BarButtonItem btnToWord;
        private DevExpress.XtraBars.BarButtonItem btnToPdf;
        private DevExpress.XtraBars.BarButtonItem btnToHtml;
        private DevExpress.XtraBars.BarSubItem btnZoom;
        private DevExpress.XtraBars.BarCheckItem btnPageWidth;
        private DevExpress.XtraBars.BarCheckItem btnWholePage;
        private DevExpress.XtraBars.BarCheckItem btn300;
        private DevExpress.XtraBars.BarCheckItem btn200;
        private DevExpress.XtraBars.BarCheckItem btn150;
        private DevExpress.XtraBars.BarCheckItem btn100;
        private DevExpress.XtraBars.BarCheckItem btn75;
        private DevExpress.XtraBars.BarCheckItem btn50;
        private DevExpress.XtraBars.BarCheckItem btn25;
        private DevExpress.XtraBars.BarButtonItem btnFind;
        private DevExpress.XtraBars.BarSubItem btnPart;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarEditItem cboView;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ComboBox;
        private DevExpress.XtraBars.BarButtonItem btnSort;
        private DevExpress.XtraBars.BarButtonItem btnFont;
        private DevExpress.XtraBars.BarButtonItem btnGroup;
        private DevExpress.XtraBars.BarButtonItem btnColumns;
        private DevExpress.XtraBars.BarButtonItem btnTitle;
        private DevExpress.XtraBars.BarButtonItem btnPageSetup;
        private DevExpress.XtraBars.BarButtonItem btnFilter;
        private DevExpress.XtraBars.BarButtonItem btnConfig;
    }
}
