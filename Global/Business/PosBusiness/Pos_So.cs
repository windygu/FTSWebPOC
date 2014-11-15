
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Pos_So : IHead
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get
            {
                return mOrganization_Id;
            }
            set
            {
                mOrganization_Id = value;
            }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get
            {
                return mTran_Id;
            }
            set
            {
                mTran_Id = value;
            }
        }
        private string mTran_No;
        public string Tran_No
        {
            get
            {
                return mTran_No;
            }
            set
            {
                mTran_No = value;
            }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get
            {
                return mTran_Date;
            }
            set
            {
                mTran_Date = value;
            }
        }
        private int mTran_Hour;
        public int Tran_Hour
        {
            get
            {
                return mTran_Hour;
            }
            set
            {
                mTran_Hour = value;
            }
        }
        private int mTran_Minute;
        public int Tran_Minute
        {
            get
            {
                return mTran_Minute;
            }
            set
            {
                mTran_Minute = value;
            }
        }
        private Guid mPos_Shift_Pr_key;
        public Guid Pos_Shift_Pr_Key
        {
            get
            {
                return mPos_Shift_Pr_key;
            }
            set
            {
                mPos_Shift_Pr_key = value;
            }
        }
        private string mVat_Tran_No;
        public string Vat_Tran_No
        {
            get
            {
                return mVat_Tran_No;
            }
            set
            {
                mVat_Tran_No = value;
            }
        }
        private DateTime mVat_Tran_Date;
        public DateTime Vat_Tran_Date
        {
            get
            {
                return mVat_Tran_Date;
            }
            set
            {
                mVat_Tran_Date = value;
            }
        }
        private string mVat_Tran_Serie;
        public string Vat_Tran_Serie
        {
            get
            {
                return mVat_Tran_Serie;
            }
            set
            {
                mVat_Tran_Serie = value;
            }
        }
        private string mVat_Purchase_Id;
        public string Vat_Purchase_Id
        {
            get
            {
                return mVat_Purchase_Id;
            }
            set
            {
                mVat_Purchase_Id = value;
            }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get
            {
                return mItem_Source_Id;
            }
            set
            {
                mItem_Source_Id = value;
            }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get
            {
                return mItem_Op_Id;
            }
            set
            {
                mItem_Op_Id = value;
            }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get
            {
                return mWarehouse_Id;
            }
            set
            {
                mWarehouse_Id = value;
            }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get
            {
                return mEmployee_Id;
            }
            set
            {
                mEmployee_Id = value;
            }
        }
        private string mMarket_Id;
        public string Market_Id
        {
            get
            {
                return mMarket_Id;
            }
            set
            {
                mMarket_Id = value;
            }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get
            {
                return mCurrency_Id;
            }
            set
            {
                mCurrency_Id = value;
            }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get
            {
                return mExchange_Rate;
            }
            set
            {
                mExchange_Rate = value;
            }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get
            {
                return mPr_Detail_Id;
            }
            set
            {
                mPr_Detail_Id = value;
            }
        }
        private string mRec_Pr_Detail_Id;
        public string Rec_Pr_Detail_Id
        {
            get
            {
                return mRec_Pr_Detail_Id;
            }
            set
            {
                mRec_Pr_Detail_Id = value;
            }
        }
        private string mPr_Detail_Name;
        public string Pr_Detail_Name
        {
            get
            {
                return mPr_Detail_Name;
            }
            set
            {
                mPr_Detail_Name = value;
            }
        }
        private string mContact_Person;
        public string Contact_Person
        {
            get
            {
                return mContact_Person;
            }
            set
            {
                mContact_Person = value;
            }
        }
        private string mAddress;
        public string Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                mAddress = value;
            }
        }
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get
            {
                return mTax_File_Number;
            }
            set
            {
                mTax_File_Number = value;
            }
        }
        private string mPayment_Method_Id;
        public string Payment_Method_Id
        {
            get
            {
                return mPayment_Method_Id;
            }
            set
            {
                mPayment_Method_Id = value;
            }
        }
        private string mPayment_Term_Id;
        public string Payment_Term_Id
        {
            get
            {
                return mPayment_Term_Id;
            }
            set
            {
                mPayment_Term_Id = value;
            }
        }
        private DateTime mPayment_Date;
        public DateTime Payment_Date
        {
            get
            {
                return mPayment_Date;
            }
            set
            {
                mPayment_Date = value;
            }
        }
        private string mComments;
        public string Comments
        {
            get
            {
                return mComments;
            }
            set
            {
                mComments = value;
            }
        }
        private string mStatus;
        public string Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                mStatus = value;
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
