#region

using System;
using System.Data;

#endregion

namespace FTS.Global{
    [Serializable]
    public class Parameter{
        private DbType mDbType;
        private ParameterDirection mDirection;
        private string mParameterName = string.Empty;
        private int mSize;
        private string mSourceColumn = string.Empty;
        private bool mSourceColumnNullMapping;
        private DataRowVersion mSourceVersion;
        private Object mValue;

        public Parameter()
        {
            this.mDbType = DbType.String;
            this.mDirection = ParameterDirection.Input;
            this.mParameterName = string.Empty;
            this.mSize = 8;
            this.mSourceColumn = string.Empty;
            this.mSourceColumnNullMapping = true;
            this.mSourceVersion = DataRowVersion.Default;
            this.mValue = string.Empty;
        }

        public Parameter(DbType dbtype, ParameterDirection direction, string parametername, int size,
                         string sourcecolumn, bool sourcecolumnnullmapping, DataRowVersion sourceversion, object value){
            this.mDbType = dbtype;
            this.mDirection = direction;
            this.mParameterName = parametername;
            this.mSize = size;
            this.mSourceColumn = sourcecolumn;
            this.mSourceColumnNullMapping = sourcecolumnnullmapping;
            this.mSourceVersion = sourceversion;
            this.mValue = value;
        }

        public DbType DbType{
            get { return this.mDbType; }
            set { this.mDbType = value; }
        }

        public ParameterDirection Direction{
            get { return this.mDirection; }
            set { this.mDirection = value; }
        }

        public string ParameterName{
            get { return this.mParameterName; }
            set { this.mParameterName = value; }
        }

        public int Size{
            get { return this.mSize; }
            set { this.mSize = value; }
        }

        public string SourceColumn{
            get { return this.mSourceColumn; }
            set { this.mSourceColumn = value; }
        }

        public bool SourceColumnNullMapping{
            get { return this.mSourceColumnNullMapping; }
            set { this.mSourceColumnNullMapping = value; }
        }

        public DataRowVersion SourceVersion{
            get { return this.mSourceVersion; }
            set { this.mSourceVersion = value; }
        }

        public object Value{
            get { return this.mValue; }
            set { this.mValue = value; }
        }
    }
}