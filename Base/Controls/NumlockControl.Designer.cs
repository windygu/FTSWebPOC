namespace FTS.BaseUI.Controls
{
    partial class NumlockControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumlockControl));
            this.pictureBoxNumlock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNumlock)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxNumlock
            // 
            resources.ApplyResources(this.pictureBoxNumlock, "pictureBoxNumlock");
            this.pictureBoxNumlock.Image = global::FTS.BaseUI.Properties.Resources.numlock_white;
            this.pictureBoxNumlock.Name = "pictureBoxNumlock";
            this.pictureBoxNumlock.TabStop = false;
            this.pictureBoxNumlock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxNumlock_MouseClick);
            // 
            // NumlockControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxNumlock);
            this.Name = "NumlockControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNumlock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNumlock;
    }
}
