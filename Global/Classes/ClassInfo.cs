#region

using System;
using System.Data;
using System.Collections.Generic;

#endregion

namespace FTS.Global.Classes{
    public class ClassInfo{
        private string mTableName = string.Empty;
        private string mDescription = string.Empty;
        private string mIdField = string.Empty;
        private DbType mIdType = DbType.String;
        private List<IdField> mIdFieldEx = new List<IdField>();   
        private Type mType;
        private TransferType mTransferType = TransferType.Data;
        
        public ClassInfo(string tableName, string description, string idField, DbType idType, Type type){
            this.mTableName = tableName;
            this.mDescription = description;
            this.mIdField = idField;
            this.mIdType = idType;
            this.mType = type;
            this.mTransferType = TransferType.Data;
        }
        public ClassInfo(string tableName, string description, string idField, DbType idType, Type type, List<IdField> idfieldex): this(tableName, description, idField, idType, type)
        {
            this.mIdFieldEx = idfieldex;            
        }        
        public ClassInfo(string tableName, string description, string idField, DbType idType, Type type, TransferType transfertype):this(tableName,description,idField,idType,type)
        {
            this.mTransferType = transfertype;
        }
        public ClassInfo(string tableName, string description, string idField, DbType idType, Type type, TransferType transfertype, List<IdField> idfieldex): this(tableName, description, idField, idType, type, transfertype)
        {
            this.mIdFieldEx = idfieldex;
        }              
        public string TableName{
            get { return this.mTableName; }
        }

        public string Description{
            get { return this.mDescription; }
        }

        public string IdField{
            get { return this.mIdField; }
        }

        public DbType IdType{
            get { return this.mIdType; }
        }

        public Type Type{
            get { return this.mType; }
        }

        public TransferType TransferType
        {
            get { return this.mTransferType; }
        }

        public List<IdField> IdFieldEx
        {
            get { return this.mIdFieldEx; }
        }

        public string IdFields
        {
            get {
                string idfields = string.Empty;
                foreach (IdField field in this.mIdFieldEx)
                {
                    idfields = idfields + "," + field.Field;
                }
                return idfields.Substring(1);
            }
        }
    }    
    public enum TransferType
    {
        Data = 0,
        Command = 1
    }
    public class IdField
    {
        private string mField = string.Empty;
        private DbType mType = DbType.String;

        public IdField()
        {}
        public IdField(string field, DbType type)
        {
            this.mField = field;
            this.mType = type;
        }
        public string Field
        {
            get { return this.mField;}
        }
        public DbType Type
        {
            get { return this.mType;}
        }
    }
}