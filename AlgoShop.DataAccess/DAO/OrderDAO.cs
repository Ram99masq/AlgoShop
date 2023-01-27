using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess.DAO
{
    public class OrderDAO : IOrderDAO
    {
        SqlDataAccess sqlDataAccess = SqlDataAccess.GetSqlDataAccess();

        public int CreateOrder(Order order)
        {
            string sql = "insert into [Order] ([ProductId]      ,[CustomerId] ,[OrderedQuantity]) values("
                       + order.ProductId + "," + order.CustomerId + "," + order.OrderedQuantity +") ;";
                  sql += $"update [Stock] set [StockedQuantity] = [StockedQuantity] - {order.OrderedQuantity} where Productid={order.ProductId} ";

            int isSuccess = sqlDataAccess.ExecuteNonQuery(sql);

            return isSuccess;

        }
    }
}
