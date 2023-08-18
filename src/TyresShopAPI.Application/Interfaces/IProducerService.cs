using TyresShopAPI.Domain.Models.Producer;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IProducerService
    {
        public Task AddOrUpdateProducer(ProducerCreate producerCreate);

        public Task<ProducerView?> GetProducerBydId(int producerId);

        public Task<IEnumerable<ProducerView>> GetAllProducers();

        public Task DeleteProducerById(int producerId);

    }
}
