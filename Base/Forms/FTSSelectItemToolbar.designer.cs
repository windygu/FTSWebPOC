namespace FTS.BaseUI.Forms
{
    partial class FTSSelectItemToolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSSelectItemToolbar));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeID = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnChoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
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
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnChangeID,
            this.btnConfig,
            this.btnHelp,
            this.btnChoice,
            this.btnClose,
            this.btnEditList,
            this.btnExportExcel,
            this.btnPrint});
            this.barManager.MaxItemId = 11;
            // 
            // bar
            // 
            this.bar.BarName = "toolBar";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChangeID, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEditList, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnConfig, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChoice, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "toolBar";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Hint = "hint";
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 1;
            this.btnNew.Name = "btnNew";
            this.btnNew.Tag = "New";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageIndex = 3;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "Edit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Tag = "Delete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnChangeID
            // 
            this.btnChangeID.Caption = "Change ID";
            this.btnChangeID.Id = 3;
            this.btnChangeID.ImageIndex = 9;
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Tag = "ChangeID";
            this.btnChangeID.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnEditList
            // 
            this.btnEditList.Id = 9;
            this.btnEditList.ImageIndex = 4;
            this.btnEditList.Name = "btnEditList";
            this.btnEditList.Tag = "EditList";
            this.btnEditList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Id = 10;
            this.btnPrint.ImageIndex = 9;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Excel";
            this.btnExportExcel.Id = 11;
            this.btnExportExcel.ImageIndex = 8;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Tag = "ExportExcel";
            this.btnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Id = 4;
            this.btnConfig.ImageIndex = 7;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Tag = "Config";
            this.btnConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnChoice
            // 
            this.btnChoice.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnChoice.Caption = "Chọn";
            this.btnChoice.Id = 6;
            this.btnChoice.ImageIndex = 6;
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Tag = "Choice";
            this.btnChoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 7;
            this.btnClose.ImageIndex = 5;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "Close";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Help";
            this.btnHelp.Id = 5;
            this.btnHelp.ImageIndex = 0;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Tag = "Help";
            this.btnHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(532, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 26);
            this.barDockControlBottom.Size = new System.Drawing.Size(532, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(532, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(9, "Transfer.png");
            // 
            // FTSSelectItemToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FTSSelectItemToolbar";
            this.Size = new System.Drawing.Size(532, 26);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnChangeID;
        private DevExpress.XtraBars.BarButtonItem btnConfig;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnChoice;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnEditList;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
    }
}
