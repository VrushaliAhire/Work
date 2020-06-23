using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    class CallSP
    {

        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        

        public void Test(String ZoneName, String SensorString)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspSaveSensorData", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("ZoneName", SqlDbType.NVarChar).Value = ZoneName;
                sql_cmnd.Parameters.AddWithValue("SensorString ", SqlDbType.NVarChar).Value = SensorString;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();

            }

        }
    }
}
