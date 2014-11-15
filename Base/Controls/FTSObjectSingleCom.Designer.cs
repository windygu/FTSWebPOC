namespace FTS.BaseUI.Controls
{
    partial class FTSObjectSingleCom
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpObject = new DevExpress.XtraEditors.GroupControl();
            this.txtObject = new DevExpress.XtraEditors.LabelControl();
            this.ObjectId = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpObject)).BeginInit();
            this.grpObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpObject
            // 
            this.grpObject.Controls.Add(this.ObjectId);
            this.grpObject.Controls.Add(this.txtObject);
            this.grpObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpObject.Location = new System.Drawing.Point(0, 0);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(180, 106);
            this.grpObject.TabIndex = 0;
            // 
            // txtObject
            // 
            this.txtObject.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObject.Location = new System.Drawing.Point(2, 20);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(176, 0);
            this.txtObject.TabIndex = 0;
            // 
            // ObjectId
            // 
            this.ObjectId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ObjectId.Dock = System.Windows.Forms.DockStyle.Right;
            this.ObjectId.Location = new System.Drawing.Point(178, 20);
            this.ObjectId.Name = "ObjectId";
            this.ObjectId.Size = new System.Drawing.Size(0, 84);
            this.ObjectId.TabIndex = 1;
            this.ObjectId.TextChanged += new System.EventHandler(this.ObjectId_TextChanged);
            // 
            // FTSObjectSingleCom
            // 
            this.Controls.Add(this.grpObject);
            this.Name = "FTSObjectSingleCom";
            this.Size = new System.Drawing.Size(180, 106);
            ((System.ComponentModel.ISupportInitialize)(this.grpObject)).EndInit();
            this.grpObject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpObject;
        private DevExpress.XtraEditors.LabelControl ObjectId;
        private DevExpress.XtraEditors.LabelControl txtObject;
    }
}
