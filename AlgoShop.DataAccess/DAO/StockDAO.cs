using AlgoShop.DataAccess.DAO.Interface;
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



        public List<Stock>? GetStocks()
        {
            DataTable dt = sqlDataAccess.Execute("select * from Stock");
            List<Stock> lstStock = null;

            lstStock = new List<Stock>();
            foreach (DataRow dr in dt.Rows)
            {
                lstStock.Add(new Stock
                {
                    ProductId = Convert.ToInt16(dr["ProductId"].ToString()),
                    StockId = Convert.ToInt16(dr["StockId"].ToString()),
                    StockedQuantity = Convert.ToInt16(dr["StockedQuantity"].ToString())
                });

            }
            if (lstStock.Count <= 0)
                return null;

            return lstStock;

        }

       
    }

}
