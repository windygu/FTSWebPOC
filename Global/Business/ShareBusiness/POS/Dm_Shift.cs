using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    public class Dm_Shift : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private int mActive;
        public int Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private int mEnd_Hour;
        public int End_Hour
        {
            get { return mEnd_Hour; }
            set { mEnd_Hour = value; }
        }
        private int mEnd_Minute;
        public int End_Minute
        {
            get { return mEnd_Minute; }
            set { mEnd_Minute = value; }
        }
        private string mShift_Id;
        public string Shift_Id
        {
            get { return mShift_Id; }
            set { mShift_Id = value; }
        }
        private string mShift_Name;
        public string Shift_Name
        {
            get { return mShift_Name; }
            set { mShift_Name = value; }
        }
        private int mStart_Hour;
        public int Start_Hour
        {
            get { return mStart_Hour; }
            set { mStart_Hour = value; }
        }
        private int mStart_Minute;
        public int Start_Minute
        {
            get { return mStart_Minute; }
            set { mStart_Minute = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
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
