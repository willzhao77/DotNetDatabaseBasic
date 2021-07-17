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
                con.Open(); //打开仓库门
                SqlCommand cmd = new SqlCommand(cmdText, con); //告诉管家拿什么东西。 把SQL语句传进去。同时把仓库钥匙(con)给管理员
                SqlDataAdapter sda = new SqlDataAdapter(cmd);   //拿推车装东西用
                DataSet ds = new DataSet(); //放运输卡车上。 这里有一个个集装箱
                sda.Fill(ds);   //推车里的东西装卡车上
                return ds.Tables[0]; //由于我们只用了第一个表， 这里只return第一个表
            }
        }
    }
}
