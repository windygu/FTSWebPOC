namespace FTS.BaseUI.Forms
{
    partial class FrmTranPrintOutput
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
            this.toolbar = new FTS.BaseUI.Forms.FTSTranPrintToolbar();
            this.reportViewer = new DevExpress.XtraPrinting.Control.PrintControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.reportViewer);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 26);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(567, 370);
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(567, 26);
            this.toolbar.TabIndex = 1;
            this.toolbar.ItemClick += new FTS.BaseUI.Controls.ItemClickEventHandler(this.toolbar_ItemClick);
            // 
            // reportViewer
            // 
            this.reportViewer.BackColor = System.Drawing.Color.Empty;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.ForeColor = System.Drawing.Color.Empty;
            this.reportViewer.IsMetric = false;
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(567, 370);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // FrmTranPrintOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 396);
            this.Controls.Add(this.toolbar);
            this.Name = "FrmTranPrintOutput";
            this.Text = "In giao dịch";
            this.Controls.SetChildIndex(this.toolbar, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTSTranPrintToolbar toolbar;
        private DevExpress.XtraPrinting.Control.PrintControl reportViewer;
    }
}