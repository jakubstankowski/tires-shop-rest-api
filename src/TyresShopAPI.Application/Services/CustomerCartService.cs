using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities;
using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Exceptions;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class CustomerCartService : BaseService, ICustomerCartService
    {
        public CustomerCartService(Context context) : base(context)
        {
        }

        public async Task AddOrUpdateCartItem(CartItemModel model)
        {
            var isTyreExist = _context.Tyres.Any(t => t.Id == model.TyreId);

            if (!isTyreExist)
            {
                throw new TyreNotFoundException(model.TyreId);
            }

            var customer = await _context
                .Users.Include(u => u.CustomerCart)
                .ThenInclude(ct => ct.Items)
                .FirstOrDefaultAsync(x => x.Id == model.CustomerId);

            if (customer is null)
            {
                throw new CustomerNotFoundException(model.CustomerId);
            }

            var isCartItemExist = customer.CustomerCart.Items.Any(x => x.TyreId == model.TyreId);

            var cartItem = new CartItem()
            {
                TyreId = model.TyreId,
                Quantity = model.Quantity,
                TotalValue = await CalculateTotalValue(model.TyreId, model.Quantity),
                CustomerCart = customer.CustomerCart
            };

            if (!isCartItemExist)
            {
                customer.CustomerCart.Items.Add(cartItem);
            }
            else
            {
                var dbCartItem = customer.CustomerCart.Items.FirstOrDefault(x => x.TyreId == model.TyreId);

                dbCartItem.TotalValue = await CalculateTotalValue(model.TyreId, model.Quantity);
                dbCartItem.Quantity = model.Quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RegisterCustomerCart(string customerEmail)
        {
            var customer = await _context.Users
                .Where(x => x.Email!.Equals(customerEmail))
                .Include(c => c.CustomerCart)
                .SingleOrDefaultAsync();

            customer!.CustomerCart = new CustomerCart()
            {
                Customer = customer,
                CustomerId = customer.Id
            };

            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartItem(CartItemModel model)
        {
            var customer = await _context
                .Users.Include(u => u.CustomerCart)
                .ThenInclude(ct => ct.Items)
                .FirstOrDefaultAsync(x => x.Id == model.CustomerId);

            if (customer is null)
            {
                throw new CustomerNotFoundException(model.CustomerId);
            }

            var isCartItemExist = customer.CustomerCart.Items.Any(x => x.TyreId == model.TyreId);

            if (isCartItemExist)
            {
                customer.CustomerCart.Items.RemoveAll(x => x.TyreId == model.TyreId);
            }

            await _context.SaveChangesAsync();
        }

        private async Task<decimal> CalculateTotalValue(int tyreId, int quantity)
        {
            var tyre = await _context.Tyres.FindAsync(tyreId);

            return tyre!.Price * quantity;
        }
    }
}
