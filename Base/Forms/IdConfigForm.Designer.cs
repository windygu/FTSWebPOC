namespace FTS.BaseUI.Forms
{
    partial class IdConfigForm
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
            this.palBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            this.btnOk = new FTS.BaseUI.Controls.FTSButton();
            this.gridTable = new FTS.BaseUI.Controls.FTSDataGrid();
            this.split = new DevExpress.XtraEditors.SplitterControl();
            this.palMain = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.gridStruct = new FTS.BaseUI.Controls.FTSDataGrid();
            this.gridDefault = new FTS.BaseUI.Controls.FTSDataGrid();
            this.gridFilter = new FTS.BaseUI.Controls.FTSDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            this.palBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStruct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.palMain);
            this.groupBox.Controls.Add(this.split);
            this.groupBox.Controls.Add(this.gridTable);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(784, 508);
            // 
            // palBottom
            // 
            this.palBottom.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palBottom.Appearance.Options.UseBackColor = true;
            this.palBottom.BorderColor = System.Drawing.Color.Empty;
            this.palBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBottom.Controls.Add(this.btnCancel);
            this.palBottom.Controls.Add(this.btnOk);
            this.palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palBottom.Location = new System.Drawing.Point(0, 508);
            this.palBottom.Name = "palBottom";
            this.palBottom.NoBorderColor = true;
            this.palBottom.Size = new System.Drawing.Size(784, 54);
            this.palBottom.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.HelpText = "";
            this.btnCancel.Location = new System.Drawing.Point(395, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnOk.HelpText = "";
            this.btnOk.Location = new System.Drawing.Point(314, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 33);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gridTable
            // 
            this.gridTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridTable.Location = new System.Drawing.Point(0, 0);
            this.gridTable.Name = "gridTable";
            this.gridTable.Size = new System.Drawing.Size(333, 508);
            this.gridTable.TabIndex = 0;
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(333, 0);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(5, 508);
            this.split.TabIndex = 7;
            this.split.TabStop = false;
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.BorderColor = System.Drawing.Color.Empty;
            this.palMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palMain.Controls.Add(this.gridStruct);
            this.palMain.Controls.Add(this.gridDefault);
            this.palMain.Controls.Add(this.gridFilter);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(338, 0);
            this.palMain.Name = "palMain";
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(446, 508);
            this.palMain.SkinBackColor = System.Drawing.SystemColors.Control;
            this.palMain.TabIndex = 8;
            // 
            // gridStruct
            // 
            this.gridStruct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStruct.Location = new System.Drawing.Point(0, 192);
            this.gridStruct.Name = "gridStruct";
            this.gridStruct.Size = new System.Drawing.Size(446, 108);
            this.gridStruct.TabIndex = 3;
            // 
            // gridDefault
            // 
            this.gridDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridDefault.Location = new System.Drawing.Point(0, 300);
            this.gridDefault.Name = "gridDefault";
            this.gridDefault.Size = new System.Drawing.Size(446, 208);
            this.gridDefault.TabIndex = 4;
            // 
            // gridFilter
            // 
            this.gridFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridFilter.Location = new System.Drawing.Point(0, 0);
            this.gridFilter.Name = "gridFilter";
            this.gridFilter.Size = new System.Drawing.Size(446, 192);
            this.gridFilter.TabIndex = 0;
            // 
            // IdConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.palBottom);
            this.Name = "IdConfigForm";
            this.Text = "IdConfigForm";
            this.Controls.SetChildIndex(this.palBottom, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            this.palBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStruct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FTSShadowPanel palBottom;
        private Controls.FTSDataGrid gridTable;
        private Controls.FTSShadowPanel palMain;
        protected DevExpress.XtraEditors.SplitterControl split;
        private Controls.FTSDataGrid gridFilter;
        private Controls.FTSDataGrid gridDefault;
        private Controls.FTSDataGrid gridStruct;
        private Controls.FTSButton btnCancel;
        private Controls.FTSButton btnOk;
    }
}