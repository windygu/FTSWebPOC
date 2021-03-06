using FTS.BaseUI.Controls;

namespace FTS.BaseUI.Forms
{
    partial class FrmTranManager
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
            this.lstTranClass = new DevExpress.XtraEditors.ListBoxControl();
            this.split = new DevExpress.XtraEditors.SplitterControl();
            this.lstTranId = new DevExpress.XtraEditors.ListBoxControl();
            this.palBottom = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.btnClose = new FTS.BaseUI.Controls.FTSButton();
            this.btnDelete = new FTS.BaseUI.Controls.FTSButton();
            this.btnCreate = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTranClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTranId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            this.palBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lstTranId);
            this.groupBox.Controls.Add(this.palBottom);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(274, 0);
            this.groupBox.Size = new System.Drawing.Size(410, 446);
            // 
            // lstTranClass
            // 
            this.lstTranClass.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstTranClass.Location = new System.Drawing.Point(0, 0);
            this.lstTranClass.Name = "lstTranClass";
            this.lstTranClass.Size = new System.Drawing.Size(268, 446);
            this.lstTranClass.TabIndex = 0;
            this.lstTranClass.SelectedIndexChanged += new System.EventHandler(this.lstTranClass_SelectedIndexChanged);
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(268, 0);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(6, 446);
            this.split.TabIndex = 1;
            this.split.TabStop = false;
            // 
            // lstTranId
            // 
            this.lstTranId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTranId.Location = new System.Drawing.Point(0, 0);
            this.lstTranId.Name = "lstTranId";
            this.lstTranId.Size = new System.Drawing.Size(410, 371);
            this.lstTranId.TabIndex = 3;
            // 
            // palBottom
            // 
            this.palBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palBottom.Controls.Add(this.btnClose);
            this.palBottom.Controls.Add(this.btnDelete);
            this.palBottom.Controls.Add(this.btnCreate);
            this.palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palBottom.Location = new System.Drawing.Point(0, 371);
            this.palBottom.Name = "palBottom";
            this.palBottom.Size = new System.Drawing.Size(410, 75);
            this.palBottom.TabIndex = 2;
            this.palBottom.Text = "ftsShadowPanel1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(269, 28);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xoá chứng từ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(61, 28);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Tạo chứng từ";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FrmTranManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 446);
            this.Controls.Add(this.split);
            this.Controls.Add(this.lstTranClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTranManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý giao dịch";
            this.Controls.SetChildIndex(this.lstTranClass, 0);
            this.Controls.SetChildIndex(this.split, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTranClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTranId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            this.palBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lstTranClass;
        private DevExpress.XtraEditors.SplitterControl split;
        private DevExpress.XtraEditors.ListBoxControl lstTranId;
        private FTSShadowPanel palBottom;
        private FTS.BaseUI.Controls.FTSButton btnClose;
        private FTS.BaseUI.Controls.FTSButton btnDelete;
        private FTS.BaseUI.Controls.FTSButton btnCreate;
    }
}