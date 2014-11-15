#region

using System;
using System.Collections;
using System.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;

#endregion

namespace FTS.BaseUI.Controls {
    public class GridCheckHeaderColumn {
        private GridColumn mColumn;
        private RepositoryItemCheckEdit mItemCheck;
        private ArrayList mSelection;

        public GridCheckHeaderColumn(GridColumn column, RepositoryItemCheckEdit itemcheck) {
            this.mColumn = column;
            this.mItemCheck = itemcheck;
            this.mSelection = new ArrayList();
        }

        public void DrawCheckBox(Graphics g, Rectangle r, bool check) {
            CheckEditViewInfo info;
            CheckEditPainter painter;
            ControlGraphicsInfoArgs args;
            info = this.mItemCheck.CreateViewInfo() as CheckEditViewInfo;
            painter = this.mItemCheck.CreatePainter() as CheckEditPainter;
            info.EditValue = check ? Convert.ToInt16(1) : Convert.ToInt16(0);
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        public GridColumn Column {
            get { return this.mColumn; }
            set { this.mColumn = value; }
        }

        public RepositoryItemCheckEdit ItemCheck {
            get { return this.mItemCheck; }
            set { this.mItemCheck = value; }
        }

        public ArrayList Selection {
            get { return this.mSelection; }
            set { this.mSelection = value; }
        }
    }
}