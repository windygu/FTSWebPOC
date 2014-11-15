#region

using System.ComponentModel;
using DevExpress.XtraEditors;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSMRUEdit : MRUEdit {
        public FTSMRUEdit() {
            this.InitializeComponent();
        }

        public FTSMRUEdit(IContainer container) {
            container.Add(this);
            this.InitializeComponent();
        }
    }
}