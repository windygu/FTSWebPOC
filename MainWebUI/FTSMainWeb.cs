using System.Data;
using System.Data.SqlClient;
using FTS.BaseBusiness.Systems;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FTS.MainWebUI
{
    public class FTSMainWeb : FTSMain
    {
        public DataTable GetTable(string tableName, string sql)
        {
            Database db = new SqlDatabase(StaticWeb.CONNECTION_STRING);
            return db.LoadDataTable(new SqlCommand(sql), tableName);
        }

        public void SaveItem()
        {
            
        }
    }
}