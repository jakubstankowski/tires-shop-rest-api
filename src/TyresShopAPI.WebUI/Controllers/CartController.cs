using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Models.Cart;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICustomerCartService _cartService;

        public CartController(ICustomerCartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost]
        [Route("AddOrUpdateCartItem")]
        public async Task<IActionResult> AddOrUpdateCartItem(CartItemModel model)
        {
            try
            {
                await _cartService.AddOrUpdateCartItem(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

        [HttpPost]
        [Route("RemoveCartItem")]
        public async Task<IActionResult> RemoveCartItem(CartItemModel model)
        {
            try
            {
                await _cartService.RemoveCartItem(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

    }
}
