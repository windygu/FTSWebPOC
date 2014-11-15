
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Pos_Sale_Invoice_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get
            {
                return mPr_Key;
            }
            set
            {
                mPr_Key = value;
            }
        }
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get
            {
                return mFr_Key;
            }
            set
            {
                mFr_Key = value;
            }
        }
        private Guid mPr_Key_Sale_Detail;
        public Guid Pr_Key_Sale_Detail
        {
            get
            {
                return mPr_Key_Sale_Detail;
            }
            set
            {
                mPr_Key_Sale_Detail = value;
            }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get
            {
                return mItem_Id;
            }
            set
            {
                mItem_Id = value;
            }
        }
        private string mDescription;
        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get
            {
                return mUnit_Id;
            }
            set
            {
                mUnit_Id = value;
            }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get
            {
                return mUnit_Price;
            }
            set
            {
                mUnit_Price = value;
            }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get
            {
                return mQuantity;
            }
            set
            {
                mQuantity = value;
            }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get
            {
                return mAmount;
            }
            set
            {
                mAmount = value;
            }
        }
        private decimal mVat_Tax_Rate;
        public decimal Vat_Tax_Rate
        {
            get
            {
                return mVat_Tax_Rate;
            }
            set
            {
                mVat_Tax_Rate = value;
            }
        }
        private decimal mVat_Tax_Amount;
        public decimal Vat_Tax_Amount
        {
            get
            {
                return mVat_Tax_Amount;
            }
            set
            {
                Vat_Tax_Amount = value;
            }
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
