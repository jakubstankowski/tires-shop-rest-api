using TyresShopAPI.Domain.Models.Cart;

namespace TyresShopAPI.Application.Interfaces
{
    public interface ICustomerCartService
    {
        public Task AddOrUpdateCartItem(CartItemModel model);

        public Task RemoveCartItem(CartItemModel model);

        public Task RegisterCustomerCart(string customerEmail);

    }
}
