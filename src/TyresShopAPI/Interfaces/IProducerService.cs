using TyresShopAPI.Models.Producer;

namespace TyresShopAPI.Interfaces
{
    public interface IProducerService
    {
        public Task AddOrUpdateProducer(ProducerCreate producerCreate);

        public Task<IEnumerable<ProducerView>> GetAllProducers();

        public Task<ProducerView> GetProducerBydId(int producerId);

        public Task DeleteProducerById(int producerId);
    }
}
