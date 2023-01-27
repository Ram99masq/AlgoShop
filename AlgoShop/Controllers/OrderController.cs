using Algo.Services.Interfaces;
using AlgoShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private IConfiguration Configuration;


        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IConfiguration _configuration)
        {
            _logger = logger;
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
