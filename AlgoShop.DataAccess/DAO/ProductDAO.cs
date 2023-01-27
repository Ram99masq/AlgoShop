using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess.DAO
{
    public class ProductDAO
    {
        SqlDataAccess sqlDataAccess = SqlDataAccess.GetSqlDataAccess();

        public List<Product> GetProduct()
        {
            DataTable dt = sqlDataAccess.Execute("select * from Product");
            List<Product>? lstOrder = null;

            lstOrder = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                lstOrder.Add(new Product { ProductId = Convert.ToInt16(dr["ProductId"].ToString()), ProductName = dr["ProductName"].ToString() });

            }
            return lstOrder;
        }
    }
}
