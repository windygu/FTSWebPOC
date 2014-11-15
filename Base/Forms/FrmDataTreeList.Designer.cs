namespace FTS.BaseUI.Forms
{
    partial class FrmDataTreeList
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
            this.palBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palHeader = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.treelist = new FTS.BaseUI.Controls.FTSTreeList();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelist)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(657, 26);
            this.toolbar.TabIndex = 2;
            this.toolbar.ItemClick+=new FTS.BaseUI.Controls.ItemClickEventHandler(toolbar_ItemClick);
            // 
            // palBottom
            // 
            this.palBottom.BorderColor = System.Drawing.Color.Empty;
            this.palBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palBottom.Location = new System.Drawing.Point(0, 347);
            this.palBottom.Name = "palBottom";
            this.palBottom.NoBorderColor = true;
            this.palBottom.Size = new System.Drawing.Size(657, 75);
            this.palBottom.TabIndex = 3;
            this.palBottom.Visible = false;
            // 
            // palHeader
            // 
            this.palHeader.BorderColor = System.Drawing.Color.Empty;
            this.palHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.palHeader.Location = new System.Drawing.Point(0, 26);
            this.palHeader.Name = "palHeader";
            this.palHeader.NoBorderColor = true;
            this.palHeader.Size = new System.Drawing.Size(657, 42);
            this.palHeader.TabIndex = 4;
            this.palHeader.Visible = false;
            // 
            // palMain
            // 
            this.palMain.BorderColor = System.Drawing.Color.Empty;
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Controls.Add(this.treelist);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 68);
            this.palMain.Name = "palMain";
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(657, 279);
            this.palMain.TabIndex = 5;
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
            this.treelist.Size = new System.Drawing.Size(657, 279);
            this.treelist.TabIndex = 0;
            // 
            // FrmDataTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 422);
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.palHeader);
            this.Controls.Add(this.palBottom);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmDataTreeList";
            this.Text = "FrmDataTreeList";
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTSSelectItemToolbar toolbar;
        protected FTS.BaseUI.Controls.FTSShadowPanel palBottom;
        protected FTS.BaseUI.Controls.FTSShadowPanel palHeader;
        protected FTS.BaseUI.Controls.FTSShadowPanel palMain;
        private FTS.BaseUI.Controls.FTSTreeList treelist;
    }
}