using DevExpress.XtraBars;

namespace FTS.BaseUI.Forms
{
    partial class FTSEditForm2Toolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSEditForm2Toolbar));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeposit = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheck_In = new DevExpress.XtraBars.BarButtonItem();
            this.btnOption = new DevExpress.XtraBars.BarButtonItem();
            this.dropConfig = new DevExpress.XtraBars.BarSubItem();
            this.btnConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalculation = new DevExpress.XtraBars.BarButtonItem();
            this.btnLayout = new DevExpress.XtraBars.BarButtonItem();
            this.btnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.btnTemp = new DevExpress.XtraBars.BarButtonItem();
            this.btnEntry = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            this.btnMoney = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnequal = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalePay = new DevExpress.XtraBars.BarButtonItem();
            this.btnPurchasePay = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnOpen,
            this.btnCopy,
            this.btnEdit,
            this.btnSave,
            this.btnPrint,
            this.btnRefresh,
            this.btnUndo,
            this.btnDelete,
            this.btnImportExcel,
            this.dropConfig,
            this.btnConfig,
            this.btnCalculation,
            this.btnLayout,
            this.btnDefault,
            this.btnHelp,
            this.btnPrevious,
            this.btnNext,
            this.btnTemp,
            this.btnEntry,
            this.btnMoney,
            this.btnUnequal,
            this.btnSalePay,
            this.btnPurchasePay,
            this.btnOption,
            this.btnDeposit,
            this.btnCheck_In});
            this.barManager.MaxItemId = 30;
            // 
            // bar
            // 
            this.bar.BarName = "toolBar";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnOpen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDeposit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCheck_In, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnOption, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dropConfig, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrevious, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "toolBar";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Thêm mới";
            this.btnNew.Id = 0;
            this.btnNew.ImageIndex = 1;
            this.btnNew.Name = "btnNew";
            this.btnNew.Tag = "New";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Mở";
            this.btnOpen.Id = 1;
            this.btnOpen.ImageIndex = 8;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Tag = "Open";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 3;
            this.btnEdit.ImageIndex = 7;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "Edit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "Sao";
            this.btnCopy.Id = 2;
            this.btnCopy.ImageIndex = 4;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Tag = "Copy";
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 4;
            this.btnSave.ImageIndex = 6;
            this.btnSave.Name = "btnSave";
            this.btnSave.Tag = "Save";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageIndex = 12;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Nạp";
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageIndex = 11;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Tag = "Refresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Lại";
            this.btnUndo.Id = 7;
            this.btnUndo.ImageIndex = 0;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Tag = "Undo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 8;
            this.btnDelete.ImageIndex = 5;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Tag = "Delete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Caption = "Import";
            this.btnImportExcel.Id = 27;
            this.btnImportExcel.ImageIndex = 18;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Tag = "ImportExcel";
            this.btnImportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Caption = "Deposit";
            this.btnDeposit.Id = 28;
            this.btnDeposit.ImageIndex = 15;
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Tag = "Deposit";
            this.btnDeposit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDeposit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnCheck_In
            // 
            this.btnCheck_In.Caption = "Check in";
            this.btnCheck_In.Id = 29;
            this.btnCheck_In.ImageIndex = 16;
            this.btnCheck_In.Name = "btnCheck_In";
            this.btnCheck_In.Tag = "Check_In";
            this.btnCheck_In.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCheck_In.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnOption
            // 
            this.btnOption.Id = 25;
            this.btnOption.ImageIndex = 13;
            this.btnOption.Name = "btnOption";
            this.btnOption.Tag = "Option";
            this.btnOption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // dropConfig
            // 
            this.dropConfig.Id = 9;
            this.dropConfig.ImageIndex = 9;
            this.dropConfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCalculation),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDefault),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTemp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEntry)});
            this.dropConfig.Name = "dropConfig";
            // 
            // btnConfig
            // 
            this.btnConfig.Caption = "Cấu hình";
            this.btnConfig.Id = 10;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Tag = "Config";
            this.btnConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnCalculation
            // 
            this.btnCalculation.Caption = "Công thức";
            this.btnCalculation.Id = 11;
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Tag = "Calculation";
            this.btnCalculation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnLayout
            // 
            this.btnLayout.Caption = "Giao diện";
            this.btnLayout.Id = 12;
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Tag = "Layout";
            this.btnLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Caption = "Giá trị mặc định";
            this.btnDefault.Id = 13;
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Tag = "Default";
            this.btnDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.Caption = "Mẫu phiếu in";
            this.btnTemp.Id = 18;
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Tag = "Temp";
            this.btnTemp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.Caption = "Khai định khoản";
            this.btnEntry.Id = 19;
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Tag = "Entry";
            this.btnEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 14;
            this.btnHelp.ImageIndex = 10;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Tag = "Help";
            this.btnHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPrevious.Id = 15;
            this.btnPrevious.ImageIndex = 2;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Tag = "Previous";
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnNext
            // 
            this.btnNext.Id = 16;
            this.btnNext.ImageIndex = 3;
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = "Next";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1026, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 26);
            this.barDockControlBottom.Size = new System.Drawing.Size(1026, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1026, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(15, "1337843779_deposit.png");
            this.imageList.Images.SetKeyName(16, "check_in.png");
            this.imageList.Images.SetKeyName(17, "1340696757_invoice.png");
            this.imageList.Images.SetKeyName(18, "Actions system log out.png");
            // 
            // btnMoney
            // 
            this.btnMoney.Caption = "Chứng từ tiền";
            this.btnMoney.Id = 21;
            this.btnMoney.Name = "btnMoney";
            this.btnMoney.Tag = "Money";
            this.btnMoney.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnUnequal
            // 
            this.btnUnequal.Caption = "Chứng từ chênh lệch";
            this.btnUnequal.Id = 22;
            this.btnUnequal.Name = "btnUnequal";
            this.btnUnequal.Tag = "Unequal";
            this.btnUnequal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnSalePay
            // 
            this.btnSalePay.Caption = "Chứng từ thu";
            this.btnSalePay.Id = 23;
            this.btnSalePay.Name = "btnSalePay";
            this.btnSalePay.Tag = "SalePay";
            this.btnSalePay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Click);
            // 
            // btnPurchasePay
            // 
            this.btnPurchasePay.Caption = "Chứng từ trả";
            this.btnPurchasePay.Id = 24;
            this.btnPurchasePay.Name = "btnPurchasePay";
            this.btnPurchasePay.Tag = "PurchasePay";
            // 
            // FTSEditForm2Toolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FTSEditForm2Toolbar";
            this.Size = new System.Drawing.Size(1026, 26);
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
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnCopy;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarSubItem dropConfig;
        private DevExpress.XtraBars.BarButtonItem btnConfig;
        private DevExpress.XtraBars.BarButtonItem btnCalculation;
        private DevExpress.XtraBars.BarButtonItem btnLayout;
        private DevExpress.XtraBars.BarButtonItem btnDefault;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;        
        private DevExpress.XtraBars.BarButtonItem btnTemp;
        private DevExpress.XtraBars.BarButtonItem btnEntry;
        private DevExpress.XtraBars.BarButtonItem btnMoney;
        private DevExpress.XtraBars.BarButtonItem btnUnequal;
        private DevExpress.XtraBars.BarButtonItem btnSalePay;
        private DevExpress.XtraBars.BarButtonItem btnPurchasePay;
        private DevExpress.XtraBars.BarButtonItem btnOption;
		private DevExpress.XtraBars.BarButtonItem btnImportExcel;
        private BarButtonItem btnDeposit;
        private BarButtonItem btnCheck_In;
    }
}
