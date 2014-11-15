using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    public class Dm_Prints : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mPrints_Id;
        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mPrints_Name;
        public string Prints_Name
        {
            get { return mPrints_Name; }
            set { mPrints_Name = value; }
        }
        private string mPrints_Type_Id;

        public string Prints_Type_Id
        {
            get { return mPrints_Type_Id; }
            set { mPrints_Type_Id = value; }
        }
        private string mUnit_Id;

        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        
        private int mBatch_Quantity;

        public int Batch_Quantity
        {
            get { return mBatch_Quantity; }
            set { mBatch_Quantity = value; }
        }
        
        //
        private int mActive;
        public int Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }

        private int mTotal_Character;
        public int Total_Character {
            get { return mTotal_Character; }
            set { mTotal_Character = value; }
        }

        private string mTemplate_Prints;
        public string Template_Prints {
            get { return mTemplate_Prints; }
            set { mTemplate_Prints = value; }
        }
        private string mAccount_Id_Cost;
        public string Account_Id_Cost
        {
            get { return mAccount_Id_Cost; }
            set { mAccount_Id_Cost = value; }
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
