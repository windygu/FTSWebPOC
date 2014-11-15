#region

using System.Drawing;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSGroupBox : GroupControl {
        public FTSGroupBox() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Appearance.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.Options.UseFont = true;
            this.AppearanceCaption.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.AppearanceCaption.Options.UseFont = true;
        }
    }
}