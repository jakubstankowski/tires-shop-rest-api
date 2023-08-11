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

        public async Task<IEnumerable<ProducerGet>> GetAllProducer()
        {
            var producers = await _context.Producers.Where(c => !c.IsDeleted)
                .Select(x => new ProducerGet() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Localization = x.Localization,
                }).ToListAsync();
            return producers;
        }

        public async Task<ProducerGet> GetProducerById(int producerId)
        {
            var producer = await _context.Producers.Where(c => !c.IsDeleted && c.Id == producerId).SingleOrDefaultAsync();

            if (producer == null)
            {
                throw new Exception();
            }

            ProducerGet producerCreate = new ProducerGet() 
            {
                Id = producer.Id,
                Name = producer.Name,
                Localization = producer.Localization,
            };

            return producerCreate;
        }

        public async Task DeleteProducerById(int producerId)
        {
            var producer = await _context.Producers.Where(x => x.Id == producerId).SingleOrDefaultAsync();

            if (producer == null)
            {
                throw new ArgumentNullException();
            }

            producer.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}
