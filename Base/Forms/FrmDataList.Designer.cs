namespace FTS.BaseUI.Forms
{
    partial class FrmDataList
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
            this.toolbar = new FTS.BaseUI.Forms.FTSSelectItemToolbar();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            this.palRight = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.split = new DevExpress.XtraEditors.SplitterControl();
            this.treeList = new FTS.BaseUI.Controls.FTSTreeList();
            this.palBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.splitRight = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(699, 26);
            this.toolbar.TabIndex = 1;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // palMain
            // 
            this.palMain.BorderColor = System.Drawing.Color.Empty;
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Controls.Add(this.splitRight);
            this.palMain.Controls.Add(this.grid);
            this.palMain.Controls.Add(this.palRight);
            this.palMain.Controls.Add(this.split);
            this.palMain.Controls.Add(this.treeList);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 26);
            this.palMain.Name = "palMain";
            this.palMain.Size = new System.Drawing.Size(699, 389);
            this.palMain.TabIndex = 1;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(166, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(366, 389);
            this.grid.TabIndex = 0;
            // 
            // palRight
            // 
            this.palRight.BorderColor = System.Drawing.Color.Empty;
            this.palRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(532, 0);
            this.palRight.Name = "palRight";
            this.palRight.NoBorderColor = true;
            this.palRight.Size = new System.Drawing.Size(167, 389);
            this.palRight.TabIndex = 2;
            this.palRight.Visible = false;
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(161, 0);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(5, 389);
            this.split.TabIndex = 1;
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
            this.treeList.Size = new System.Drawing.Size(161, 389);
            this.treeList.TabIndex = 1;
            // 
            // palBottom
            // 
            this.palBottom.BorderColor = System.Drawing.Color.Empty;
            this.palBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palBottom.Location = new System.Drawing.Point(0, 415);
            this.palBottom.Name = "palBottom";
            this.palBottom.NoBorderColor = true;
            this.palBottom.Size = new System.Drawing.Size(699, 100);
            this.palBottom.TabIndex = 2;
            this.palBottom.Visible = false;
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitRight.Enabled = false;
            this.splitRight.Location = new System.Drawing.Point(527, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Size = new System.Drawing.Size(5, 389);
            this.splitRight.TabIndex = 3;
            this.splitRight.TabStop = false;
            this.splitRight.Visible = false;
            // 
            // FrmDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 515);
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.palBottom);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataList";
            this.Text = "FrmDataList";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTSSelectItemToolbar toolbar;
        protected FTS.BaseUI.Controls.FTSShadowPanel palMain;
        protected FTS.BaseUI.Controls.FTSTreeList treeList;
        protected DevExpress.XtraEditors.SplitterControl split;
        protected FTS.BaseUI.Controls.FTSDataGrid grid;
        protected FTS.BaseUI.Controls.FTSShadowPanel palBottom;
        protected Controls.FTSShadowPanel palRight;
        protected DevExpress.XtraEditors.SplitterControl splitRight;
    }
}