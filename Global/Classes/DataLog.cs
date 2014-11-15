using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTS.Global.Classes
{
    [Serializable]
    public class DataLog
    {
        private string mTableName = string.Empty;
        private string mObjectValue = string.Empty;
        private string mUser_Id = string.Empty;

        public DataLog(string tablename, string objectvalue, string userid)
        {
            this.mTableName = tablename;
            this.mObjectValue = objectvalue;
            this.mUser_Id = userid;
        }
        public string TableName
        {
            get { return this.mTableName; }
            set { this.mTableName = value; }
        }
        public string ObjectValue
        {
            get { return this.mObjectValue; }
            set { this.mObjectValue = value; }
        }
        public string User_Id
        {
            get { return this.mUser_Id; }
            set { this.mUser_Id = value; }
        }
    }
}
