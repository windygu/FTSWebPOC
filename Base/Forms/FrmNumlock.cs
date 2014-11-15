using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseUI.Controls;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.Globalization;

namespace FTS.BaseUI.Forms
{
    public partial class FrmNumlock : XtraForm
    {
        object retValue = null;
        string mMask = string.Empty;
        bool mPass = false;
        bool mDecimals = false;        
        NumlockAction mAction = NumlockAction.NONE;

        public FrmNumlock()
        {
            InitializeComponent();
        }
        public FrmNumlock(Point location, Size size, bool pass, bool decimals, string mask, object value)
        {
            this.mMask = mask;
            this.mPass = pass;
            this.mDecimals = decimals;            
            InitializeComponent();
            this.palAction.Visible = false;
            this.numlockControl.Height = this.numlockControl.Height + this.palAction.Height;
            bool header = true;
            Bitmap bitmap = global::FTS.BaseUI.Properties.Resources.numlock_header;
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            this.textMap.Size = size;
            if (mask != "s0")
            {
                this.textMap.Properties.DisplayFormat.FormatString = mask;
                this.textMap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.textMap.Properties.EditFormat.FormatString = mask;
                this.textMap.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.textMap.Properties.Mask.EditMask = mask;
                this.textMap.Properties.Mask.MaskType = MaskType.Numeric;                
                this.textMap.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            this.textMap.Top = (this.palControl.Height - size.Height) / 2;
            this.textMap.Left = (this.palControl.Width - size.Width) / 2;
            if (this.textMap.Left > location.X)
                this.textMap.Left = location.X;
            else if (location.X + this.palControl.Width - this.textMap.Left > screen.Width)            
                this.textMap.Left = this.palControl.Width - this.textMap.Width;
            if (location.Y + this.palControl.Height - this.textMap.Top + this.numlockControl.Height > screen.Height)
            {
                header = false;                
                this.palControl.Dock = DockStyle.Bottom;                
            }
            if(!header)
                bitmap = global::FTS.BaseUI.Properties.Resources.numlock_footer;
            if (this.mPass)
                this.textMap.Properties.PasswordChar = '*';
            BitmapRegion.CreateControlRegion(this.palControl, bitmap,header);
            if (header)
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top);
            else
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top - this.numlockControl.Height);
            /*
            if (value != null)            
                this.textMap.EditValue = value;                            
            */ 
        }

        public FrmNumlock(Point location, Size size, string mask, object value)
        {
            this.mMask = mask;
            this.mPass = false;
            this.mDecimals = true;            
            InitializeComponent();
            this.palAction.Visible = true;
            this.Height = this.Height + this.palAction.Height;
            bool header = true;
            Bitmap bitmap = global::FTS.BaseUI.Properties.Resources.numlock_header;
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            this.textMap.Size = size;
            if (mask != "s0")
            {
                this.textMap.Properties.DisplayFormat.FormatString = mask;
                this.textMap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.textMap.Properties.EditFormat.FormatString = mask;
                this.textMap.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.textMap.Properties.Mask.EditMask = mask;
                this.textMap.Properties.Mask.MaskType = MaskType.Numeric;
                this.textMap.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            this.textMap.Top = (this.palControl.Height - size.Height) / 2;
            this.textMap.Left = (this.palControl.Width - size.Width) / 2;
            if (this.textMap.Left > location.X)
                this.textMap.Left = location.X;
            else if (location.X + this.palControl.Width - this.textMap.Left > screen.Width)
                this.textMap.Left = this.palControl.Width - this.textMap.Width;
            if (location.Y + this.palControl.Height - this.textMap.Top + this.numlockControl.Height + this.palAction.Height > screen.Height)
            {
                header = false;
                this.palAction.Dock = DockStyle.Top;
                this.palControl.Dock = DockStyle.Bottom;
            }
            if (!header)
                bitmap = global::FTS.BaseUI.Properties.Resources.numlock_footer;
            if (this.mPass)
                this.textMap.Properties.PasswordChar = '*';
            BitmapRegion.CreateControlRegion(this.palControl, bitmap, header);
            if (header)
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top);
            else
                this.Location = new Point(location.X - this.textMap.Left, location.Y - this.textMap.Top - this.numlockControl.Height- this.palAction.Height);
            /*
            if (value != null)            
                this.textMap.EditValue = value;                            
            */
        }

        private void numlockControl_UserKeyPressed(object sender, FTS.BaseUI.Controls.KeyboardEventArgs e)
        {
            if (e.KeyboardKeyPressed == "{ENTER}")
            {
                this.retValue = this.textMap.EditValue;                
                try
                {
                    if ((this.mMask != "s0") && this.mMask.StartsWith("n"))
                    {
                        if (this.mMask.Substring(1, 1) == "0")
                        {
                            if (this.mDecimals)
                            {
                                decimal number = decimal.Parse(this.retValue.ToString(), NumberStyles.Any);
                                if (number == 0)
                                    this.DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                Int16 number = System.Convert.ToInt16(this.retValue);
                                if (number == 0)
                                    this.DialogResult = DialogResult.Cancel;
                            }
                        }
                        else
                        {
                            decimal number = decimal.Parse(this.retValue.ToString(), NumberStyles.Any);
                            if (number == 0)
                                this.DialogResult = DialogResult.Cancel;
                        }
                    }                                        
                }
                catch (Exception)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
                SendKeys.Send(e.KeyboardKeyPressed);
        }
        private void textMap_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (this.mMask != "s0")
                {
                    if (this.mMask.StartsWith("n"))
                    {
                        if (this.mMask.Substring(1, 1) == "0")
                        {
                            if (this.mDecimals)
                            {
                                decimal number = decimal.Parse(e.NewValue.ToString(), NumberStyles.Any);
                                if (number < 0)
                                    e.Cancel = true;
                            }
                            else
                            {
                                Int16 number = System.Convert.ToInt16(e.NewValue);
                                if (number < 0)
                                    e.Cancel = true;
                            }
                        }
                        else
                        {
                            decimal number = decimal.Parse(e.NewValue.ToString(), NumberStyles.Any);
                            if (number < 0)
                                e.Cancel = true;
                        }
                    }
                    else if (this.mMask.StartsWith("p"))
                    {
                        decimal percent = decimal.Parse(e.NewValue.ToString(), NumberStyles.Any) / 100;
                        if ((percent < 0) || (percent > 1))
                            e.Cancel = true;
                    }
                }
                else if ((this.mMask == "s0")&&(this.mPass))
                {
                    try
                    {
                        e.NewValue = e.NewValue.ToString().Replace(" ", string.Empty);
                        if (e.NewValue.ToString().Trim() != string.Empty)
                        {
                            Int32 number = System.Convert.ToInt32(e.NewValue);
                        }
                    }
                    catch (Exception)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception)
            {                
                e.Cancel = true;
            }
        }        
        public object RetValue
        {
            get { return this.retValue; }
        }
        public NumlockAction Action
        {
            get { return this.mAction; }
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (this.palAction.Visible)
            {
                this.btnAdd.Enabled = true;
                this.btnSub.Enabled = false;
                this.mAction = NumlockAction.SUB;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.palAction.Visible)
            {
                this.btnSub.Enabled = true;
                this.btnAdd.Enabled = false;
                this.mAction = NumlockAction.ADD;
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.numlockControl_UserKeyPressed(this.numlockControl, new FTS.BaseUI.Controls.KeyboardEventArgs("{ENTER}"));
                return true;
            }
            else if(keyData == Keys.Add)
            {
                this.btnAdd_Click(this.btnAdd,new EventArgs());
                return true;
            }
            else if (keyData == Keys.Subtract)
            {
                this.btnSub_Click(this.btnSub, new EventArgs());
                return true;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }
    }
    public enum NumlockAction
    {
        NONE =0,
        ADD =1,
        SUB =2
    }
}