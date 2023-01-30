using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.EF;
using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess.DAO
{
    public class StockDAO : IStockDAO
    {
        SqlDataAccess sqlDataAccess = SqlDataAccess.GetSqlDataAccess();
        private readonly AlgoShopContext _algoShopContext;

        public StockDAO(AlgoShopContext algoShopContext)
        {
            _algoShopContext = algoShopContext;
        }

        public List<Stock>? GetStocks()
        {
            //DataTable dt = sqlDataAccess.Execute("select * from Stock");
            //List<Stock> lstStock = null;

            //lstStock = new List<Stock>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    lstStock.Add(new Stock
            //    {
            //        ProductId = Convert.ToInt16(dr["ProductId"].ToString()),
            //        StockId = Convert.ToInt16(dr["StockId"].ToString()),
            //        StockedQuantity = Convert.ToInt16(dr["StockedQuantity"].ToString())
            //    });
            //}


            IQueryable<Stock> rtn = from stocks in _algoShopContext.Stock select stocks;
            var lstStock = rtn.ToList();


            if (lstStock.Count <= 0)
                return null;

            return lstStock;

        }


        public int UpdateStock(Order order)
        {
            Stock rtn = _algoShopContext.Stock.Where(a => a.ProductId.Equals(order.ProductId)).FirstOrDefault();
            rtn.StockedQuantity = rtn.StockedQuantity - order.OrderedQuantity;
            _algoShopContext.Update(rtn);
            return _algoShopContext.SaveChanges();
        }



    }

}
