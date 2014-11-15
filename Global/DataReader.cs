#region

using System;
using System.Data;

#endregion

namespace FTS.Global{
    [Serializable]
    public class DataReader{
        private IDataReader mIDataReader;

        public DataReader(IDataReader idatareader){
            this.mIDataReader = idatareader;
        }

        public IDataReader IDataReader{
            get { return this.mIDataReader; }
        }
    }
}