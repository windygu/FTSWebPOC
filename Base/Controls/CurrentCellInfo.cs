#region

using System;
using DevExpress.XtraGrid.Columns;

#endregion

namespace FTS.BaseUI.Controls{
    public class CurrentCellInfo : Object {
        private object mValue;
        private int mRowHandle;
        private GridColumn mColumn;

        public CurrentCellInfo(object value, int rowHandle, GridColumn column) {
            this.mValue = value;
            this.mRowHandle = rowHandle;
            this.mColumn = column;
        }

        public object Value {
            get { return this.mValue; }
            set { this.mValue = value; }
        }

        public int RowHandle {
            get { return this.mRowHandle; }
            set { this.mRowHandle = value; }
        }

        public GridColumn Column {
            get { return this.mColumn; }
            set { this.mColumn = value; }
        }
    }
}