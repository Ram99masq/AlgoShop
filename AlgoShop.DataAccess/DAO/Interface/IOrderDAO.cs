using AlgoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess.DAO.Interface
{
    public interface IOrderDAO
    {
        int CreateOrder(Order order);
    }
}
