using Algo.Services.OrderServices.Interfaces;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.EF;
using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Services.OrderServices
{
    public class OrderService : IOrderService
    {

        private readonly IOrderDAO _orderDAO;
        private readonly IStockDAO _stockDAO;
        private readonly AlgoShopContext _algoShopContext;
        public OrderService(AlgoShopContext algoShopContext,IOrderDAO orderDAO, IStockDAO stockDAO)
        {
            _algoShopContext = algoShopContext;
            _orderDAO = orderDAO;
            _stockDAO = stockDAO;
        }


        public string CreateOrder(Order order)
        {
            Stock lstStock = _stockDAO.GetStocks().ToList().Where(a => a.ProductId.Equals(order.ProductId) & a.StockedQuantity > 0).ToList().FirstOrDefault();
            if (order.OrderedQuantity == 0)
                return "Ordered quantity should be greater than Zero";
            if (lstStock == null)
            {
                return "Ordered ProductId not found / No stock found for the ProductId";
            }
            if (lstStock != null && order.OrderedQuantity > lstStock.StockedQuantity)
                return "Ordered quantity cannot be more than the stocked quantity";
            else
            {
                int rows = _orderDAO.CreateOrder(order);
                if (rows > 0)
                {
                    return "Order place successfully for the product - " + order.ProductId;
                }
                else
                    return "Internal server error";
            }

        }
    }
}
