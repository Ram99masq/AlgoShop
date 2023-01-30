using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.EF;
using AlgoShop.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using System.Net;

namespace AlgoShop.DataAccess.DAO
{
    public class OrderDAO : IOrderDAO
    {
        SqlDataAccess sqlDataAccess = SqlDataAccess.GetSqlDataAccess();
        private object cancellationToken;
        private readonly AlgoShopContext _algoShopContext;
        private readonly string STOCK_URL = "https://localhost:7179/api";
        public OrderDAO(AlgoShopContext algoShopContext)
        {
            _algoShopContext = algoShopContext;
        }
        public int CreateOrder(Order order)
        {
            //ADO.NET
            //string sql = "insert into [Order] ([ProductId]      ,[CustomerId] ,[OrderedQuantity]) values("
            //           + order.ProductId + "," + order.CustomerId + "," + order.OrderedQuantity +") ;";
            //      sql += $"update [Stock] set [StockedQuantity] = [StockedQuantity] - {order.OrderedQuantity} where Productid={order.ProductId} ";

            //int isSuccess = sqlDataAccess.ExecuteNonQuery(sql);
            //return isSuccess;

            //EF core
            _algoShopContext.Order.Add(order);
            _algoShopContext.SaveChanges();
            //_algoShopContext.Database.ExecuteSqlRaw($"update [Stock] set [StockedQuantity] = [StockedQuantity] - {order.OrderedQuantity} where Productid={order.ProductId} ");


            //Call the microservice client for Stocks
            var client = new RestClient(STOCK_URL);
            var request = new RestRequest("/stock");
         
            request.AddBody(order);
            var restResponse = client.Put(request);
          
            if (restResponse.StatusCode == HttpStatusCode.OK & Convert.ToInt16(restResponse.Content) == 1)
            {
                return 1;
            }

            return 0;
               
           

        }
    }
}
