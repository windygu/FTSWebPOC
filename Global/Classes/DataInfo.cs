#region

using System;
using System.Collections.Generic;

#endregion

namespace FTS.Global.Classes{
    [Serializable]
    public class DataInfo{
        private List<DataLog> mRows = new List<DataLog>();
        private string mCondition = "(";
        
        public DataInfo(){            
        }        

        public string Condition{
            get { return this.mCondition; }
            set { this.mCondition = value; }
        }

        public List<DataLog> Rows
        {
            get { return this.mRows; }
        }        
    }
}