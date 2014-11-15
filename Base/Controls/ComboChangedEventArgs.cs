#region

using System;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;

#endregion

namespace FTS.BaseUI.Controls {
    public class ComboChangedEventArgs : EventArgs {
        private ItemCombobox mItem = null;

        public ComboChangedEventArgs(ItemCombobox item) {
            this.mItem = item;
        }

        public ItemCombobox Item {
            get { return this.mItem; }
        }
    }
}