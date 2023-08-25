using TyresShopAPI.Domain.Models.Cart;

namespace TyresShopAPI.Application.Interfaces
{
    public interface ICustomerCartService
    {
        public Task AddOrUpdateCartItem(CartItemCreate model);

        public Task RemoveCartItem(int cartItemId);

        public Task UpdateCustomerCart(UpdateCustomerCart model);

        public Task RegisterCustomerCart(int customerId);

    }
}
