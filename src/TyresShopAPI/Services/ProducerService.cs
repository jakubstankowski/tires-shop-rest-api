using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Entities;
using TyresShopAPI.Exceptions;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models.Producer;
using TyresShopAPI.Models.Tyres;

namespace TyresShopAPI.Services
{
    public class ProducerService : BaseService, IProducerService
    {
        private readonly ILogger<ProducerService> _logger;

        public ProducerService(IContext context, ILogger<ProducerService> logger) : base(context)
        {
            _logger = logger;
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

            _logger.LogInformation("Producer success add or update");
        }

        public async Task<ProducerView> GetProducerBydId(int producerId)
        {
            var result = await _context.Producers
                .Where(x => x.Id == producerId && !x.IsDeleted)
                .Select(x => new ProducerView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Localization = x.Name
                }).SingleOrDefaultAsync();

            if (result == null)
            {
                _logger.LogInformation($"Producer with id {producerId} not found");
                throw new ProducerNotFoundException(producerId);
            }

            return result;
        }

        public async Task<IEnumerable<ProducerView>> GetAllProducers()
        {
            return await _context.Producers
                .Where(x => !x.IsDeleted)
                .Select(x => new ProducerView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Localization = x.Localization
                }).ToListAsync();
        }

        public async Task DeleteProducerById(int producerId)
        {
            var producer = await _context.Producers.Where(x => x.Id == producerId).SingleOrDefaultAsync();

            if (producer == null)
            {
                _logger.LogInformation($"Producer with id {producerId} not found");
                throw new ProducerNotFoundException(producerId);
            }

            producer.IsDeleted = true;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Producer with id {producerId} success delete");
        }
    }
}
