namespace FTS.BaseUI.Forms {
    partial class FTSUserControlGrid {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupMain = new FTS.BaseUI.Controls.FTSGroupBox();
            this.grid = new FTS.BaseUI.Controls.FTSDataGrid();
            this.groupCommand = new FTS.BaseUI.Controls.FTSShadowPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupMain)).BeginInit();
            this.groupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.grid);
            this.groupMain.Controls.Add(this.groupCommand);
            this.groupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMain.Location = new System.Drawing.Point(0, 0);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(429, 279);
            this.groupMain.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Name = "";
            this.grid.Location = new System.Drawing.Point(2, 20);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(425, 216);
            this.grid.TabIndex = 2;
            // 
            // groupCommand
            // 
            this.groupCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupCommand.Location = new System.Drawing.Point(2, 236);
            this.groupCommand.Name = "groupCommand";
            this.groupCommand.Size = new System.Drawing.Size(425, 41);
            this.groupCommand.TabIndex = 4;
            this.groupCommand.Text = "ftsShadowPanel1";
            // 
            // FTSUserControlGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupMain);
            this.Name = "FTSUserControlGrid";
            ((System.ComponentModel.ISupportInitialize)(this.groupMain)).EndInit();
            this.groupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTS.BaseUI.Controls.FTSGroupBox groupMain;
        protected FTS.BaseUI.Controls.FTSDataGrid grid;
        protected FTS.BaseUI.Controls.FTSShadowPanel groupCommand;

    }
}
