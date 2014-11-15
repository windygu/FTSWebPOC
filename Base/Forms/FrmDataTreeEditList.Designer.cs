namespace FTS.BaseUI.Forms
{
    partial class FrmDataTreeEditList
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
            this.groupBox = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.groupTree = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.treelist = new FTS.BaseUI.Controls.FTSTreeList();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTree)).BeginInit();
            this.groupTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelist)).BeginInit();
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
            this.toolbar.Size = new System.Drawing.Size(690, 26);
            this.toolbar.TabIndex = 2;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.Empty;
            this.groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 308);
            this.groupBox.Name = "groupBox";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(690, 143);
            this.groupBox.TabIndex = 7;
            this.groupBox.Visible = false;
            // 
            // groupTree
            // 
            this.groupTree.BorderColor = System.Drawing.Color.Empty;
            this.groupTree.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupTree.Controls.Add(this.treelist);
            this.groupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTree.Location = new System.Drawing.Point(0, 26);
            this.groupTree.Name = "groupTree";
            this.groupTree.NoBorderColor = true;
            this.groupTree.Size = new System.Drawing.Size(690, 282);
            this.groupTree.TabIndex = 8;
            // 
            // treelist
            // 
            this.treelist.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treelist.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Appearance.EvenRow.Options.UseBackColor = true;
            this.treelist.Appearance.EvenRow.Options.UseFont = true;
            this.treelist.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.treelist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treelist.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Appearance.FooterPanel.Options.UseFont = true;
            this.treelist.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Appearance.GroupFooter.Options.UseFont = true;
            this.treelist.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Appearance.HeaderPanel.Options.UseFont = true;
            this.treelist.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treelist.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treelist.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treelist.Appearance.OddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Appearance.OddRow.Options.UseBackColor = true;
            this.treelist.Appearance.OddRow.Options.UseFont = true;
            this.treelist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treelist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treelist.Location = new System.Drawing.Point(0, 0);            
            this.treelist.Name = "treelist";
            this.treelist.OptionsBehavior.EnterMovesNextColumn = true;
            this.treelist.OptionsMenu.EnableColumnMenu = false;
            this.treelist.OptionsMenu.EnableFooterMenu = false;
            this.treelist.OptionsView.EnableAppearanceEvenRow = true;
            this.treelist.OptionsView.EnableAppearanceOddRow = true;
            this.treelist.Size = new System.Drawing.Size(690, 282);
            this.treelist.TabIndex = 0;
            // 
            // FrmDataTreeEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 451);
            this.Controls.Add(this.groupTree);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataTreeEditList";
            this.Text = "FrmDataTreeEditList";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTree)).EndInit();
            this.groupTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FTSEditFormToolbar toolbar;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupBox;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupTree;
        private FTS.BaseUI.Controls.FTSTreeList treelist;
    }
}