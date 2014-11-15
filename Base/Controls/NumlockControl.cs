using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FTS.BaseUI.Controls
{
    public partial class NumlockControl : XtraUserControl
    {
        public NumlockControl()
        {
            InitializeComponent();
        }
        private string pvtKeyboardKeyPressed = "";

        [Category("Mouse"), Description("Return value of mouseclicked key")]
        public event KeyboardDelegate UserKeyPressed;
        protected virtual void OnUserKeyPressed(KeyboardEventArgs e)
        {
            if (UserKeyPressed != null)
                UserKeyPressed(this, e);
        }
        private void pictureBoxNumlock_MouseClick(object sender, MouseEventArgs e)
        {
            Single xpos = e.X;
            Single ypos = e.Y;

            xpos = 220 * (xpos / pictureBoxNumlock.Width);
            ypos = 223 * (ypos / pictureBoxNumlock.Height);

            pvtKeyboardKeyPressed = HandleTheMouseClick(xpos, ypos);

            KeyboardEventArgs dea = new KeyboardEventArgs(pvtKeyboardKeyPressed);

            OnUserKeyPressed(dea);
        }
        private string HandleTheMouseClick(Single x, Single y)
        {
            string Keypressed = null;
            if (y > 1 && y < 54)
            {
                if (x > 1 && x < 54) Keypressed = "7";
                else if (x > 55 && x < 108) Keypressed = "8";
                else if (x > 110 && x < 163) Keypressed = "9";
                else if (x > 165 && x < 218)Keypressed = "{ENTER}";            
            }
            else if (y > 55 && y < 108)
            {
                if (x > 1 && x < 54) Keypressed = "4";
                else if (x > 55 && x < 108) Keypressed = "5";
                else if (x > 110 && x < 163) Keypressed = "6";
                else if (x > 165 && x < 218) Keypressed = "{ENTER}";            
            }
            else if (y > 110 && y < 163)
            {
                if (x > 1 && x < 54) Keypressed = "1";
                else if (x > 55 && x < 108) Keypressed = "2";
                else if (x > 110 && x < 163) Keypressed = "3";
                else if (x > 165 && x < 218) Keypressed = "{ENTER}";            
            }
            else if (y > 168 && y < 220)
            {
                if (x > 1 && x < 54) Keypressed = "0";
                else if (x > 55 && x < 108) Keypressed = ".";
                else if (x > 110 && x < 218) Keypressed = "{BACKSPACE}";                
            }
            else
            {
                if (x > 165 && x < 218) Keypressed = "{ENTER}";
            }
            return Keypressed;            
        }        
    }
}
