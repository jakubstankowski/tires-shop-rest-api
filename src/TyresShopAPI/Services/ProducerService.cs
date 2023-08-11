using Microsoft.EntityFrameworkCore;
using System.Threading;
using TyresShopAPI.Entities;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models.Producer;
using TyresShopAPI.Models.Tyres;

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

        public async Task DeleteProducerById(int id)
        {

            var tyre = await _context.Producers.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (tyre == null)
            {
                throw new ArgumentNullException();
            }

            tyre.IsDeleted = true;

            await _context.SaveChangesAsync();



        }

        public async Task<IEnumerable<ProducerView>> GetAllProducers()
        {

            return await _context.Producers
    .Where(x=>!x.IsDeleted)
    .Select(x => new ProducerView()
    {
        Id = x.Id,
        Name = x.Name,
        Localization = x.Localization,
    }).ToListAsync();



        }

        public async Task<ProducerView> GetProducerBydId(int producerId)
        {
            var result = await _context.Producers
                .Where(x => x.Id == producerId && !x.IsDeleted)
                .Select(x => new ProducerView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Localization = x.Localization,

                }).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentNullException();
            }

            return result;

            //throw new NotImplementedException();
        }
    }
}
