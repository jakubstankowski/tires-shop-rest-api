using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Exceptions;
using TyresShopAPI.Domain.Models.DeliveryMethod;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class DeliveryMethodService : BaseService, IDeliveryMethodService
    {
        public DeliveryMethodService(Context context) : base(context)
        {
        }

        public Task<DeliveryMethodView?> GetDeliveryMethodById(int deliveryMethodId)
        {
            var result  = _context.DeliveryMethods.Where(x => x.Id == deliveryMethodId)
                .Select(x => new DeliveryMethodView()
                {
                    Id = x.Id,
                    Price = x.Price,
                    Name = x.Name,
                    DeliveryTime = x.DeliveryTime
                })
                .SingleOrDefaultAsync();

            if (result == null)
            {
                throw new DeliveryMethodNotFoundException(deliveryMethodId);
            }

            return result;
        }
    }
}
