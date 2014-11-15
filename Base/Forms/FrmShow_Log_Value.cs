#region

using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmShow_Log_Value : FrmBaseForm {
        public FrmShow_Log_Value() {
            this.InitializeComponent();
        }

        public FrmShow_Log_Value(FTSMain ftsMain, string value) : base(ftsMain, true) {
            this.InitializeComponent();
            this.memo.EditValue = value;
        }
    }
}