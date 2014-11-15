#region

using System.Drawing;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSPage : Panel {
        private bool mLandscape = false;
        private int mTopMargin = 5;
        private int mLeftMargin = 5;
        private int mBottomMargin = 5;
        private int mRightMargin = 5;

        public FTSPage() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        protected override void OnPaint(PaintEventArgs e) {
            SolidBrush brush1 = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.White);
            if (!this.mLandscape) {
                e.Graphics.FillRectangle(brush1, new Rectangle(24, 4, 100, 144));
                e.Graphics.FillRectangle(brush2, new Rectangle(20, 0, 100, 140));
                e.Graphics.DrawLine(new Pen(brush1), new Point(20, 0), new Point(120, 0));
                e.Graphics.DrawLine(new Pen(brush1), new Point(120, 0), new Point(120, 140));
                e.Graphics.DrawLine(new Pen(brush1), new Point(20, 140), new Point(120, 140));
                e.Graphics.DrawLine(new Pen(brush1), new Point(20, 0), new Point(20, 140));
                for (int i = 0; i < 7; i++) {
                    if (this.mTopMargin + 20*i < 140 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(20 + 8 + this.mLeftMargin, this.mTopMargin + 20*i),
                                            new Point(20 + 100 - this.mRightMargin, this.mTopMargin + 20*i));
                    }
                    if (this.mTopMargin + 4 + 20*i < 140 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(20 + this.mLeftMargin, this.mTopMargin + 4 + 20*i),
                                            new Point(20 + 100 - this.mRightMargin, this.mTopMargin + 4 + 20*i));
                    }
                    if (this.mTopMargin + 8 + 20*i < 140 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(20 + this.mLeftMargin, this.mTopMargin + 8 + 20*i),
                                            new Point(60, this.mTopMargin + 8 + 20*i));
                    }
                }
            } else {
                e.Graphics.FillRectangle(brush1, new Rectangle(4, 24, 144, 100));
                e.Graphics.FillRectangle(brush2, new Rectangle(0, 20, 140, 100));
                e.Graphics.DrawLine(new Pen(brush1), new Point(0, 20), new Point(140, 20));
                e.Graphics.DrawLine(new Pen(brush1), new Point(140, 20), new Point(140, 120));
                e.Graphics.DrawLine(new Pen(brush1), new Point(0, 120), new Point(140, 120));
                e.Graphics.DrawLine(new Pen(brush1), new Point(0, 20), new Point(0, 120));
                for (int i = 0; i < 5; i++) {
                    if (20 + this.mTopMargin + 20*i < 120 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(8 + this.mLeftMargin, 20 + this.mTopMargin + 20*i),
                                            new Point(140 - this.mRightMargin, 20 + this.mTopMargin + 20*i));
                    }
                    if (20 + this.mTopMargin + 4 + 20*i < 120 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(this.mLeftMargin, 20 + this.mTopMargin + 4 + 20*i),
                                            new Point(140 - this.mRightMargin, 20 + this.mTopMargin + 4 + 20*i));
                    }
                    if (20 + this.mTopMargin + 8 + 20*i < 120 - this.mBottomMargin) {
                        e.Graphics.DrawLine(new Pen(brush1),
                                            new Point(this.mLeftMargin, 20 + this.mTopMargin + 8 + 20*i),
                                            new Point(60, 20 + this.mTopMargin + 8 + 20*i));
                    }
                }
            }
        }

        public bool Landscape {
            get { return this.mLandscape; }
            set {
                this.mLandscape = value;
                this.Invalidate();
            }
        }

        public int TopMargin {
            get { return this.mTopMargin; }
            set {
                this.mTopMargin = value;
                this.Invalidate();
            }
        }

        public int LeftMargin {
            get { return this.mLeftMargin; }
            set {
                this.mLeftMargin = value;
                this.Invalidate();
            }
        }

        public int BottomMargin {
            get { return this.mBottomMargin; }
            set {
                this.mBottomMargin = value;
                this.Invalidate();
            }
        }

        public int RightMargin {
            get { return this.mRightMargin; }
            set {
                this.mRightMargin = value;
                this.Invalidate();
            }
        }
    }
}