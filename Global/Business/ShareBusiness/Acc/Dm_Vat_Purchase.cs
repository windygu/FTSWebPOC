using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Vat_Purchase : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mVat_Purchase_Id;
        public string Vat_Purchase_Id
        {
            get { return mVat_Purchase_Id; }
            set { mVat_Purchase_Id = value; }
        }
        private string mVat_Purchase_Name;
        public string Vat_Purchase_Name
        {
            get { return mVat_Purchase_Name; }
            set { mVat_Purchase_Name = value; }
        }


        #region IHead Members

        public DataState DataState
        {
            get
            {
                return this.mDataState;
            }
            set
            {
                this.mDataState = value;
            }
        }

        public object IdValue
        {
            get
            {
                return this.mIdValue;
            }
            set
            {
                this.mIdValue = value;
            }
        }

        #endregion
    }
}