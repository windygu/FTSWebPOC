using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Floor : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private byte[] mBack_Ground_Image;
        public byte[] Back_Ground_Image
        {
            get { return mBack_Ground_Image; }
            set { mBack_Ground_Image = value; }
        }
        private string mBuilding_Id;
        public string Building_Id
        {
            get { return mBuilding_Id; }
            set { mBuilding_Id = value; }
        }
        private string mFloor_Id;
        public string Floor_Id
        {
            get { return mFloor_Id; }
            set { mFloor_Id = value; }
        }
        private string mFloor_Name;
        public string Floor_Name
        {
            get { return mFloor_Name; }
            set { mFloor_Name = value; }
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