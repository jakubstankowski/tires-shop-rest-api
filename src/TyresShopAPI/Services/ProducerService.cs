using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Entities;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models.Producer;

namespace TyresShopAPI.Services
{
    public class ProducerService : BaseService, IProducerService
    {
        public ProducerService(IContext context) : base(context)
        {
        }

        public async Task AddOrUpdateProducer(ProducerCreate model)
        {
            var dbProducer = new Producer();

            if (model.Id > 0)
            {
                dbProducer = await _context.Producers.SingleAsync(c => c.Id == model.Id);
            }

            dbProducer.Localization = model.Localization;
            dbProducer.Name = model.Name;

            if (model.Id == 0)
            {
                _context.Producers.Add(dbProducer);
            }


            await _context.SaveChangesAsync();
        }
    }
}
