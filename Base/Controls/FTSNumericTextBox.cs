#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSNumericTextBox : TextEdit {
        public FTSNumericTextBox() {
            this.InitializeComponent();
            this.SetProperty();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        protected void SetProperty() {
            this.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.RightToLeft = RightToLeft.No;
            this.Properties.AppearanceDisabled.TextOptions.HAlignment = HorzAlignment.Far;
            this.Properties.DisplayFormat.FormatString = "n0";
            this.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.Properties.EditFormat.FormatString = "n0";
            this.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.Properties.Mask.EditMask = "n0";
            this.Properties.Mask.MaskType = MaskType.Numeric;
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Spin += new SpinEventHandler(this.DisableMouseWheel);
        }

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void SetDecimalPlace(int digits) {
            this.Properties.DisplayFormat.FormatString = "n" + digits.ToString().Trim();
            this.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.Properties.EditFormat.FormatString = "n" + digits.ToString().Trim();
            this.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.Properties.Mask.EditMask = "n" + digits.ToString().Trim();
            this.Properties.Mask.MaskType = MaskType.Numeric;
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private bool mIsUnderline = false;

        [DefaultValue(false)]
        public bool IsUnderline {
            get { return this.mIsUnderline; }
            set { this.mIsUnderline = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (this.mIsUnderline) {
                GraphicsCache cache = new GraphicsCache(e);
                try {
                    Graphics gfx = e.Graphics;
                    SmoothingMode mode = gfx.SmoothingMode;
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.DarkGray)) {
                        gfx.DrawLine(pen, 0, this.Height - 3, this.Width, this.Height - 3);
                    }
                    gfx.SmoothingMode = mode;
                } catch (Exception) {
                } finally {
                    cache.Dispose();
                }
            }
        }
    }
}