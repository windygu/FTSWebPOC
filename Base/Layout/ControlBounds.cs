#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for ControlBounds.
    /// </summary>
    public class ControlBounds {
        // Fields
        private Rectangle bounds;
        private Control c;
        private bool needRTLTransform;
        private RTLMatrix rtlMatrix;
        private bool updating;

        public ControlBounds(Rectangle bounds, Control c, RTLMatrix rtlMatrix) {
            this.updating = false;
            this.bounds = bounds;
            this.c = c;
            this.rtlMatrix = rtlMatrix;
            this.needRTLTransform = this.rtlMatrix != null;
            if (this.NeedRTLTransform) {
                this.bounds = this.RTLTransformRect(this.bounds);
            }
        }

        public ControlBounds(Rectangle bounds, Control c) : this(bounds, c, null) {
        }

        public void BeginUpdate() {
            if (this.updating) {
                throw new Exception("Multiple BeginUpdates not allowed on ControlBounds.");
            }
            this.updating = true;
        }

        public void EndUpdate() {
            if (!this.updating) {
                throw new Exception("EndUpdate called without calling BeginUpdate in ControlBounds.");
            }
            this.updating = false;
            this.UpdateControlBounds();
        }

        internal void ReinitLocation() {
            if (this.needRTLTransform) {
                Rectangle rectangle1 = this.RTLTransformRect(this.c.Bounds);
                rectangle1.Size = this.bounds.Size;
                this.bounds = rectangle1;
            } else {
                this.bounds.Location = this.c.Location;
            }
        }

        private Rectangle RTLTransformRect(Rectangle rect) {
            Point point1 = this.rtlMatrix.TransformPoint(new Point(rect.Left, rect.Top));
            point1.X -= rect.Width;
            return new Rectangle(point1, rect.Size);
        }

        internal void SetOnlyInternalBounds(Rectangle newBounds) {
            this.bounds = newBounds;
        }

        public override string ToString() {
            return this.bounds.ToString();
        }

        private void UpdateControlBounds() {
            if (!this.NeedRTLTransform) {
                this.c.Bounds = this.bounds;
            } else {
                this.c.Bounds = this.RTLTransformRect(this.bounds);
            }
        }

        public Rectangle Bounds {
            get { return this.bounds; }
            set {
                this.bounds = value;
                if (!this.updating) {
                    this.UpdateControlBounds();
                }
            }
        }

        public int Height {
            get { return this.bounds.Height; }
            set {
                this.bounds.Height = value;
                if (!this.updating) {
                    this.c.Height = value;
                }
            }
        }

        public Point Location {
            get { return new Point(this.bounds.X, this.bounds.Y); }
            set {
                this.bounds.X = value.X;
                this.bounds.Y = value.Y;
                if (!this.updating) {
                    if (!this.NeedRTLTransform) {
                        this.c.Location = value;
                    } else {
                        Point point1 = this.rtlMatrix.TransformPoint(value);
                        point1.X -= this.Width;
                        this.c.Location = point1;
                    }
                }
            }
        }

        private bool NeedRTLTransform {
            get { return this.needRTLTransform; }
        }

        public int Width {
            get { return this.bounds.Width; }
            set {
                this.bounds.Width = value;
                if (!this.updating) {
                    if (!this.NeedRTLTransform) {
                        this.c.Width = value;
                    } else {
                        Rectangle rectangle1 = this.bounds;
                        rectangle1.Width = value;
                        Rectangle rectangle2 = this.RTLTransformRect(rectangle1);
                        this.c.Location = new Point(rectangle2.X, this.c.Location.Y);
                        this.c.Width = rectangle2.Width;
                    }
                }
            }
        }
    }
}