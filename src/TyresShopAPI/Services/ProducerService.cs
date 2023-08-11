using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Entities;
using TyresShopAPI.Exceptions;
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

        public async Task<IEnumerable<ProducerCreate>> GetAllProducer()
        {
            var producers = await _context.Producers.Where(c => !c.IsDeleted)
                .Select(x => new ProducerCreate() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Localization = x.Localization,
                }).ToListAsync();
            return producers;
        }

        public async Task<ProducerCreate> GetProducerById(int producerId)
        {
            var producer = await _context.Producers.Where(c => !c.IsDeleted && c.Id == producerId).SingleOrDefaultAsync();

            if (producer == null)
            {
                throw new DidntFindProducerAtGivenIdException(producerId);
            }

            ProducerCreate producerCreate = new ProducerCreate() 
            {
                Id = producer.Id,
                Name = producer.Name,
                Localization = producer.Localization,
            };

            return producerCreate;
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
    }
}
