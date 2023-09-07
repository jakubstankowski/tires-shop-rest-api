using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Application.Services;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Domain.Models.Orders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrder model)
        {
            try
            {
                await _orderService.CreateOrder(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

        [HttpGet]
        [Route("GetOrderByCustomerId/{customerId}")]
        public async Task<IActionResult> GetOrderByCustomerId(string customerId)
        {
            var result = await _orderService.GetOrdersByCustomerId(customerId);

            return Ok(result);
        }
    }
}
