using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parkomate_Parking_Management_Software.Model;
using Parkomate_Parking_Management_Software.BL.Utilities;


namespace Parkomate_Parking_Management_Software
{
    class CallSP
    {

        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        

        public void Test(List<SensorData> lstZoneValues)
        {

            DataTable dtZoneValues = lstZoneValues.ToDataTable();
            try
            {
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("uspSaveSensorData", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@tvpSensorData";
                    param1.SqlDbType = SqlDbType.Structured;
                    param1.TypeName = "tvpSensorData";
                    param1.SqlValue = dtZoneValues;


                    sql_cmnd.Parameters.Add(param1);
                    //sql_cmnd.Parameters.AddWithValue("ZoneName", SqlDbType.NVarChar).Value = ZoneName;
                    //sql_cmnd.Parameters.AddWithValue("SensorString ", SqlDbType.NVarChar).Value = SensorString;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
       
        }
    }
}
