using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.Utils.Drawing;
using System.Drawing.Drawing2D;
using FTS.BaseUI.Graphic;
using System.Windows.Forms;

namespace FTS.BaseUI.Controls
{
    public class FTSShadowPanel2 : Panel
    {
        private System.ComponentModel.Container components = null;
        private Color mGradientColor = Color.Black;

        public FTSShadowPanel2():base()
        {
            InitializeComponent();           
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            components = new System.ComponentModel.Container();
        }
        #endregion
        private void DrawRoundedRectangle(Graphics g, Pen p, Rectangle rc, Size size)
        {
            SmoothingMode mode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(p, rc.Left + (size.Width / 2), rc.Top, rc.Right - (size.Width / 2), rc.Top);
            g.DrawLine(p, rc.Left, rc.Bottom - (size.Height / 2), rc.Left, rc.Top + (size.Height / 2));
            g.DrawArc(p, rc.Left, rc.Top, size.Width, size.Height, 180, 90);
            g.DrawArc(p, rc.Right - size.Width, rc.Top, size.Width, size.Height, 270, 90);
            g.DrawLine(p, rc.Right, rc.Top + (size.Height / 2), rc.Right, rc.Bottom - (size.Height / 2));
            g.DrawArc(p, rc.Right - size.Width, rc.Bottom - size.Height, size.Width, size.Height, 0, 90);
            g.DrawLine(p, rc.Right - (size.Width / 2), rc.Bottom, rc.Left + (size.Width / 2), rc.Bottom);
            g.DrawArc(p, rc.Left, rc.Bottom - size.Height, size.Width, size.Height, 90, 90);
            g.SmoothingMode = mode;
        }
        private GraphicsPath RoundedRectangle(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(this.Width / 2, 0),
            new Point(this.Width / 2, this.Height), Color.White, this.mGradientColor);
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            rectangle.X++;
            rectangle.Y++;
            rectangle.Width = rectangle.Width - 4;
            rectangle.Height = rectangle.Height - 4;
            GraphicsPath path = this.RoundedRectangle(rectangle, 5, 5, 5, 5);
            e.Graphics.FillPath(gradBrush, path);
            Graphics gfx = e.Graphics;
            SmoothingMode mode = gfx.SmoothingMode;
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = Color.Gray;
            using (Pen pen = new Pen(color))
            {
                this.DrawRoundedRectangle(gfx, pen, rectangle, new Size(16, 16));
            }
            gfx.SmoothingMode = mode;           
        }
        public Color GradientColor
        {
            get { return this.mGradientColor; }
            set { this.mGradientColor = value; }
        }
    }
}
