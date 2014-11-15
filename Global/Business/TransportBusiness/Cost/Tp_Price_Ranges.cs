using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost {
    public class Tp_Price_Ranges : IHead {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        #region IHead Members

        public DataState DataState {
            get {
                return this.mDataState;
            }
            set {
                this.mDataState = value;
            }
        }

        public object IdValue {
            get {
                return this.mIdValue;
            }
            set {
                this.mIdValue = value;
            }
        }
        #endregion
        private decimal mPrice;
        public decimal Price {
            get { return mPrice; }
            set { mPrice = value; }
        }
        private decimal mKm_From;
        public decimal Km_From {
            get { return mKm_From; }
            set { mKm_From = value; }
        }
        private decimal mKm_To;
        public decimal Km_To {
            get { return mKm_To; }
            set { mKm_To = value; }
        }
        private string mItem_Id;
        public string Item_Id {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private string mFuel_Cost_Method;
        public string Fuel_Cost_Method {
            get { return mFuel_Cost_Method; }
            set { mFuel_Cost_Method = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
    }

}
