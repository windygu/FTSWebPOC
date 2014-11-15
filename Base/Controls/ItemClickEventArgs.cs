// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:50
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         ItemClickEventArgs.cs
// Project Item Filename:     ItemClickEventArgs.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace FTS.BaseUI.Controls {
    public class ItemClickEventArgs : EventArgs {
        private string ItemName;

        public ItemClickEventArgs(string itemName) {
            this.ItemName = itemName;
        }

        public string Name {
            get { return this.ItemName.Trim(); }
        }
    }
}