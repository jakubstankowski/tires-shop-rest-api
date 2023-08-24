using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Models.Cart;

namespace TyresShopAPI.Application.Interfaces
{
    public interface ICartService
    {
        public Task AddCartItem(CreateCartItem createCartItem);

        public Task<bool> IsCartItemExists(int cartId, int tyreId);

    }
}
