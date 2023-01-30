using Algo.Services.StockServices.Interfaces;
using AlgoShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace AlgoShop.Microservices.Stocks.Controllers
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

        [HttpPut(Name = "UpdateStock")]
        public int UpdateStock(Order order)
        {
            return _stockService.UpdateStock( order);
        }

        //[HttpGet(Name = "GetProduct")]       
        //public List<Product>  GetProduct()
        //{
        //   return _stockService.GetProduct();
        //}
    }
}
