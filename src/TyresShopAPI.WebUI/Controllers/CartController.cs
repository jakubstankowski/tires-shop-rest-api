using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Domain.Models.Tyres;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost]
        [Route("AddOrUpdateCartItem")]
        public async Task<IActionResult> AddOrUpdateCartItem(CreateCartItem model)
        {
            try
            {
                await _cartService.AddCartItem(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

    }
}
