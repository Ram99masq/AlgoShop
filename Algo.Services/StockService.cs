using Algo.Services.Interfaces;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Services
{
    public class StockService :IStockService
    {
        private readonly IStockDAO _stockDAO;

        public StockService(IStockDAO stockDAO)
        {
            _stockDAO = stockDAO;
        }

        public List<Stock> GetStocks()
        {
           return _stockDAO.GetStocks();
        }
      

    }
}
