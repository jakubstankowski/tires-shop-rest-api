using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class CustomerCartService : BaseService, ICustomerCartService
    {
        public CustomerCartService(Context context) : base(context)
        {
        }

        public Task AddOrUpdateCartItem(CartItemCreate model)
        {
            throw new NotImplementedException();
        }

        public Task RegisterCustomerCart(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCartItem(int cartItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerCart(UpdateCustomerCart createCartItem)
        {
            throw new NotImplementedException();
        }
    }
}
