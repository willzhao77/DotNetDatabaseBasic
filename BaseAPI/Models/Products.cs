using BaseAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models
{
    public class Products
    {
        private static object Sqlhelper;

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int Age { get; set; }
        public int DeptId { get; set; }

        public static List<Products> GetProductList()
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from UserInfo");
            List<Products> products = new List<Products>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(ToModel(dt.Rows[i]));
            }
            return products;
        }

        private static Products ToModel(DataRow dr)
        {
            Products product = new Products();
            product.UserId = (int)dr["UserId"];
            product.UserName = dr["UserName"].ToString();
            product.UserPwd = dr["UserPwd"].ToString();
            product.Age = (int)dr["Age"];
            return product;
        }
    }
}
