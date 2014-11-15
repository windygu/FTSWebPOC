using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    public class Dm_Pump : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private int mActive;
        public int Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mPump_Id;
        public string Pump_Id
        {
            get { return mPump_Id; }
            set { mPump_Id = value; }
        }
        private string mPump_Name;
        public string Pump_Name
        {
            get { return mPump_Name; }
            set { mPump_Name = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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
