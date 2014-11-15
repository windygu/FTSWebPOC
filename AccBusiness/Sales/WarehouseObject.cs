using System;
using System.Data;

namespace FTS.AccBusiness.Sale
{
    public class WarehouseObject {
        
        private string mComments = String.Empty;

        private string mIssue_Receive = String.Empty;

        private string mOrganization_Id = String.Empty;

        private Guid mPr_Key;

        private Guid mPr_Key_Detail;

        private Guid mPr_Key_Warehouse;


        private decimal mQuantity = 0;


        private DateTime mTran_Date = DateTime.Today;

        private string mTran_Id = String.Empty;

        private string mTran_No = String.Empty;

        private string mItem_Id = String.Empty;
        
        public string Comments {
            get { return this.mComments; }
            set { this.mComments = value; }
        }


        public string Issue_Receive {
            get { return this.mIssue_Receive; }
            set { this.mIssue_Receive = value; }
        }

        public string Organization_Id {
            get { return this.mOrganization_Id; }
            set { this.mOrganization_Id = value; }
        }

        public Guid Pr_Key {
            get { return this.mPr_Key; }
            set { this.mPr_Key = value; }
        }

        public Guid Pr_Key_Detail {
            get { return this.mPr_Key_Detail; }
            set { this.mPr_Key_Detail = value; }
        }

        public Guid Pr_Key_Warehouse {
            get { return this.mPr_Key_Warehouse; }
            set { this.mPr_Key_Warehouse = value; }
        }

        
        
        public decimal Quantity {
            get { return this.mQuantity; }
            set { this.mQuantity = value; }
        }

        
        public DateTime Tran_Date {
            get { return this.mTran_Date; }
            set { this.mTran_Date = value; }
        }

        public string Tran_Id {
            get { return this.mTran_Id; }
            set { this.mTran_Id = value; }
        }

        public string Tran_No {
            get { return this.mTran_No; }
            set { this.mTran_No = value; }
        }

        public string Item_Id {
            get { return this.mItem_Id; }
            set { this.mItem_Id = value; }
        }
        
        public WarehouseObject Copy() {
            return (WarehouseObject) this.MemberwiseClone();
        }
    }
}