#region

using DevExpress.XtraGrid.Columns;

#endregion

namespace FTS.BaseUI.Controls {
    public class FTSGridColumn : GridColumn, IRequire {
        private bool mRequire = false;

        public FTSGridColumn() : base() {
        }

        public bool Require {
            get { return this.mRequire; }
            set { this.mRequire = value; }
        }
    }
}