using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Common
{
    public class SqlHelper
    {
        public static string conStr { get; set; }
        public static DataTable ExecuteTable(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open(); //open data
                SqlCommand cmd = new SqlCommand(cmdText, con); //Tell admin to get which data. Give key to admin.
                SqlDataAdapter sda = new SqlDataAdapter(cmd);   //Put items in a trolly
                DataSet ds = new DataSet(); //Put item on track. Track has few container
                sda.Fill(ds);   //Put data from trolly to track.
                return ds.Tables[0]; //As we only have one table, so only return first table.
            }
        }
    }
}
