namespace FTS.BaseUI.Forms
{
    partial class FrmProgressBar
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
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.bar = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.bar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(7, 7);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(42, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Message";
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(7, 24);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(302, 24);
            this.bar.TabIndex = 1;
            // 
            // FrmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 53);
            this.ControlBox = false;
            this.Controls.Add(this.bar);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmProgressBar";
            this.ShowInTaskbar = false;
            this.Text = "Tiến trình xử lý";
            ((System.ComponentModel.ISupportInitialize)(this.bar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.ProgressBarControl bar;
    }
}