namespace FTS.BaseUI.Forms
{
    partial class FrmBaseFormGrid
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
            this.groupGrid = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palFill = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupGrid2 = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.splitGrid = new DevExpress.XtraEditors.SplitterControl();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            this.groupBox = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palLeft = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palGrid2 = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.grid2 = new FTS.BaseUI.Controls.FTSDataGrid();
            this.scrollGrid = new DevExpress.XtraEditors.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).BeginInit();
            this.groupGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).BeginInit();
            this.palGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.BorderColor = System.Drawing.Color.Empty;
            this.groupGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupGrid.Controls.Add(this.palMain);
            this.groupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGrid.Location = new System.Drawing.Point(0, 0);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.NoBorderColor = true;
            this.groupGrid.Size = new System.Drawing.Size(580, 382);
            this.groupGrid.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupGrid.TabIndex = 1;
            // 
            // palMain
            // 
            this.palMain.BorderColor = System.Drawing.Color.Empty;
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Controls.Add(this.palFill);
            this.palMain.Controls.Add(this.palLeft);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 0);
            this.palMain.Name = "palMain";
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(580, 382);
            this.palMain.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palMain.TabIndex = 0;
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.BorderColor = System.Drawing.Color.Empty;
            this.palFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palFill.Controls.Add(this.groupGrid2);
            this.palFill.Controls.Add(this.groupBox);
            this.palFill.Controls.Add(this.groupBottom);
            this.palFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palFill.Location = new System.Drawing.Point(196, 0);
            this.palFill.Name = "palFill";
            this.palFill.NoBorderColor = true;
            this.palFill.Size = new System.Drawing.Size(384, 382);
            this.palFill.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palFill.TabIndex = 1;
            // 
            // groupGrid2
            // 
            this.groupGrid2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupGrid2.Appearance.Options.UseBackColor = true;
            this.groupGrid2.BorderColor = System.Drawing.Color.Empty;
            this.groupGrid2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupGrid2.Controls.Add(this.grid);
            this.groupGrid2.Controls.Add(this.splitGrid);
            this.groupGrid2.Controls.Add(this.palGrid2);
            this.groupGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGrid2.Location = new System.Drawing.Point(0, 139);
            this.groupGrid2.Name = "groupGrid2";
            this.groupGrid2.NoBorderColor = true;
            this.groupGrid2.Size = new System.Drawing.Size(384, 175);
            this.groupGrid2.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupGrid2.TabIndex = 6;
            // 
            // splitGrid
            // 
            this.splitGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitGrid.Location = new System.Drawing.Point(212, 0);
            this.splitGrid.Name = "splitGrid";
            this.splitGrid.Size = new System.Drawing.Size(5, 175);
            this.splitGrid.TabIndex = 5;
            this.splitGrid.TabStop = false;
            this.splitGrid.Visible = false;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(212, 175);
            this.grid.TabIndex = 4;
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.Empty;
            this.groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(384, 139);
            this.groupBox.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupBox.TabIndex = 3;
            // 
            // groupBottom
            // 
            this.groupBottom.BorderColor = System.Drawing.Color.Empty;
            this.groupBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBottom.Location = new System.Drawing.Point(0, 314);
            this.groupBottom.Name = "groupBottom";
            this.groupBottom.NoBorderColor = true;
            this.groupBottom.Size = new System.Drawing.Size(384, 68);
            this.groupBottom.SkinBackColor = System.Drawing.SystemColors.Control;
            this.groupBottom.TabIndex = 5;
            this.groupBottom.Visible = false;
            // 
            // palLeft
            // 
            this.palLeft.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palLeft.BorderColor = System.Drawing.Color.Empty;
            this.palLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.palLeft.Location = new System.Drawing.Point(0, 0);
            this.palLeft.Name = "palLeft";
            this.palLeft.NoBorderColor = true;
            this.palLeft.Size = new System.Drawing.Size(196, 382);
            this.palLeft.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palLeft.TabIndex = 0;
            this.palLeft.Visible = false;
            // 
            // palGrid2
            // 
            this.palGrid2.BorderColor = System.Drawing.Color.Empty;
            this.palGrid2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palGrid2.Controls.Add(this.grid2);
            this.palGrid2.Controls.Add(this.scrollGrid);
            this.palGrid2.Dock = System.Windows.Forms.DockStyle.Right;
            this.palGrid2.Location = new System.Drawing.Point(217, 0);
            this.palGrid2.Name = "palGrid2";
            this.palGrid2.NoBorderColor = true;
            this.palGrid2.Size = new System.Drawing.Size(167, 175);
            this.palGrid2.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palGrid2.TabIndex = 6;
            this.palGrid2.Visible = false;
            // 
            // grid2
            // 
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(0, 0);
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(150, 175);
            this.grid2.TabIndex = 8;
            this.grid2.Visible = false;
            // 
            // scrollGrid
            // 
            this.scrollGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollGrid.Location = new System.Drawing.Point(150, 0);
            this.scrollGrid.Name = "scrollGrid";
            this.scrollGrid.Size = new System.Drawing.Size(17, 175);
            this.scrollGrid.TabIndex = 9;
            this.scrollGrid.Visible = false;
            // 
            // FrmBaseFormGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 382);
            this.Controls.Add(this.groupGrid);
            this.Name = "FrmBaseFormGrid";
            this.Text = "FrmBaseFormGrid";
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid2)).EndInit();
            this.groupGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palGrid2)).EndInit();
            this.palGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTS.BaseUI.Controls.FTSShadowPanel groupGrid;
        protected Controls.FTSShadowPanel palMain;
        protected Controls.FTSShadowPanel palFill;
        protected Controls.FTSShadowPanel groupBottom;
        protected Controls.FTSDataGrid grid;
        protected Controls.FTSShadowPanel groupBox;
        protected Controls.FTSShadowPanel palLeft;
        protected Controls.FTSShadowPanel groupGrid2;
        protected DevExpress.XtraEditors.SplitterControl splitGrid;
        protected Controls.FTSShadowPanel palGrid2;
        protected Controls.FTSDataGrid grid2;
        protected DevExpress.XtraEditors.VScrollBar scrollGrid;

    }
}