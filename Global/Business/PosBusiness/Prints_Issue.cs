using System;
using FTS.Global.Classes;
using FTS.Global.Interface;

namespace FTS.Global.Business.PosBusiness {
    public class Prints_Issue : IHead {
        
        private DataState mDataState = DataState.NONE;
        
        
        private object mIdValue = string.Empty;
        
        
        private Guid mPr_Key;
        private string mTran_Id;
        private string mTran_No;        
        private DateTime mTran_Date;
        private Guid mPos_Shift_Pr_key;
        private string mReceive_Warehouse_Id;
        private string mOrganization_Id;
        private string mEmployee_Id;
        private string mWarehouse_Id;
        private string mComments;
        private string mExport_Type_Id;        

        public Guid Pr_Key {
            get { return this.mPr_Key; }
            set { this.mPr_Key = value; }
        }

        public string Tran_Id {
            get { return this.mTran_Id; }
            set { this.mTran_Id = value; }
        }

        public string Tran_No {
            get { return this.mTran_No; }
            set { this.mTran_No = value; }
        }

        public DateTime Tran_Date {
            get { return this.mTran_Date; }
            set { this.mTran_Date = value; }
        }

        public string Warehouse_Id {
            get { return this.mWarehouse_Id; }
            set { this.mWarehouse_Id = value; }
        }

        public string Receive_Warehouse_Id {
            get { return this.mReceive_Warehouse_Id; }
            set { this.mReceive_Warehouse_Id = value; }
        }

        public string Organization_Id {
            get { return this.mOrganization_Id; }
            set { this.mOrganization_Id = value; }
        }

        public string Employee_Id {
            get { return this.mEmployee_Id; }
            set { this.mEmployee_Id = value; }
        }

        public string Comments {
            get { return this.mComments; }
            set { this.mComments = value; }
        }

        public Guid Pos_Shift_Pr_Key {
            get { return this.mPos_Shift_Pr_key; }
            set { this.mPos_Shift_Pr_key = value; }
        }

        public string Export_Type_Id {
            get { return this.mExport_Type_Id; }
            set { this.mExport_Type_Id = value; }
        }

        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return this.mItem_Op_Id; }
            set { this.mItem_Op_Id = value; }
        }

        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return this.mPr_Detail_Id; }
            set { this.mPr_Detail_Id = value; }
        }

        private string mDealer_Id;
        public string Dealer_Id
        {
            get { return this.mDealer_Id; }
            set { this.mDealer_Id = value; }
        }

        private Int16 mIs_Change_Fee;
        public Int16 Is_Change_Fee
        {
            get { return mIs_Change_Fee; }
            set { mIs_Change_Fee = value; }
        }

        private Int16 mIs_Change_Name;
        public Int16 Is_Change_Name
        {
            get { return mIs_Change_Name; }
            set { mIs_Change_Name = value; }
        }

        private Int16 mIs_Change_Vehicle;
        public Int16 Is_Change_Vehicle
        {
            get { return mIs_Change_Vehicle; }
            set { mIs_Change_Vehicle = value; }
        }

        private string mStatus;
        public string Status
        {
            get { return this.mStatus; }
            set { this.mStatus = value; }
        }

        #region IHead Members

        public DataState DataState {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }

        public object IdValue {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }

        #endregion
    }
}