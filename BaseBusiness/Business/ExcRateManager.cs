#region

using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class ExcRateManager {
        private FTSMain mFTSMain;
        private string mMain_Currency = string.Empty;
        private string mSecond_Currency = string.Empty;

        public ExcRateManager(FTSMain ftsMain) {
            this.mFTSMain = ftsMain;
            this.mMain_Currency = this.mFTSMain.SystemVars.GetSystemVars("MAIN_CURRENCY").ToString().Trim().ToUpper();
            this.mSecond_Currency =
                this.mFTSMain.SystemVars.GetSystemVars("SECOND_CURRENCY").ToString().Trim().ToUpper();
        }

        /*
        public RateValue GetExchangeRate(string Nte, bool Main)
        {

            if (Nte.Trim() != string.Empty)
            {
                if (Main)
                {
                    if (Nte.Trim().ToUpper() == this.mMain_Currency)
                    {
                        return new RateValue(1, 1);
                    }
                    else
                    {
                        string sql = "select ty_gia from dm_tygia where ma_org = '" + this.mMain_Currency + "' and ma_nte = '" + Nte.Trim().ToUpper() + "' and ngay_hl <= " + Functions.ParseDate(this.mFTSMain.WorkingDay) + " order by ngay_hl desc";
                        object ty_gia = this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand(sql));
                        if ((ty_gia != null) && (ty_gia != DBNull.Value))
                        {
                            return new RateValue(ty_gia, 1);
                        }
                        else
                        {
                            sql = "select ty_gia from dm_tygia where ma_org = '" + Nte.Trim().ToUpper() + "' and ma_nte = '" + this.mMain_Currency + "' and ngay_hl <= " + Functions.ParseDate(this.mFTSMain.WorkingDay) + " order by ngay_hl desc";
                            ty_gia = this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand(sql));
                            if ((ty_gia != null) && (ty_gia != DBNull.Value))
                            {
                                return new RateValue(1, ty_gia);
                            }
                            else
                            {
                                throw (new FTSException("DONT_SET_EXCHANGE_RATE", new object[] { Nte, mMain_Currency }));
                            }
                        }
                    }
                }
                else
                {
                    if (Nte.Trim().ToUpper() == this.mSecond_Currency)
                    {
                        return new RateValue(1, 1);
                    }
                    else
                    {
                        string sql = "select ty_gia from dm_tygia where ma_org = '" + this.mSecond_Currency + "' and ma_nte = '" + Nte.Trim().ToUpper() + "' and ngay_hl <= " + Functions.ParseDate(this.mFTSMain.WorkingDay) + " order by ngay_hl desc";
                        object ty_gia = this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand(sql));
                        if ((ty_gia != null) && (ty_gia != DBNull.Value))
                        {
                            return new RateValue(ty_gia, 1);
                        }
                        else
                        {
                            sql = "select ty_gia from dm_tygia where ma_org = '" + Nte.Trim().ToUpper() + "' and ma_nte = '" + this.mSecond_Currency + "' and ngay_hl <= " + Functions.ParseDate(this.mFTSMain.WorkingDay) + " order by ngay_hl desc";
                            ty_gia = this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand(sql));
                            if ((ty_gia != null) && (ty_gia != DBNull.Value))
                            {
                                return new RateValue(1, ty_gia);
                            }
                            else
                            {
                                throw (new FTSException("DONT_SET_EXCHANGE_RATE"));
                            }
                        }
                    }
                }
            }
            else
            {
                return new RateValue(1, 1);
            }

        }
        */ 
        public string MainCurrency {
            get { return this.mMain_Currency; }
        }

        public string SecondCurrency {
            get { return this.mSecond_Currency; }
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
        }
    }
}