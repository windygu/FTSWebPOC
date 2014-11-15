#region

using System.Drawing;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSListBox : ListBox {
        public FTSListBox() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }
    }
}