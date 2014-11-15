using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Shift_Room : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private Guid mPr_Key_Folio;
        public Guid Pr_Key_Folio
        {
            get { return mPr_Key_Folio; }
            set { mPr_Key_Folio = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }
        private decimal mOpening_Balance;
        public decimal Opening_Balance
        {
            get { return mOpening_Balance; }
            set { mOpening_Balance = value; }
        }
        private decimal mCharge_Room;
        public decimal Charge_Room
        {
            get { return mCharge_Room; }
            set { mCharge_Room = value; }
        }
        private decimal mCharge_Hourly;
        public decimal Charge_Hourly
        {
            get { return mCharge_Hourly; }
            set { mCharge_Hourly = value; }
        }
        private decimal mCharge_After;
        public decimal Charge_After
        {
            get { return mCharge_After; }
            set { mCharge_After = value; }
        }
        private decimal mCharge_Before;
        public decimal Charge_Before
        {
            get { return mCharge_Before; }
            set { mCharge_Before = value; }
        }
        private decimal mCharge_Laundary;
        public decimal Charge_Laundary
        {
            get { return mCharge_Laundary; }
            set { mCharge_Laundary = value; }
        }
        private decimal mCharge_Minibar;
        public decimal Charge_Minibar
        {
            get { return mCharge_Minibar; }
            set { mCharge_Minibar = value; }
        }
        private decimal mCharge_Phone;
        public decimal Charge_Phone
        {
            get { return mCharge_Phone; }
            set { mCharge_Phone = value; }
        }
        private decimal mCharge_Restaurant;
        public decimal Charge_Restaurant
        {
            get { return mCharge_Restaurant; }
            set { mCharge_Restaurant = value; }
        }
        private decimal mCharge_Other;
        public decimal Charge_Other
        {
            get { return mCharge_Other; }
            set { mCharge_Other = value; }
        }
        private decimal mEnding_Balance;
        public decimal Ending_Balance
        {
            get { return mEnding_Balance; }
            set { mEnding_Balance = value; }
        }
        private decimal mPayment;
        public decimal Payment
        {
            get { return mPayment; }
            set { mPayment = value; }
        }
        private decimal mPayment_Money;
        public decimal Payment_Money
        {
            get { return mPayment_Money; }
            set { mPayment_Money = value; }
        }
        private decimal mPayment_Deposit;
        public decimal Payment_Deposit
        {
            get { return mPayment_Deposit; }
            set { mPayment_Deposit = value; }
        }
        private decimal mDeposit;
        public decimal Deposit
        {
            get { return mDeposit; }
            set { mDeposit = value; }
        }
        private decimal mDeposit_Return;
        public decimal Deposit_Return
        {
            get { return mDeposit_Return; }
            set { mDeposit_Return = value; }
        }
        private Int16 mIs_Check_Out;
        public Int16 Is_Check_Out
        {
            get { return mIs_Check_Out; }
            set { mIs_Check_Out = value; }
        }
        private decimal mDebit;
        public decimal Debit
        {
            get { return mDebit; }
            set { mDebit = value; }
        }
        private string mNotes;
        public string Notes
        {
            get { return mNotes; }
            set { mNotes = value; }
        }
        private decimal mLoss;
        public decimal Loss
        {
            get { return mLoss; }
            set { mLoss = value; }
        }
        private decimal mVat_Amount;
        public decimal Vat_Amount
        {
            get { return mVat_Amount; }
            set { mVat_Amount = value; }
        }
        private decimal mDiscount_Amount;
        public decimal Discount_Amount
        {
            get { return mDiscount_Amount; }
            set { mDiscount_Amount = value; }
        }
        private decimal mPayment_Transfer;
        public decimal Payment_Transfer
        {
            get { return mPayment_Transfer; }
            set { mPayment_Transfer = value; }
        }
        private Int16 mIs_Booking;
        public Int16 Is_Booking
        {
            get { return mIs_Booking; }
            set { mIs_Booking = value; }
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