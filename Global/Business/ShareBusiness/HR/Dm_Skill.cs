using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Skill : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mDm_Skill_Id;
        public string Dm_Skill_Id
        {
            get { return mDm_Skill_Id; }
            set { mDm_Skill_Id = value; }
        }
        private string mDm_Skill_Name;
        public string Dm_Skill_Name
        {
            get { return mDm_Skill_Name; }
            set { mDm_Skill_Name = value; }
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