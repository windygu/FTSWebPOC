using System.Windows.Forms;

namespace FTS.BaseUI.Forms
{
    partial class FrmBase2Listing
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
            this.groupControl = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.toolbar = new FTS.BaseUI.Forms.FTSSelectItemToolbar();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.Location = new System.Drawing.Point(0, 26);
            this.groupGrid.Size = new System.Drawing.Size(580, 356);
            // 
            // palMain
            // 
            this.palMain.Size = new System.Drawing.Size(580, 356);
            // 
            // palFill
            // 
            this.palFill.Size = new System.Drawing.Size(384, 356);
            // 
            // groupBottom
            // 
            this.groupBottom.Location = new System.Drawing.Point(0, 288);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupControl);
            this.groupBox.Size = new System.Drawing.Size(384, 80);
            // 
            // palLeft
            // 
            this.palLeft.Size = new System.Drawing.Size(196, 356);
            // 
            // groupControl
            // 
            this.groupControl.BorderColor = System.Drawing.Color.Empty;
            this.groupControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.NoBorderColor = true;
            this.groupControl.Size = new System.Drawing.Size(384, 80);
            this.groupControl.TabIndex = 1;
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(580, 26);
            this.toolbar.TabIndex = 4;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // FrmBase2Listing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 382);
            this.ControlBox = false;
            this.Controls.Add(this.toolbar);
            this.Name = "FrmBase2Listing";
            this.Text = "FrmBase2Listing";           
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTS.BaseUI.Controls.FTSShadowPanel groupControl;
        protected FTSSelectItemToolbar toolbar;
    }
}