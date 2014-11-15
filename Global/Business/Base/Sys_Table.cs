using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sys_Table : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mTableName;
        public string TableName
        {
            get { return mTableName; }
            set { mTableName = value; }
        }
        private string mId_Field;
        public string Id_Field
        {
            get { return mId_Field; }
            set { mId_Field = value; }
        }
        private string mName_Field;
        public string Name_Field
        {
            get { return mName_Field; }
            set { mName_Field = value; }
        }
        private string mTable_Type;
        public string Table_Type
        {
            get { return mTable_Type; }
            set { mTable_Type = value; }
        }
        private Int16 mBackups;
        public Int16 Backups
        {
            get { return mBackups; }
            set { mBackups = value; }
        }
        private Int32 mNum_Order;
        public Int32 Num_Order
        {
            get { return mNum_Order; }
            set { mNum_Order = value; }
        }
        private Int32 mRes_Order;
        public Int32 Res_Order
        {
            get { return mRes_Order; }
            set { mRes_Order = value; }
        }
        private Int16 mCan_Group;
        public Int16 Can_Group
        {
            get { return mCan_Group; }
            set { mCan_Group = value; }
        }
        private Int16 mId_Auto;
        public Int16 Id_Auto
        {
            get { return mId_Auto; }
            set { mId_Auto = value; }
        }
        private string mId_Mask;
        public string Id_Mask
        {
            get { return mId_Mask; }
            set { mId_Mask = value; }
        }
        private Int32 mId_Length;
        public Int32 Id_Length
        {
            get { return mId_Length; }
            set { mId_Length = value; }
        }
        private Int32 mId_Parts;
        public Int32 Id_Parts
        {
            get { return mId_Parts; }
            set { mId_Parts = value; }
        }
        private string mId_Split;
        public string Id_Split
        {
            get { return mId_Split; }
            set { mId_Split = value; }
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