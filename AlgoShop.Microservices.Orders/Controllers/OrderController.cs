using Algo.Services.OrderServices.Interfaces;
using AlgoShop.DataAccess.EF;
using AlgoShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoShop.Microservices.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private IConfiguration Configuration;
        private readonly AlgoShopContext _algoShopContext;

        public OrderController(ILogger<OrderController> logger, AlgoShopContext algoShopContext, IOrderService orderService, IConfiguration _configuration)
        {
            _logger = logger;
            _algoShopContext = algoShopContext;
            _orderService = orderService;
            Configuration = _configuration;
        }


        [HttpPost(Name = "CreateOrder")]
        public string CreateOrder(Order order)
        {
            return _orderService.CreateOrder(order);
        }
    }
}
