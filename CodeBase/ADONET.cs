using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CodeBase
{
    class ADONET
    {
        public Boolean GetUpdateGoFlagFromDB()
        {
            try
            {
                var tb = new DataTable();
                using (var dbConn = new SqlConnection(""))
                {
                    var cmd = new SqlCommand("spApp_GetDataBaseUpdatingFlag", dbConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dbConn.Open();
                    tb.Load(cmd.ExecuteReader());
                }
                if (tb.Rows.Count < 1)
                {
                    return false;
                }
                DataRow row = tb.Rows[0];

                Boolean.TryParse(row["GOFLAG"].ToString(), out bool goFlag);
                return goFlag;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
