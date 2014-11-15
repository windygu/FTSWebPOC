// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:55
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FTS.BaseUI.Utilities.FTSMessageBox.cs
// Project Item Filename:     FTS.BaseUI.Utilities.FTSMessageBox.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Utilities {
    public class FTSMessageBox {
        public FTSMessageBox() {
        }

        public static void ShowErrorMessage(string msg) {
            if (msg.Length > 0) {
                XtraMessageBox.Show(msg, RegManager.GetKey("APP_TITLE").ToString(), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        public static void ShowInfoMessage(string msg) {
            if (msg.Length > 0) {
                XtraMessageBox.Show(msg, RegManager.GetKey("APP_TITLE").ToString(), MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        public static DialogResult ShowYesNoMessage(string msg) {
            if (msg.Length > 0) {
                return XtraMessageBox.Show(msg, RegManager.GetKey("APP_TITLE").ToString(), MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
            } else {
                return DialogResult.No;
            }
        }

        public static int ShowYesNoMessage2(string msg)
        {
            if (msg.Length > 0){
                return XtraMessageBox.Show(msg, RegManager.GetKey("APP_TITLE").ToString(), MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0;
            }else{
                return 0;
            }
        }

        public static DialogResult ShowYesNoCancelMessage(string msg) {
            if (msg.Length > 0) {
                return XtraMessageBox.Show(msg, RegManager.GetKey("APP_TITLE").ToString(), MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question);
            } else {
                return DialogResult.Cancel;
            }
        }
    }
}