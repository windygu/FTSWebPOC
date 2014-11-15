namespace FTS.BaseUI.Controls
{
    partial class KeyboardControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardControl));
            this.pictureBoxLeftShiftDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxRightShiftDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapsLockDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxKeyboard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftShiftDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightShiftDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapsLockDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLeftShiftDown
            // 
            this.pictureBoxLeftShiftDown.Image = global::FTS.BaseUI.Properties.Resources.shift_down_white;
            resources.ApplyResources(this.pictureBoxLeftShiftDown, "pictureBoxLeftShiftDown");
            this.pictureBoxLeftShiftDown.Name = "pictureBoxLeftShiftDown";
            this.pictureBoxLeftShiftDown.TabStop = false;
            this.pictureBoxLeftShiftDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLeftShiftState_MouseClick);
            // 
            // pictureBoxRightShiftDown
            // 
            this.pictureBoxRightShiftDown.Image = global::FTS.BaseUI.Properties.Resources.shift_down_white;
            resources.ApplyResources(this.pictureBoxRightShiftDown, "pictureBoxRightShiftDown");
            this.pictureBoxRightShiftDown.Name = "pictureBoxRightShiftDown";
            this.pictureBoxRightShiftDown.TabStop = false;
            this.pictureBoxRightShiftDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRightShiftState_MouseClick);
            // 
            // pictureBoxCapsLockDown
            // 
            this.pictureBoxCapsLockDown.Image = global::FTS.BaseUI.Properties.Resources.caps_down_white;
            resources.ApplyResources(this.pictureBoxCapsLockDown, "pictureBoxCapsLockDown");
            this.pictureBoxCapsLockDown.Name = "pictureBoxCapsLockDown";
            this.pictureBoxCapsLockDown.TabStop = false;
            this.pictureBoxCapsLockDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCapsLockState_MouseClick);
            // 
            // pictureBoxKeyboard
            // 
            resources.ApplyResources(this.pictureBoxKeyboard, "pictureBoxKeyboard");
            this.pictureBoxKeyboard.Image = global::FTS.BaseUI.Properties.Resources.keyboard_white;
            this.pictureBoxKeyboard.Name = "pictureBoxKeyboard";
            this.pictureBoxKeyboard.TabStop = false;
            this.pictureBoxKeyboard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxKeyboard_MouseClick);
            this.pictureBoxKeyboard.SizeChanged += new System.EventHandler(this.pictureBoxKeyboard_SizeChanged);
            // 
            // KeyboardControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxLeftShiftDown);
            this.Controls.Add(this.pictureBoxRightShiftDown);
            this.Controls.Add(this.pictureBoxCapsLockDown);
            this.Controls.Add(this.pictureBoxKeyboard);
            this.Name = "KeyboardControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftShiftDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightShiftDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapsLockDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCapsLockDown;
        private System.Windows.Forms.PictureBox pictureBoxRightShiftDown;
        private System.Windows.Forms.PictureBox pictureBoxLeftShiftDown;
        private System.Windows.Forms.PictureBox pictureBoxKeyboard;
    }
}
