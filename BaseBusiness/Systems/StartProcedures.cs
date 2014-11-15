using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTS.BaseBusiness.Systems {
    public class StartProcedures {
        public StartProcedures() {
            
        }
        public virtual void BackupData() {
            
        }
        public virtual bool LoadReport(string report_id, string parent_id) {
            return false;
        }
        public virtual bool ExecuteProcedures(string menu_id) {
            return false;
        }

        public virtual bool RunTransaction(string menu_id) {
            return false;
        }

        public virtual void ExecuteSystemProcedures(string menu_id) {

        }
        public virtual bool LoadReport(string report_id) {
            return false;
        }
        public virtual void RefreshTransaction(DateTime daystart, DateTime dayend, bool showerror,string item_op_id) {
            
        }
        public virtual void RefreshFixedPrice(DateTime daystart, DateTime dayend) {

        }
        public virtual void RefreshTransactionPrints(DateTime daystart, DateTime dayend) {

        }
        public virtual void ReUploadTransaction(DateTime daystart, DateTime dayend) {

        }
        public virtual void RefreshPrints() {
            
        }
    }
}
