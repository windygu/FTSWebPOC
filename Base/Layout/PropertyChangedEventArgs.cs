#region

using System;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for PropertyChangedEventArgs.
    /// </summary>
    public class PropertyChangedEventArgs : EventArgs {
        private readonly string propertyName;

        public PropertyChangedEventArgs(string propertyName) {
            this.propertyName = propertyName;
        }

        public virtual string PropertyName {
            get { return this.propertyName; }
        }
    }
}