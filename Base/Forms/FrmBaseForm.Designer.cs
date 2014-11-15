namespace FTS.BaseUI.Forms
{
    partial class FrmBaseForm
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
            this.groupBox = new FTS.BaseUI.Controls.FTSShadowPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.Empty;
            this.groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupBox.Location = new System.Drawing.Point(10, 38);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(272, 190);
            this.groupBox.TabIndex = 1;
            // 
            // FrmBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupBox);
            this.Name = "FrmBaseForm";
            this.Text = "FrmBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FTS.BaseUI.Controls.FTSShadowPanel groupBox;
    }
}