#region

using System;

#endregion

namespace FTS.BaseUI.Controls {
    public class GoItemToolbarEventArgs : EventArgs {
        private object mKey;

        public GoItemToolbarEventArgs(object key) {
            this.mKey = key;
        }

        public object Key {
            get { return this.mKey; }
        }
    }
}