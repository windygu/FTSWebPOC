#region

using System.Data;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmShowData : Form {
        public FrmShowData(DataTable dt) {
            this.InitializeComponent();
            this.LoadData(dt);
        }

        private void LoadData(DataTable dt) {
            this.grid.DataSource = dt;
        }
    }
}