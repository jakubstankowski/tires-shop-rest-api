using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class CartService : BaseService, ICartService
    {
        public CartService(Context context) : base(context)
        {
        }

        public async Task AddCartItem(CreateCartItem createCartItem)
        {
           /* if (!createCartItem.Items.Any())
            {
                return;
            }


            foreach (var cartItem in createCartItem.Items)
            {
                var isCartItemExist = await IsCartItemExists(createCartItem.CartId, cartItem.TyreId);

                if (isCartItemExist)
                {
                    return;
                }

                var cartDbItem = await (from tyre in _context.Tyres
                                  where tyre.Id == createCartItem.CartId
                                  select new CartItem
                                  {
                                      CartId = createCartItem.CartId,
                                      TyreId = tyre.Id,
                                      Quantity = cartItem.Quantity,
                                      TotalValue = tyre.Price * cartItem.Quantity
                                  }).SingleOrDefaultAsync();

                if (cartDbItem != null)
                {
                    await _context.CartItems.AddAsync(cartDbItem);
                    await _context.SaveChangesAsync();
                }
            }*/
        }

        public async Task<bool> IsCartItemExists(int cartId, int tyreId)
            => await _context.CartItems.AnyAsync(c => c.CartId == cartId && c.TyreId == tyreId);
    }
}
