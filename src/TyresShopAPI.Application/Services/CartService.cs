using TyresShopAPI.Application.Interfaces;
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
          
        }

    }
}
