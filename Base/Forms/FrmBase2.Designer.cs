namespace FTS.BaseUI.Forms
{
    partial class FrmBase2
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
            this.toolbar = new FTS.BaseUI.Forms.FTSEditForm2Toolbar();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palFill = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupGrid = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            this.groupBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupBottom0 = new FTS.BaseUI.Controls.FTSShadowPanel();

            this.groupHeader = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palExtTop = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palRight = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.split = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            this.palRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.CheckInVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.DepositVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(721, 26);
            this.toolbar.TabIndex = 4;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // palMain
            // 
            this.palMain.BorderColor = System.Drawing.Color.Empty;
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Controls.Add(this.palFill);
            this.palMain.Controls.Add(this.palRight);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 26);
            this.palMain.Name = "palMain";
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(721, 468);
            this.palMain.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palMain.TabIndex = 5;
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.BorderColor = System.Drawing.Color.Empty;
            this.palFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palFill.Controls.Add(this.groupGrid);
            this.palFill.Controls.Add(this.groupBottom);
            this.palFill.Controls.Add(this.groupBottom0);

            this.palFill.Controls.Add(this.groupHeader);
            this.palFill.Controls.Add(this.palExtTop);
            this.palFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palFill.Location = new System.Drawing.Point(0, 0);
            this.palFill.Name = "palFill";
            this.palFill.NoBorderColor = true;
            this.palFill.Size = new System.Drawing.Size(585, 468);
            this.palFill.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palFill.TabIndex = 1;
            // 
            // groupGrid
            // 
            this.groupGrid.BlankWidth = 3;
            this.groupGrid.BorderColor = System.Drawing.Color.Empty;
            this.groupGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupGrid.Controls.Add(this.grid);
            this.groupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGrid.Location = new System.Drawing.Point(0, 183);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(585, 233);
            this.groupGrid.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupGrid.TabIndex = 9;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(585, 233);
            this.grid.TabIndex = 11;
            // 
            // groupBottom
            // 
            this.groupBottom.BlankWidth = 3;
            this.groupBottom.BorderColor = System.Drawing.Color.Empty;
            this.groupBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBottom.Location = new System.Drawing.Point(0, 416);
            this.groupBottom.Name = "groupBottom";
            this.groupBottom.NoBorderColor = true;
            this.groupBottom.Size = new System.Drawing.Size(585, 52);
            this.groupBottom.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupBottom.TabIndex = 10;
            this.groupBottom.Visible = false;
            // 
            // groupBottom2

            // 
            this.groupBottom0.BlankWidth = 3;
            this.groupBottom0.BorderColor = System.Drawing.Color.Empty;
            this.groupBottom0.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBottom0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBottom0.Location = new System.Drawing.Point(0, 416);
            this.groupBottom0.Name = "groupBottom0";
            this.groupBottom0.NoBorderColor = true;
            this.groupBottom0.Size = new System.Drawing.Size(585, 52);
            this.groupBottom0.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupBottom0.TabIndex = 10;
            this.groupBottom0.Visible = false;            
            // 
            // groupHeader
            // 
            this.groupHeader.BlankWidth = 3;
            this.groupHeader.BorderColor = System.Drawing.Color.Empty;
            this.groupHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupHeader.Location = new System.Drawing.Point(0, 40);
            this.groupHeader.Name = "groupHeader";
            this.groupHeader.NoBorderColor = true;
            this.groupHeader.Size = new System.Drawing.Size(585, 143);
            this.groupHeader.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupHeader.TabIndex = 9;
            // 
            // palExtTop
            // 
            this.palExtTop.BlankWidth = 3;
            this.palExtTop.BorderColor = System.Drawing.Color.Empty;
            this.palExtTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palExtTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palExtTop.Location = new System.Drawing.Point(0, 0);
            this.palExtTop.Name = "palExtTop";
            this.palExtTop.NoBorderColor = true;
            this.palExtTop.Size = new System.Drawing.Size(585, 40);
            this.palExtTop.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palExtTop.TabIndex = 12;
            this.palExtTop.Visible = false;
            // 
            // palRight
            // 
            this.palRight.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palRight.Appearance.Options.UseBackColor = true;
            this.palRight.BorderColor = System.Drawing.Color.Empty;
            this.palRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palRight.Controls.Add(this.split);
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(585, 0);
            this.palRight.Name = "palRight";
            this.palRight.NoBorderColor = true;
            this.palRight.Size = new System.Drawing.Size(136, 468);
            this.palRight.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palRight.TabIndex = 0;
            this.palRight.Visible = false;
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(5, 468);
            this.split.TabIndex = 6;
            this.split.TabStop = false;
            // 
            // FrmBase2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 494);
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmBase2";
            this.Text = "FrmBase2";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            this.palRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected FTSEditForm2Toolbar toolbar;
        protected Controls.FTSShadowPanel palMain;
        protected Controls.FTSShadowPanel palFill;
        protected Controls.FTSDataGrid grid;
        protected Controls.FTSShadowPanel groupBottom;
        protected Controls.FTSShadowPanel groupBottom0;
        protected Controls.FTSShadowPanel groupHeader;
        protected Controls.FTSShadowPanel groupGrid;
        protected Controls.FTSShadowPanel palExtTop;
        protected Controls.FTSShadowPanel palRight;
        protected DevExpress.XtraEditors.SplitterControl split;
    }
}