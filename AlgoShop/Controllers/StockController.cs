using Algo.Services.Interfaces;
using AlgoShop.DataAccess;
using AlgoShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly IStockService _stockService;

        public StockController(ILogger<StockController> logger, IStockService stockService, IConfiguration _configuration)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [HttpGet(Name = "GetStock")]
        public List<Stock> GetStock()
        {
            return _stockService.GetStocks();
        }

        //[HttpGet(Name = "GetProduct")]       
        //public List<Product>  GetProduct()
        //{
        //   return _stockService.GetProduct();
        //}
    }
}
