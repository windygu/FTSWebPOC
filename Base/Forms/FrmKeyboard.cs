using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseUI.Controls;

namespace FTS.BaseUI.Forms
{
    public partial class FrmKeyboard : XtraForm
    {
        object retValue = null;
        public FrmKeyboard()
        {
            InitializeComponent();
        }
        public FrmKeyboard(Point location, Size size, bool pass)
        {
            InitializeComponent();
            bool header = true;
            Bitmap bitmap = global::FTS.BaseUI.Properties.Resources.keyboard_header;
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            this.textMap.Size = size;
            this.textMap.Top = (this.palControl.Height - size.Height) / 2;
            this.textMap.Left = (this.palControl.Width - size.Width) / 2;
            if (this.textMap.Left > location.X)
                this.textMap.Left = location.X;
            else if (location.X + this.palControl.Width - this.textMap.Left > screen.Width)            
                this.textMap.Left = this.palControl.Width - this.textMap.Width;
            if (location.Y + this.palControl.Height - this.textMap.Top + this.keyboardControl.Height > screen.Height)
            {
                header = false;                
                this.palControl.Dock = DockStyle.Bottom;                
            }
            if(!header)
                bitmap = global::FTS.BaseUI.Properties.Resources.keyboard_footer;
            if (pass)            
                this.textMap.Properties.PasswordChar = '*';                           
            BitmapRegion.CreateControlRegion(this.palControl, bitmap,header);
            /*
            if (header)
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top);
            else
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top - this.keyboardControl.Height);            
            */
            if (header)            
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top);                            
            else            
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top - this.keyboardControl.Height);            
            if (this.Location.X < 0)
            {
                this.textMap.Left = this.textMap.Left + this.Location.X;
                this.Location = new Point(0, this.Location.Y);
            }
        }

        private void keyboardControl_UserKeyPressed(object sender, FTS.BaseUI.Controls.KeyboardEventArgs e)
        {
            if (e.KeyboardKeyPressed == "{ENTER}")
            {
                this.retValue = this.textMap.EditValue;
                this.DialogResult = DialogResult.OK;
            }
            else
                SendKeys.Send(e.KeyboardKeyPressed);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.keyboardControl_UserKeyPressed(this.keyboardControl, new FTS.BaseUI.Controls.KeyboardEventArgs("{ENTER}"));
                return true;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }
        public object RetValue
        {
            get { return this.retValue; }
        }
    }
}