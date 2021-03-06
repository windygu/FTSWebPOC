namespace FTS.BaseUI.Forms
{
    partial class CustomizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationForm));
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabForm = new DevExpress.XtraTab.XtraTabPage();
            this.GridForForm = new DevExpress.XtraGrid.GridControl();
            this.gridViewForm = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.xtraTabForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridForForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewForm)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTab
            // 
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTab.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.xtraTabForm;
            this.xtraTab.Size = new System.Drawing.Size(691, 442);
            this.xtraTab.TabIndex = 1;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabForm});
            // 
            // xtraTabForm
            // 
            this.xtraTabForm.Controls.Add(this.GridForForm);
            this.xtraTabForm.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabForm.Image")));
            this.xtraTabForm.Name = "xtraTabForm";
            this.xtraTabForm.Size = new System.Drawing.Size(685, 413);
            this.xtraTabForm.Text = "Form";
            // 
            // GridForForm
            // 
            this.GridForForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridForForm.Location = new System.Drawing.Point(0, 0);
            this.GridForForm.MainView = this.gridViewForm;
            this.GridForForm.Name = "GridForForm";
            this.GridForForm.Size = new System.Drawing.Size(685, 413);
            this.GridForForm.TabIndex = 0;
            this.GridForForm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewForm});
            // 
            // gridViewForm
            // 
            this.gridViewForm.GridControl = this.GridForForm;
            this.gridViewForm.Name = "gridViewForm";
            this.gridViewForm.OptionsView.ShowAutoFilterRow = true;
            // 
            // CustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 442);
            this.Controls.Add(this.xtraTab);
            this.Name = "CustomizationForm";
            this.Text = "Tuỳ biến giao diện";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.xtraTabForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridForForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTab;       
        private DevExpress.XtraTab.XtraTabPage xtraTabForm;
        private DevExpress.XtraGrid.GridControl GridForForm;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewForm;
    }
}