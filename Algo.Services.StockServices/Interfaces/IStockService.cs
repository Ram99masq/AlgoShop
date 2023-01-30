using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Services.StockServices.Interfaces
{
    public interface IStockService
    {
        List<Stock> GetStocks();
        int  UpdateStock(Order order);
    }
}
