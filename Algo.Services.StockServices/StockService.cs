using Algo.Services.StockServices.Interfaces;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.EF;
using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Services.StockServices
{
    public class StockService : IStockService
    {
        private readonly IStockDAO _stockDAO;
        private readonly AlgoShopContext _algoShopContext;
        public StockService(AlgoShopContext algoShopContext,IStockDAO stockDAO)
        {
            _algoShopContext = algoShopContext;
            _stockDAO = stockDAO;
        }

        public List<Stock> GetStocks()
        {
            return _stockDAO.GetStocks();
        }

        public int UpdateStock(Order order)
        {
            return _stockDAO.UpdateStock(order);
        }
    }
}
