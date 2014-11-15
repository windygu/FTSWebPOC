#region

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSLabel : Label, IHelpField {
        private bool useEnable = false;

        public FTSLabel() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (this.useEnable) {
                Color color = e.Graphics.GetNearestColor(base.Enabled ? this.ForeColor : this.DisabledColor);
                StringFormat format = this.CreateStringFormat();
                if (base.Enabled) {
                    using (Brush brush = new SolidBrush(color)) {
                        e.Graphics.DrawString(this.Text, this.Font, brush, (RectangleF) base.ClientRectangle, format);
                    }
                } else {
                    ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Font, color,
                                                    (RectangleF) base.ClientRectangle, format);
                }
                format.Dispose();
            } else {
                Color color = e.Graphics.GetNearestColor(this.ForeColor);
                StringFormat format = this.CreateStringFormat();
                using (Brush brush = new SolidBrush(color)) {
                    e.Graphics.DrawString(this.Text, this.Font, brush, (RectangleF) base.ClientRectangle, format);
                }
                format.Dispose();
            }
        }

        private StringAlignment TranslateAlignment(ContentAlignment align) {
            if ((align & FTSControlPaint.anyRight) != ((ContentAlignment) 0)) {
                return StringAlignment.Far;
            }
            if ((align & FTSControlPaint.anyCenter) != ((ContentAlignment) 0)) {
                return StringAlignment.Center;
            }
            return StringAlignment.Near;
        }

        private StringAlignment TranslateLineAlignment(ContentAlignment align) {
            if ((align & FTSControlPaint.anyBottom) != ((ContentAlignment) 0)) {
                return StringAlignment.Far;
            }
            if ((align & FTSControlPaint.anyMiddle) != ((ContentAlignment) 0)) {
                return StringAlignment.Center;
            }
            return StringAlignment.Near;
        }

        private StringFormat StringFormatForAlignment(ContentAlignment align) {
            StringFormat format = new StringFormat();
            format.Alignment = this.TranslateAlignment(align);
            format.LineAlignment = this.TranslateLineAlignment(align);
            return format;
        }

        private StringFormat CreateStringFormat() {
            StringFormat format = this.StringFormatForAlignment(this.TextAlign);
            if (this.RightToLeft == RightToLeft.Yes) {
                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            if (!this.UseMnemonic) {
                format.HotkeyPrefix = HotkeyPrefix.None;
            } else if (base.ShowKeyboardCues) {
                format.HotkeyPrefix = HotkeyPrefix.Show;
            } else {
                format.HotkeyPrefix = HotkeyPrefix.Hide;
            }
            if (this.AutoSize) {
                format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            }
            return format;
        }

        public Color DisabledColor {
            get {
                Color color = this.BackColor;
                if (color.A == 0) {
                    for (Control control = this.Parent; color.A == 0; control = control.Parent) {
                        if (control == null) {
                            return SystemColors.Control;
                        }
                        color = control.BackColor;
                    }
                }
                return color;
            }
        }

        [DefaultValue(false)]
        public bool UseEnable {
            get { return this.useEnable; }
            set { this.useEnable = value; }
        }

        #region IHelpField Members

        private string mHelpText = string.Empty;

        public string HelpText {
            get { return this.mHelpText; }
            set {
                this.mHelpText = value;
                FTSForm form = this.FindForm() as FTSForm;
                if (form != null) {
                    form.SetBalloonTooltip(this, this.mHelpText);
                }
            }
        }

        #endregion
    }
}