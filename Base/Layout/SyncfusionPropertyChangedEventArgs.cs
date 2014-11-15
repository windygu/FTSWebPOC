namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for SyncfusionPropertyChangedEventArgs.
    /// </summary>
    public class SyncfusionPropertyChangedEventArgs : PropertyChangedEventArgs {
        // Fields
        private object newValue;
        private object oldValue;
        private PropertyChangeEffect propertyChangeType;

        public SyncfusionPropertyChangedEventArgs(PropertyChangeEffect propertyChangeType, string propertyName,
                                                  object oldValue, object newValue) : base(propertyName) {
            this.propertyChangeType = propertyChangeType;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public object NewValue {
            get { return this.newValue; }
            set { this.newValue = value; }
        }

        public object OldValue {
            get { return this.oldValue; }
            set { this.oldValue = value; }
        }

        public PropertyChangeEffect PropertyChangeEffect {
            get { return this.propertyChangeType; }
            set { this.propertyChangeType = value; }
        }
    }
}