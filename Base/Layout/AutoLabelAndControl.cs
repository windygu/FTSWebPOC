#region

using System;
using System.Drawing;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for AutoLabelAndControl.
    /// </summary>
    internal class AutoLabelAndControl {
        // Fields
        private ControlBounds al;
        private int alDX;
        private int alDY;
        private AutoLabelPosition alPosition;
        private ControlBounds c;
        private int height;
        private bool updating;
        private int width;
        private int x;
        private int y;

        internal AutoLabelAndControl(ControlBounds c) {
            this.updating = false;
            this.al = null;
            this.c = c;
            this.Init();
        }

        internal AutoLabelAndControl(ControlBounds al, AutoLabelPosition position, int dx, int dy, ControlBounds c) {
            this.updating = false;
            this.al = al;
            this.c = c;
            this.alPosition = position;
            this.alDX = dx;
            this.alDY = dy;
            this.Init();
        }

        public void BeginUpdate() {
            if (this.updating) {
                throw new Exception("Multiple BeginUpdates not allowed on AutoLabelAndControl.");
            }
            this.c.BeginUpdate();
            this.updating = true;
        }

        public void EndUpdate() {
            if (!this.updating) {
                throw new Exception("EndUpdate called without calling BeginUpdate in AutoLabelAndControl.");
            }
            this.updating = false;
            this.c.EndUpdate();
            if (this.al != null) {
                this.al.ReinitLocation();
            }
            this.Init();
        }

        private void Init() {
            if (this.al != null) {
                if (this.alPosition == AutoLabelPosition.Left) {
                    this.x = this.al.Location.X;
                    if (this.c.Location.Y < this.al.Location.Y) {
                        this.y = this.c.Location.Y;
                    } else {
                        this.y = this.al.Location.Y;
                    }
                    this.width = this.c.Width + -this.alDX;
                    this.height = Math.Max(this.al.Height, this.c.Height);
                } else if (this.alPosition == AutoLabelPosition.Top) {
                    this.y = this.al.Location.Y;
                    if (this.c.Location.X < this.al.Location.X) {
                        this.x = this.c.Location.X;
                    } else {
                        this.x = this.al.Location.X;
                    }
                    this.height = this.c.Height + -this.alDY;
                    this.width = Math.Max(this.al.Width, this.c.Width);
                } else {
                    if (this.c.Location.Y < this.al.Location.Y) {
                        this.y = this.c.Location.Y;
                        if (this.al.Bounds.Bottom > this.c.Bounds.Bottom) {
                            this.height = this.al.Bounds.Bottom - this.c.Location.Y;
                        } else {
                            this.height = this.c.Height;
                        }
                    } else {
                        this.y = this.al.Location.Y;
                        if (this.c.Bounds.Bottom > this.al.Bounds.Bottom) {
                            this.height = this.c.Bounds.Bottom - this.al.Location.Y;
                        } else {
                            this.height = this.al.Height;
                        }
                    }
                    if (this.c.Location.X < this.al.Location.X) {
                        this.x = this.c.Location.X;
                        if (this.al.Bounds.Right > this.c.Bounds.Right) {
                            this.width = this.al.Bounds.Right - this.c.Location.X;
                        } else {
                            this.width = this.c.Width;
                        }
                    } else {
                        this.x = this.al.Location.X;
                        if (this.c.Bounds.Right > this.al.Bounds.Right) {
                            this.width = this.c.Bounds.Right - this.al.Location.X;
                        } else {
                            this.width = this.al.Width;
                        }
                    }
                }
            } else {
                this.x = this.c.Location.X;
                this.y = this.c.Location.Y;
                this.width = this.c.Width;
                this.height = this.c.Height;
            }
        }

        public int Height {
            get { return this.height; }
            set {
                int num1 = value - this.Height;
                this.c.Height += num1;
                if (!this.updating) {
                    this.Init();
                }
            }
        }

        public Point Location {
            get { return new Point(this.x, this.y); }
            set {
                if (this.Location != value) {
                    int num1 = this.x - value.X;
                    this.x -= num1;
                    int num2 = this.y - value.Y;
                    this.y -= num2;
                    this.c.Location = new Point(this.c.Location.X - num1, this.c.Location.Y - num2);
                }
            }
        }

        public int Width {
            get { return this.width; }
            set {
                int num1 = value - this.Width;
                this.c.Width += num1;
                if (!this.updating) {
                    this.Init();
                }
            }
        }
    }
}