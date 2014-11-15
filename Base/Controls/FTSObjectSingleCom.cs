#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSObjectSingleCom : XtraUserControl, IHelpField {
        private FTSMain mFTSMain;
        private DataTable mTableObject;
        private string mTableName = string.Empty;
        private string mNameField = string.Empty;
        private string mOldObject = string.Empty;

        public FTSObjectSingleCom() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        public void Set(FTSMain ftsMain, DataTable tableObject, string tableName) {
            this.mFTSMain = ftsMain;
            this.mTableObject = tableObject;
            this.mTableName = tableName;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
        }

        public string TextGroup {
            get { return this.grpObject.Text; }
            set { this.grpObject.Text = value; }
        }

        [Browsable(false)]
        public string Object {
            get { return this.ObjectId.Text; }
            set { this.ObjectId.Text = value; }
        }

        private void ObjectId_TextChanged(object sender, EventArgs e) {
            try {
                if (this.ObjectId.Text != this.mOldObject) {
                    DataRow foundrow = this.mTableObject.Rows.Find(this.ObjectId.Text);
                    if (foundrow != null) {
                        this.txtObject.Text = foundrow[this.mNameField].ToString();
                    } else {
                        this.txtObject.Text = string.Empty;
                    }
                }
            } catch (Exception) {
                this.txtObject.Text = string.Empty;
            }
            this.mOldObject = this.ObjectId.Text;
        }

        #region IHelpField Members

        private string mHelpText = string.Empty;

        public string HelpText {
            get { return this.mHelpText; }
            set {
                this.mHelpText = value;
                FTSForm form = this.FindForm() as FTSForm;
                if (form != null) {
                    form.SetBalloonTooltip(this, this.mHelpText);
                    form.SetBalloonTooltip(this.txtObject, this.mHelpText);
                }
            }
        }

        #endregion
    }
}