using Algo.Services.Interfaces;
using AlgoShop.DataAccess.DAO;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.Models;

namespace Algo.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderDAO _orderDAO;
        private readonly IStockDAO _stockDAO;

        public OrderService(IOrderDAO orderDAO, IStockDAO stockDAO)
        {
            _orderDAO = orderDAO;
            _stockDAO = stockDAO;
        }


        public string CreateOrder(Order order)
        {
            Stock lstStock = _stockDAO.GetStocks().ToList().Where(a => a.ProductId.Equals(order.ProductId) & a.StockedQuantity>0).ToList().FirstOrDefault();
            if (order.OrderedQuantity == 0)
                return "Ordered quantity should be greater than Zero";
            if (lstStock == null)
            { 
                return "Ordered ProductId not found / No stock found for the ProductId";
            }
            if (lstStock!=null && order.OrderedQuantity > lstStock.StockedQuantity)
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