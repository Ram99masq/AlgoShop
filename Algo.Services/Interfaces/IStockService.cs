using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Services.Interfaces
{
    public interface IStockService
    {
        List<Stock> GetStocks();      
    }
}
