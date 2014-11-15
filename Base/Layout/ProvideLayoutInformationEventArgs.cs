#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for ProvideLayoutInformationEventArgs.
    /// </summary>
    public class ProvideLayoutInformationEventArgs : EventArgs {
        // Fields
        private Control control;
        private bool handled;
        private LayoutInformationType requestedInfoType;
        private Size size;

        public ProvideLayoutInformationEventArgs(Control control, LayoutInformationType requested) {
            this.handled = false;
            this.control = control;
            this.requestedInfoType = requested;
            this.size = Size.Empty;
        }

        public Control Control {
            get { return this.control; }
        }

        public bool Handled {
            get { return this.handled; }
            set { this.handled = value; }
        }

        public LayoutInformationType Requested {
            get { return this.requestedInfoType; }
        }

        public Size Size {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}